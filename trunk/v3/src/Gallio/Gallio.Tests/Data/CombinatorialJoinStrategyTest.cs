using System.Collections.Generic;
using Gallio.Data;
using Rhino.Mocks;
using MbUnit.Framework;

namespace Gallio.Tests.Data
{
    [TestFixture]
    [TestsOn(typeof(CombinatorialJoinStrategy))]
    public class CombinatorialJoinStrategyTest : BaseUnitTest
    {
        [Test]
        public void HandlesDegenerateCaseWithZeroProviders()
        {
            DataBinding[][] bindingsPerProvider = new DataBinding[0][];
            IDataProvider[] providers = new IDataProvider[0];

            List<IList<IDataRow>> rows = new List<IList<IDataRow>>(CombinatorialJoinStrategy.Instance.Join(providers, bindingsPerProvider));
            Assert.AreEqual(0, rows.Count);
        }

        [Test]
        public void JoinsRowsCombinatorially()
        {
            DataBinding[][] bindingsPerProvider = new DataBinding[][] {
                new DataBinding[] { new SimpleDataBinding(typeof(int), null, 0) },
                new DataBinding[] { },
                new DataBinding[] { new SimpleDataBinding(typeof(int), null, 0) },
            };

            IDataProvider[] providers = new IDataProvider[] {
                Mocks.CreateMock<IDataProvider>(),
                Mocks.CreateMock<IDataProvider>(),
                Mocks.CreateMock<IDataProvider>()
            };

            IDataRow[][] rowsPerProvider = new IDataRow[][] {
                new IDataRow[] {
                    new ScalarDataRow<int>(1, null),
                    new ScalarDataRow<int>(2, null)
                },
                new IDataRow[] {
                    new ScalarDataRow<int>(1, null),
                    new ScalarDataRow<int>(2, null),
                    new ScalarDataRow<int>(3, null)
                },
                new IDataRow[] {
                    new ScalarDataRow<int>(1, null),
                    new ScalarDataRow<int>(2, null)
                }
            };

            using (Mocks.Record())
            {
                Expect.Call(providers[0].GetRows(bindingsPerProvider[0])).Return(rowsPerProvider[0]);
                Expect.Call(providers[1].GetRows(bindingsPerProvider[1])).Return(rowsPerProvider[1]);
                Expect.Call(providers[2].GetRows(bindingsPerProvider[2])).Return(rowsPerProvider[2]);
            }

            using (Mocks.Playback())
            {
                List<IList<IDataRow>> rows = new List<IList<IDataRow>>(CombinatorialJoinStrategy.Instance.Join(providers, bindingsPerProvider));
                Assert.AreEqual(12, rows.Count);

                int index = 0;
                for (int i = 0; i < rowsPerProvider[0].Length; i++)
                {
                    for (int j = 0; j < rowsPerProvider[1].Length; j++)
                    {
                        for (int k = 0; k < rowsPerProvider[2].Length; k++)
                        {
                            Assert.AreSame(rowsPerProvider[0][i], rows[index][0]);
                            Assert.AreSame(rowsPerProvider[1][j], rows[index][1]);
                            Assert.AreSame(rowsPerProvider[2][k], rows[index][2]);

                            index += 1;
                        }
                    }
                }
            }
        }
    }
}