// Copyright 2005-2008 Gallio Project - http://www.gallio.org/
// Portions Copyright 2000-2004 Jonathan de Halleux
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using Gallio.Collections;
using Gallio.Framework.Data;
using MbUnit.Framework;

namespace Gallio.Tests.Framework.Data
{
    [TestFixture]
    [TestsOn(typeof(XmlDataSet))]
    [DependsOn(typeof(BaseDataSetTest))]
    public class XmlDataSetTest
    {
        [Test, ExpectedArgumentNullException]
        public void ConstructorThrowsWhenDocumentIsNull()
        {
            new XmlDataSet(null, "", false);
        }

        [Test, ExpectedArgumentNullException]
        public void ConstructorThrowsWhenRowPathIsNull()
        {
            new XmlDataSet(delegate { return new XmlDocument(); }, null, false);
        }

        [Test]
        [Row(true)]
        [Row(false)]
        public void IsDynamicPropertyIsSameAsWasSpecifiedInTheConstructor(bool isDynamic)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<root><rows><row a=\"42\"/></rows></root>");

            XmlDataSet dataSet = new XmlDataSet(delegate { return document; }, "//row", isDynamic);
            List<IDataRow> rows = new List<IDataRow>(dataSet.GetRows(EmptyArray<DataBinding>.Instance, true));
            Assert.AreEqual(1, rows.Count);
            Assert.AreEqual(isDynamic, rows[0].IsDynamic);
        }

        [Test]
        public void GetRowsReturnsNothingIfIsDynamicAndNotIncludingDynamicRows()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<root><rows><row a=\"42\"/></rows></root>");

            XmlDataSet dataSet = new XmlDataSet(delegate { return document; }, "//row", true);
            List<IDataRow> rows = new List<IDataRow>(dataSet.GetRows(EmptyArray<DataBinding>.Instance, false));
            Assert.AreEqual(0, rows.Count);
        }

        [Test]
        public void ColumnCountIsZero()
        {
            XmlDataSet dataSet = new XmlDataSet(delegate { return new XmlDocument(); }, "", false);
            Assert.AreEqual(0, dataSet.ColumnCount);
        }

        [Test]
        public void CanBindReturnsTrueIfAndOnlyIfTheColumnPathCanBeResolvedInTheDocument()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<root><rows><row a=\"42\"/><row a=\"53\"/></rows></root>");

            XmlDataSet dataSet = new XmlDataSet(delegate { return document; }, "//row", false);

            Assert.IsFalse(dataSet.CanBind(new SimpleDataBinding(null, null)),
                "CanBind should return false if there is no binding path.");
            Assert.IsFalse(dataSet.CanBind(new SimpleDataBinding(null, "not valid xpath")),
                "CanBind should return false if the binding path is an invalid XPath expression.");
            Assert.IsFalse(dataSet.CanBind(new SimpleDataBinding(null, "@b")),
                "CanBind should return false if the binding path cannot be resolved in the rows.");
            Assert.IsTrue(dataSet.CanBind(new SimpleDataBinding(null, "@a")),
                "CanBind should return true if the binding path can be resolved in the rows.");
        }

        [Test]
        public void GetRowsReturnsXPathNavigatorsForAllSelectedValues()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml("<root><rows><row a=\"42\" b=\"x\"/><row a=\"53\" b=\"y\"/></rows></root>");

            XmlDataSet dataSet = new XmlDataSet(delegate { return document; }, "//row", false);

            DataBinding[] bindings = new DataBinding[]
            {
                new SimpleDataBinding(null, "@a"),
                new SimpleDataBinding(null, "@b")
            };

            List<IDataRow> rows = new List<IDataRow>(dataSet.GetRows(bindings, true));

            Assert.AreEqual("42", ((XPathNavigator)rows[0].GetValue(bindings[0])).Value);
            Assert.AreEqual("x", ((XPathNavigator)rows[0].GetValue(bindings[1])).Value);
            Assert.AreEqual("53", ((XPathNavigator)rows[1].GetValue(bindings[0])).Value);
            Assert.AreEqual("y", ((XPathNavigator)rows[1].GetValue(bindings[1])).Value);

            InterimAssert.Throws<DataBindingException>(delegate { rows[0].GetValue(new SimpleDataBinding(0, null)); });
            InterimAssert.Throws<DataBindingException>(delegate { rows[0].GetValue(new SimpleDataBinding(null, "not valid xpath")); });
        }
    }
}
