﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:2.0.40607.16
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace TestFu.Tests.Data {
    using System;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("OneTableDataSet")]
    public class OneTableDataSet : System.Data.DataSet {
        
        private UsersDataTable tableUsers;
        
        public OneTableDataSet() {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        protected OneTableDataSet(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Users"] != null)) {
                    base.Tables.Add(new UsersDataTable(ds.Tables["Users"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public UsersDataTable Users {
            get {
                return this.tableUsers;
            }
        }
        
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [System.ComponentModel.DefaultValueAttribute(false)]
        public new bool EnforceConstraints {
            get {
                return base.EnforceConstraints;
            }
            set {
                base.EnforceConstraints = value;
            }
        }
        
        public override System.Data.DataSet Clone() {
            OneTableDataSet cln = ((OneTableDataSet)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
            this.Reset();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["Users"] != null)) {
                base.Tables.Add(new UsersDataTable(ds.Tables["Users"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.InitVars(true);
        }
        
        internal void InitVars(bool initTable) {
            this.tableUsers = ((UsersDataTable)(base.Tables["Users"]));
            if ((initTable == true)) {
                if ((this.tableUsers != null)) {
                    this.tableUsers.InitVars();
                }
            }
        }
        
        private void InitClass() {
            this.DataSetName = "OneTableDataSet";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/OneTable.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = false;
            this.tableUsers = new UsersDataTable();
            base.Tables.Add(this.tableUsers);
            this.ExtendedProperties.Add("DSGenerator_DataSetName", "OneTableDataSet");
            this.ExtendedProperties.Add("User_DataSetName", "OneTableDataSet");
        }
        
        private bool ShouldSerializeUsers() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
            OneTableDataSet ds = new OneTableDataSet();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            if (PublishLegacyWSDL()) {
                System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
                any.Namespace = ds.Namespace;
                sequence.Items.Add(any);
            }
            else {
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(0);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                sequence.MaxOccurs = decimal.MaxValue;
                System.Xml.Schema.XmlSchemaAttribute attribute = new System.Xml.Schema.XmlSchemaAttribute();
                attribute.Name = "namespace";
                attribute.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute);
            }
            type.Particle = sequence;
            return type;
        }
        
        protected static bool PublishLegacyWSDL() {
            System.Collections.Specialized.NameValueCollection settings = ((System.Collections.Specialized.NameValueCollection)(System.Configuration.ConfigurationSettings.GetConfig("system.data.dataset")));
            if ((settings != null)) {
                string[] values = settings.GetValues("WSDL_VERSION");
                if ((values != null)) {
                    float version = float.Parse(((string)(values[0])), ((System.IFormatProvider)(null)));
                    return (version < 2);
                }
            }
            return true;
        }
        
        public delegate void UsersRowChangeEventHandler(object sender, UsersRowChangeEvent e);
        
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public class UsersDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnUserID;
            
            private System.Data.DataColumn columnUserName;
            
            private System.Data.DataColumn columnUserLastName;
            
            private System.Data.DataColumn columnUserAddress;
            
            private bool m_suspendValidation = false;
            
            public UsersDataTable() {
                this.TableName = "Users";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            internal UsersDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            protected UsersDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            internal System.Data.DataColumn UserIDColumn {
                get {
                    return this.columnUserID;
                }
            }
            
            internal System.Data.DataColumn UserNameColumn {
                get {
                    return this.columnUserName;
                }
            }
            
            internal System.Data.DataColumn UserLastNameColumn {
                get {
                    return this.columnUserLastName;
                }
            }
            
            internal System.Data.DataColumn UserAddressColumn {
                get {
                    return this.columnUserAddress;
                }
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            public UsersRow this[int index] {
                get {
                    return ((UsersRow)(this.Rows[index]));
                }
            }
            
            public bool SuspendValidation {
                get {
                    return this.m_suspendValidation;
                }
                set {
                    this.m_suspendValidation = value;
                }
            }
            
            public event UserIDChangeEventHandler UserIDChanging;
            
            public event UserIDChangeEventHandler UserIDChanged;
            
            public event UserNameChangeEventHandler UserNameChanging;
            
            public event UserNameChangeEventHandler UserNameChanged;
            
            public event UserLastNameChangeEventHandler UserLastNameChanging;
            
            public event UserLastNameChangeEventHandler UserLastNameChanged;
            
            public event UserAddressChangeEventHandler UserAddressChanging;
            
            public event UserAddressChangeEventHandler UserAddressChanged;
            
            public event UsersRowChangeEventHandler UsersRowChanged;
            
            public event UsersRowChangeEventHandler UsersRowChanging;
            
            public event UsersRowChangeEventHandler UsersRowDeleted;
            
            public event UsersRowChangeEventHandler UsersRowDeleting;
            
            protected override void OnColumnChanging(System.Data.DataColumnChangeEventArgs e) {
                base.OnColumnChanging(e);
                if ((this.SuspendValidation == true)) {
                    return;
                }
                if ((e.Column.ColumnName == "UserID")) {
                    if ((this.UserIDChanging != null)) {
                        this.UserIDChanging(this, new UserIDChangeEventArg(e));
                    }
                }
                else {
                    if ((e.Column.ColumnName == "UserName")) {
                        if ((this.UserNameChanging != null)) {
                            this.UserNameChanging(this, new UserNameChangeEventArg(e));
                        }
                    }
                    else {
                        if ((e.Column.ColumnName == "UserLastName")) {
                            if ((this.UserLastNameChanging != null)) {
                                this.UserLastNameChanging(this, new UserLastNameChangeEventArg(e));
                            }
                        }
                        else {
                            if ((e.Column.ColumnName == "UserAddress")) {
                                if ((this.UserAddressChanging != null)) {
                                    this.UserAddressChanging(this, new UserAddressChangeEventArg(e));
                                }
                            }
                        }
                    }
                }
            }
            
            protected override void OnColumnChanged(System.Data.DataColumnChangeEventArgs e) {
                base.OnColumnChanged(e);
                if ((this.SuspendValidation == true)) {
                    return;
                }
                if ((e.Column.ColumnName == "UserID")) {
                    if ((this.UserIDChanged != null)) {
                        this.UserIDChanged(this, new UserIDChangeEventArg(e));
                    }
                }
                else {
                    if ((e.Column.ColumnName == "UserName")) {
                        if ((this.UserNameChanged != null)) {
                            this.UserNameChanged(this, new UserNameChangeEventArg(e));
                        }
                    }
                    else {
                        if ((e.Column.ColumnName == "UserLastName")) {
                            if ((this.UserLastNameChanged != null)) {
                                this.UserLastNameChanged(this, new UserLastNameChangeEventArg(e));
                            }
                        }
                        else {
                            if ((e.Column.ColumnName == "UserAddress")) {
                                if ((this.UserAddressChanged != null)) {
                                    this.UserAddressChanged(this, new UserAddressChangeEventArg(e));
                                }
                            }
                        }
                    }
                }
            }
            
            public void AddUsersRow(UsersRow row) {
                this.Rows.Add(row);
            }
            
            public UsersRow AddUsersRow(int UserID, string UserName, string UserLastName, string UserAddress) {
                UsersRow rowUsersRow = ((UsersRow)(this.NewRow()));
                rowUsersRow.ItemArray = new object[] {
                        UserID,
                        UserName,
                        UserLastName,
                        UserAddress};
                this.Rows.Add(rowUsersRow);
                return rowUsersRow;
            }
            
            public UsersRow FindByUserID(int UserID) {
                return ((UsersRow)(this.Rows.Find(new object[] {
                            UserID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override System.Data.DataTable Clone() {
                UsersDataTable cln = ((UsersDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override System.Data.DataTable CreateInstance() {
                return new UsersDataTable();
            }
            
            internal void InitVars() {
                this.columnUserID = base.Columns["UserID"];
                this.columnUserName = base.Columns["UserName"];
                this.columnUserLastName = base.Columns["UserLastName"];
                this.columnUserAddress = base.Columns["UserAddress"];
            }
            
            private void InitClass() {
                this.columnUserID = new System.Data.DataColumn("UserID", typeof(int), null, System.Data.MappingType.Element);
                this.columnUserID.ExtendedProperties.Add("Generator_ChangedEventName", "UserIDChanged");
                this.columnUserID.ExtendedProperties.Add("Generator_ChangingEventName", "UserIDChanging");
                this.columnUserID.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "UserID");
                this.columnUserID.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "UserIDColumn");
                this.columnUserID.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnUserID");
                this.columnUserID.ExtendedProperties.Add("Generator_DelegateName", "UserIDChangeEventHandler");
                this.columnUserID.ExtendedProperties.Add("Generator_EventArgName", "UserIDChangeEventArg");
                this.columnUserID.ExtendedProperties.Add("User_ColumnName", "UserID");
                base.Columns.Add(this.columnUserID);
                this.columnUserName = new System.Data.DataColumn("UserName", typeof(string), null, System.Data.MappingType.Element);
                this.columnUserName.ExtendedProperties.Add("Generator_ChangedEventName", "UserNameChanged");
                this.columnUserName.ExtendedProperties.Add("Generator_ChangingEventName", "UserNameChanging");
                this.columnUserName.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "UserName");
                this.columnUserName.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "UserNameColumn");
                this.columnUserName.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnUserName");
                this.columnUserName.ExtendedProperties.Add("Generator_DelegateName", "UserNameChangeEventHandler");
                this.columnUserName.ExtendedProperties.Add("Generator_EventArgName", "UserNameChangeEventArg");
                this.columnUserName.ExtendedProperties.Add("User_ColumnName", "UserName");
                base.Columns.Add(this.columnUserName);
                this.columnUserLastName = new System.Data.DataColumn("UserLastName", typeof(string), null, System.Data.MappingType.Element);
                this.columnUserLastName.ExtendedProperties.Add("Generator_ChangedEventName", "UserLastNameChanged");
                this.columnUserLastName.ExtendedProperties.Add("Generator_ChangingEventName", "UserLastNameChanging");
                this.columnUserLastName.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "UserLastName");
                this.columnUserLastName.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "UserLastNameColumn");
                this.columnUserLastName.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnUserLastName");
                this.columnUserLastName.ExtendedProperties.Add("Generator_DelegateName", "UserLastNameChangeEventHandler");
                this.columnUserLastName.ExtendedProperties.Add("Generator_EventArgName", "UserLastNameChangeEventArg");
                this.columnUserLastName.ExtendedProperties.Add("User_ColumnName", "UserLastName");
                base.Columns.Add(this.columnUserLastName);
                this.columnUserAddress = new System.Data.DataColumn("UserAddress", typeof(string), null, System.Data.MappingType.Element);
                this.columnUserAddress.ExtendedProperties.Add("Generator_ChangedEventName", "UserAddressChanged");
                this.columnUserAddress.ExtendedProperties.Add("Generator_ChangingEventName", "UserAddressChanging");
                this.columnUserAddress.ExtendedProperties.Add("Generator_ColumnPropNameInRow", "UserAddress");
                this.columnUserAddress.ExtendedProperties.Add("Generator_ColumnPropNameInTable", "UserAddressColumn");
                this.columnUserAddress.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "columnUserAddress");
                this.columnUserAddress.ExtendedProperties.Add("Generator_DelegateName", "UserAddressChangeEventHandler");
                this.columnUserAddress.ExtendedProperties.Add("Generator_EventArgName", "UserAddressChangeEventArg");
                this.columnUserAddress.ExtendedProperties.Add("User_ColumnName", "UserAddress");
                base.Columns.Add(this.columnUserAddress);
                this.Constraints.Add(new System.Data.UniqueConstraint("Constraint1", new System.Data.DataColumn[] {
                                this.columnUserID}, true));
                this.columnUserID.AllowDBNull = false;
                this.columnUserID.Unique = true;
                this.columnUserName.AllowDBNull = false;
                this.columnUserLastName.AllowDBNull = false;
                this.ExtendedProperties.Add("Generator_RowClassName", "UsersRow");
                this.ExtendedProperties.Add("Generator_RowEvArgName", "UsersRowChangeEvent");
                this.ExtendedProperties.Add("Generator_RowEvHandlerName", "UsersRowChangeEventHandler");
                this.ExtendedProperties.Add("Generator_SuspendValidationPropName", "SuspendValidation");
                this.ExtendedProperties.Add("Generator_SuspendValidationVarName", "m_suspendValidation");
                this.ExtendedProperties.Add("Generator_TableClassName", "UsersDataTable");
                this.ExtendedProperties.Add("Generator_TablePropName", "Users");
                this.ExtendedProperties.Add("Generator_TableVarName", "tableUsers");
                this.ExtendedProperties.Add("User_TableName", "Users");
            }
            
            public UsersRow NewUsersRow() {
                return ((UsersRow)(this.NewRow()));
            }
            
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new UsersRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(UsersRow);
            }
            
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.UsersRowChanged != null)) {
                    this.UsersRowChanged(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.UsersRowChanging != null)) {
                    this.UsersRowChanging(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.UsersRowDeleted != null)) {
                    this.UsersRowDeleted(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.UsersRowDeleting != null)) {
                    this.UsersRowDeleting(this, new UsersRowChangeEvent(((UsersRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveUsersRow(UsersRow row) {
                this.Rows.Remove(row);
            }
            
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                OneTableDataSet ds = new OneTableDataSet();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "UsersDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
            
            public delegate void UserIDChangeEventHandler(UsersDataTable sender, UserIDChangeEventArg e);
            
            public class UserIDChangeEventArg : System.EventArgs {
                
                private System.Data.DataColumnChangeEventArgs evArgs;
                
                public UserIDChangeEventArg(System.Data.DataColumnChangeEventArgs args) {
                    this.evArgs = args;
                }
                
                public UsersRow Row {
                    get {
                        return ((UsersRow)(this.evArgs.Row));
                    }
                }
                
                public System.Data.DataColumn UserIDColumn {
                    get {
                        return this.evArgs.Column;
                    }
                }
                
                public int ProposedValue {
                    get {
                        return ((int)(this.evArgs.ProposedValue));
                    }
                    set {
                        this.evArgs.ProposedValue = ((int)(value));
                    }
                }
            }
            
            public delegate void UserNameChangeEventHandler(UsersDataTable sender, UserNameChangeEventArg e);
            
            public class UserNameChangeEventArg : System.EventArgs {
                
                private System.Data.DataColumnChangeEventArgs evArgs;
                
                public UserNameChangeEventArg(System.Data.DataColumnChangeEventArgs args) {
                    this.evArgs = args;
                }
                
                public UsersRow Row {
                    get {
                        return ((UsersRow)(this.evArgs.Row));
                    }
                }
                
                public System.Data.DataColumn UserNameColumn {
                    get {
                        return this.evArgs.Column;
                    }
                }
                
                public string ProposedValue {
                    get {
                        return ((string)(this.evArgs.ProposedValue));
                    }
                    set {
                        this.evArgs.ProposedValue = ((string)(value));
                    }
                }
            }
            
            public delegate void UserLastNameChangeEventHandler(UsersDataTable sender, UserLastNameChangeEventArg e);
            
            public class UserLastNameChangeEventArg : System.EventArgs {
                
                private System.Data.DataColumnChangeEventArgs evArgs;
                
                public UserLastNameChangeEventArg(System.Data.DataColumnChangeEventArgs args) {
                    this.evArgs = args;
                }
                
                public UsersRow Row {
                    get {
                        return ((UsersRow)(this.evArgs.Row));
                    }
                }
                
                public System.Data.DataColumn UserLastNameColumn {
                    get {
                        return this.evArgs.Column;
                    }
                }
                
                public string ProposedValue {
                    get {
                        return ((string)(this.evArgs.ProposedValue));
                    }
                    set {
                        this.evArgs.ProposedValue = ((string)(value));
                    }
                }
            }
            
            public delegate void UserAddressChangeEventHandler(UsersDataTable sender, UserAddressChangeEventArg e);
            
            public class UserAddressChangeEventArg : System.EventArgs {
                
                private System.Data.DataColumnChangeEventArgs evArgs;
                
                public UserAddressChangeEventArg(System.Data.DataColumnChangeEventArgs args) {
                    this.evArgs = args;
                }
                
                public UsersRow Row {
                    get {
                        return ((UsersRow)(this.evArgs.Row));
                    }
                }
                
                public System.Data.DataColumn UserAddressColumn {
                    get {
                        return this.evArgs.Column;
                    }
                }
                
                public string ProposedValue {
                    get {
                        return ((string)(this.evArgs.ProposedValue));
                    }
                    set {
                        this.evArgs.ProposedValue = ((string)(value));
                    }
                }
            }
        }
        
        public class UsersRow : System.Data.DataRow {
            
            private UsersDataTable tableUsers;
            
            internal UsersRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableUsers = ((UsersDataTable)(this.Table));
            }
            
            public int UserID {
                get {
                    return ((int)(this[this.tableUsers.UserIDColumn]));
                }
                set {
                    this[this.tableUsers.UserIDColumn] = value;
                }
            }
            
            public string UserName {
                get {
                    return ((string)(this[this.tableUsers.UserNameColumn]));
                }
                set {
                    this[this.tableUsers.UserNameColumn] = value;
                }
            }
            
            public string UserLastName {
                get {
                    return ((string)(this[this.tableUsers.UserLastNameColumn]));
                }
                set {
                    this[this.tableUsers.UserLastNameColumn] = value;
                }
            }
            
            public string UserAddress {
                get {
                    try {
                        return ((string)(this[this.tableUsers.UserAddressColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("StrongTyping_CannotAccessDBNull", e);
                    }
                }
                set {
                    this[this.tableUsers.UserAddressColumn] = value;
                }
            }
            
            public bool IsUserAddressNull() {
                return this.IsNull(this.tableUsers.UserAddressColumn);
            }
            
            public void SetUserAddressNull() {
                this[this.tableUsers.UserAddressColumn] = System.Convert.DBNull;
            }
        }
        
        public class UsersRowChangeEvent : System.EventArgs {
            
            private UsersRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            public UsersRowChangeEvent(UsersRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public UsersRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
