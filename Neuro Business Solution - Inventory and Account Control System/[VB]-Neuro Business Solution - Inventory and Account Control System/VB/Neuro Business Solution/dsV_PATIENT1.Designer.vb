﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System


<System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
 Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.ComponentModel.ToolboxItem(true),  _
 System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"),  _
 System.Xml.Serialization.XmlRootAttribute("dsV_PATIENT1"),  _
 System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class dsV_PATIENT1
    Inherits System.Data.DataSet
    
    Private tableV_PATIENT_INFO As V_PATIENT_INFODataTable
    
    Private _schemaSerializationMode As System.Data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub New()
        MyBase.New
        Me.BeginInit
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler MyBase.Relations.CollectionChanged, schemaChangedHandler
        Me.EndInit
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context, false)
        If (Me.IsBinarySerialized(info, context) = true) Then
            Me.InitVars(false)
            Dim schemaChangedHandler1 As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
            AddHandler Me.Tables.CollectionChanged, schemaChangedHandler1
            AddHandler Me.Relations.CollectionChanged, schemaChangedHandler1
            Return
        End If
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(String)),String)
        If (Me.DetermineSchemaSerializationMode(info, context) = System.Data.SchemaSerializationMode.IncludeSchema) Then
            Dim ds As System.Data.DataSet = New System.Data.DataSet
            ds.ReadXmlSchema(New System.Xml.XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("V_PATIENT_INFO")) Is Nothing) Then
                MyBase.Tables.Add(New V_PATIENT_INFODataTable(ds.Tables("V_PATIENT_INFO")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXmlSchema(New System.Xml.XmlTextReader(New System.IO.StringReader(strSchema)))
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property V_PATIENT_INFO() As V_PATIENT_INFODataTable
        Get
            Return Me.tableV_PATIENT_INFO
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.BrowsableAttribute(true),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)>  _
    Public Overrides Property SchemaSerializationMode() As System.Data.SchemaSerializationMode
        Get
            Return Me._schemaSerializationMode
        End Get
        Set
            Me._schemaSerializationMode = value
        End Set
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Tables() As System.Data.DataTableCollection
        Get
            Return MyBase.Tables
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Relations() As System.Data.DataRelationCollection
        Get
            Return MyBase.Relations
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub InitializeDerivedDataSet()
        Me.BeginInit
        Me.InitClass
        Me.EndInit
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Overrides Function Clone() As System.Data.DataSet
        Dim cln As dsV_PATIENT1 = CType(MyBase.Clone,dsV_PATIENT1)
        cln.InitVars
        cln.SchemaSerializationMode = Me.SchemaSerializationMode
        Return cln
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As System.Xml.XmlReader)
        If (Me.DetermineSchemaSerializationMode(reader) = System.Data.SchemaSerializationMode.IncludeSchema) Then
            Me.Reset
            Dim ds As System.Data.DataSet = New System.Data.DataSet
            ds.ReadXml(reader)
            If (Not (ds.Tables("V_PATIENT_INFO")) Is Nothing) Then
                MyBase.Tables.Add(New V_PATIENT_INFODataTable(ds.Tables("V_PATIENT_INFO")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXml(reader)
            Me.InitVars
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New System.Xml.XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New System.Xml.XmlTextReader(stream), Nothing)
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars()
        Me.InitVars(true)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars(ByVal initTable As Boolean)
        Me.tableV_PATIENT_INFO = CType(MyBase.Tables("V_PATIENT_INFO"),V_PATIENT_INFODataTable)
        If (initTable = true) Then
            If (Not (Me.tableV_PATIENT_INFO) Is Nothing) Then
                Me.tableV_PATIENT_INFO.InitVars
            End If
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "dsV_PATIENT1"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/dsV_PATIENT1.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableV_PATIENT_INFO = New V_PATIENT_INFODataTable
        MyBase.Tables.Add(Me.tableV_PATIENT_INFO)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeV_PATIENT_INFO() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Shared Function GetTypedDataSetSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
        Dim ds As dsV_PATIENT1 = New dsV_PATIENT1
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub V_PATIENT_INFORowChangeEventHandler(ByVal sender As Object, ByVal e As V_PATIENT_INFORowChangeEvent)
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class V_PATIENT_INFODataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnID As System.Data.DataColumn
        
        Private columnNAME As System.Data.DataColumn
        
        Private columnFNAME As System.Data.DataColumn
        
        Private columnNIC As System.Data.DataColumn
        
        Private columnPER_ADD As System.Data.DataColumn
        
        Private columnPHONE As System.Data.DataColumn
        
        Private columnCELL As System.Data.DataColumn
        
        Private columnEMAIL As System.Data.DataColumn
        
        Private columnDISEASE As System.Data.DataColumn
        
        Private columnDISEASE_DESC As System.Data.DataColumn
        
        Private columnPANEL As System.Data.DataColumn
        
        Private columnENROL_DATE As System.Data.DataColumn
        
        Private columnSTATUS As System.Data.DataColumn
        
        Private columnDISCH_DATE As System.Data.DataColumn
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "V_PATIENT_INFO"
            Me.BeginInit
            Me.InitClass
            Me.EndInit
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal table As System.Data.DataTable)
            MyBase.New
            Me.TableName = table.TableName
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            Me.InitVars
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property IDColumn() As System.Data.DataColumn
            Get
                Return Me.columnID
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnNAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property FNAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnFNAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property NICColumn() As System.Data.DataColumn
            Get
                Return Me.columnNIC
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property PER_ADDColumn() As System.Data.DataColumn
            Get
                Return Me.columnPER_ADD
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property PHONEColumn() As System.Data.DataColumn
            Get
                Return Me.columnPHONE
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property CELLColumn() As System.Data.DataColumn
            Get
                Return Me.columnCELL
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property EMAILColumn() As System.Data.DataColumn
            Get
                Return Me.columnEMAIL
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property DISEASEColumn() As System.Data.DataColumn
            Get
                Return Me.columnDISEASE
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property DISEASE_DESCColumn() As System.Data.DataColumn
            Get
                Return Me.columnDISEASE_DESC
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property PANELColumn() As System.Data.DataColumn
            Get
                Return Me.columnPANEL
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property ENROL_DATEColumn() As System.Data.DataColumn
            Get
                Return Me.columnENROL_DATE
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property STATUSColumn() As System.Data.DataColumn
            Get
                Return Me.columnSTATUS
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property DISCH_DATEColumn() As System.Data.DataColumn
            Get
                Return Me.columnDISCH_DATE
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Default ReadOnly Property Item(ByVal index As Integer) As V_PATIENT_INFORow
            Get
                Return CType(Me.Rows(index),V_PATIENT_INFORow)
            End Get
        End Property
        
        Public Event V_PATIENT_INFORowChanging As V_PATIENT_INFORowChangeEventHandler
        
        Public Event V_PATIENT_INFORowChanged As V_PATIENT_INFORowChangeEventHandler
        
        Public Event V_PATIENT_INFORowDeleting As V_PATIENT_INFORowChangeEventHandler
        
        Public Event V_PATIENT_INFORowDeleted As V_PATIENT_INFORowChangeEventHandler
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddV_PATIENT_INFORow(ByVal row As V_PATIENT_INFORow)
            Me.Rows.Add(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddV_PATIENT_INFORow(ByVal NAME As String, ByVal FNAME As String, ByVal NIC As String, ByVal PER_ADD As String, ByVal PHONE As String, ByVal CELL As String, ByVal EMAIL As String, ByVal DISEASE As String, ByVal DISEASE_DESC As String, ByVal PANEL As String, ByVal ENROL_DATE As Date, ByVal STATUS As Boolean, ByVal DISCH_DATE As Date) As V_PATIENT_INFORow
            Dim rowV_PATIENT_INFORow As V_PATIENT_INFORow = CType(Me.NewRow,V_PATIENT_INFORow)
            rowV_PATIENT_INFORow.ItemArray = New Object() {Nothing, NAME, FNAME, NIC, PER_ADD, PHONE, CELL, EMAIL, DISEASE, DISEASE_DESC, PANEL, ENROL_DATE, STATUS, DISCH_DATE}
            Me.Rows.Add(rowV_PATIENT_INFORow)
            Return rowV_PATIENT_INFORow
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function FindByID(ByVal ID As Decimal) As V_PATIENT_INFORow
            Return CType(Me.Rows.Find(New Object() {ID}),V_PATIENT_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As V_PATIENT_INFODataTable = CType(MyBase.Clone,V_PATIENT_INFODataTable)
            cln.InitVars
            Return cln
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New V_PATIENT_INFODataTable
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnID = MyBase.Columns("ID")
            Me.columnNAME = MyBase.Columns("NAME")
            Me.columnFNAME = MyBase.Columns("FNAME")
            Me.columnNIC = MyBase.Columns("NIC")
            Me.columnPER_ADD = MyBase.Columns("PER_ADD")
            Me.columnPHONE = MyBase.Columns("PHONE")
            Me.columnCELL = MyBase.Columns("CELL")
            Me.columnEMAIL = MyBase.Columns("EMAIL")
            Me.columnDISEASE = MyBase.Columns("DISEASE")
            Me.columnDISEASE_DESC = MyBase.Columns("DISEASE_DESC")
            Me.columnPANEL = MyBase.Columns("PANEL")
            Me.columnENROL_DATE = MyBase.Columns("ENROL_DATE")
            Me.columnSTATUS = MyBase.Columns("STATUS")
            Me.columnDISCH_DATE = MyBase.Columns("DISCH_DATE")
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnID = New System.Data.DataColumn("ID", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnID)
            Me.columnNAME = New System.Data.DataColumn("NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnNAME)
            Me.columnFNAME = New System.Data.DataColumn("FNAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnFNAME)
            Me.columnNIC = New System.Data.DataColumn("NIC", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnNIC)
            Me.columnPER_ADD = New System.Data.DataColumn("PER_ADD", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnPER_ADD)
            Me.columnPHONE = New System.Data.DataColumn("PHONE", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnPHONE)
            Me.columnCELL = New System.Data.DataColumn("CELL", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnCELL)
            Me.columnEMAIL = New System.Data.DataColumn("EMAIL", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnEMAIL)
            Me.columnDISEASE = New System.Data.DataColumn("DISEASE", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnDISEASE)
            Me.columnDISEASE_DESC = New System.Data.DataColumn("DISEASE_DESC", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnDISEASE_DESC)
            Me.columnPANEL = New System.Data.DataColumn("PANEL", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnPANEL)
            Me.columnENROL_DATE = New System.Data.DataColumn("ENROL_DATE", GetType(Date), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnENROL_DATE)
            Me.columnSTATUS = New System.Data.DataColumn("STATUS", GetType(Boolean), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnSTATUS)
            Me.columnDISCH_DATE = New System.Data.DataColumn("DISCH_DATE", GetType(Date), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnDISCH_DATE)
            Me.Constraints.Add(New System.Data.UniqueConstraint("Constraint1", New System.Data.DataColumn() {Me.columnID}, true))
            Me.columnID.AutoIncrement = true
            Me.columnID.AllowDBNull = false
            Me.columnID.ReadOnly = true
            Me.columnID.Unique = true
            Me.columnNAME.AllowDBNull = false
            Me.columnNAME.MaxLength = 50
            Me.columnFNAME.AllowDBNull = false
            Me.columnFNAME.MaxLength = 50
            Me.columnNIC.AllowDBNull = false
            Me.columnNIC.MaxLength = 50
            Me.columnPER_ADD.MaxLength = 200
            Me.columnPHONE.MaxLength = 50
            Me.columnCELL.MaxLength = 50
            Me.columnEMAIL.MaxLength = 50
            Me.columnDISEASE.AllowDBNull = false
            Me.columnDISEASE.MaxLength = 50
            Me.columnDISEASE_DESC.MaxLength = 100
            Me.columnPANEL.AllowDBNull = false
            Me.columnPANEL.MaxLength = 50
            Me.columnENROL_DATE.AllowDBNull = false
            Me.columnSTATUS.AllowDBNull = false
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewV_PATIENT_INFORow() As V_PATIENT_INFORow
            Return CType(Me.NewRow,V_PATIENT_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New V_PATIENT_INFORow(builder)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(V_PATIENT_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.V_PATIENT_INFORowChangedEvent) Is Nothing) Then
                RaiseEvent V_PATIENT_INFORowChanged(Me, New V_PATIENT_INFORowChangeEvent(CType(e.Row,V_PATIENT_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.V_PATIENT_INFORowChangingEvent) Is Nothing) Then
                RaiseEvent V_PATIENT_INFORowChanging(Me, New V_PATIENT_INFORowChangeEvent(CType(e.Row,V_PATIENT_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.V_PATIENT_INFORowDeletedEvent) Is Nothing) Then
                RaiseEvent V_PATIENT_INFORowDeleted(Me, New V_PATIENT_INFORowChangeEvent(CType(e.Row,V_PATIENT_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.V_PATIENT_INFORowDeletingEvent) Is Nothing) Then
                RaiseEvent V_PATIENT_INFORowDeleting(Me, New V_PATIENT_INFORowChangeEvent(CType(e.Row,V_PATIENT_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveV_PATIENT_INFORow(ByVal row As V_PATIENT_INFORow)
            Me.Rows.Remove(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As dsV_PATIENT1 = New dsV_PATIENT1
            xs.Add(ds.GetSchemaSerializable)
            Dim any1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any1.Namespace = "http://www.w3.org/2001/XMLSchema"
            any1.MinOccurs = New Decimal(0)
            any1.MaxOccurs = Decimal.MaxValue
            any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any1)
            Dim any2 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
            any2.MinOccurs = New Decimal(1)
            any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any2)
            Dim attribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute1.Name = "namespace"
            attribute1.FixedValue = ds.Namespace
            type.Attributes.Add(attribute1)
            Dim attribute2 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute2.Name = "tableTypeName"
            attribute2.FixedValue = "V_PATIENT_INFODataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class V_PATIENT_INFORow
        Inherits System.Data.DataRow
        
        Private tableV_PATIENT_INFO As V_PATIENT_INFODataTable
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableV_PATIENT_INFO = CType(Me.Table,V_PATIENT_INFODataTable)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property ID() As Decimal
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.IDColumn),Decimal)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.IDColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property NAME() As String
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.NAMEColumn),String)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property FNAME() As String
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.FNAMEColumn),String)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.FNAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property NIC() As String
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.NICColumn),String)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.NICColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property PER_ADD() As String
            Get
                Try 
                    Return CType(Me(Me.tableV_PATIENT_INFO.PER_ADDColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'PER_ADD' in table 'V_PATIENT_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.PER_ADDColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property PHONE() As String
            Get
                Try 
                    Return CType(Me(Me.tableV_PATIENT_INFO.PHONEColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'PHONE' in table 'V_PATIENT_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.PHONEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property CELL() As String
            Get
                Try 
                    Return CType(Me(Me.tableV_PATIENT_INFO.CELLColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'CELL' in table 'V_PATIENT_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.CELLColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property EMAIL() As String
            Get
                Try 
                    Return CType(Me(Me.tableV_PATIENT_INFO.EMAILColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'EMAIL' in table 'V_PATIENT_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.EMAILColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property DISEASE() As String
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.DISEASEColumn),String)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.DISEASEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property DISEASE_DESC() As String
            Get
                Try 
                    Return CType(Me(Me.tableV_PATIENT_INFO.DISEASE_DESCColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'DISEASE_DESC' in table 'V_PATIENT_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.DISEASE_DESCColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property PANEL() As String
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.PANELColumn),String)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.PANELColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property ENROL_DATE() As Date
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.ENROL_DATEColumn),Date)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.ENROL_DATEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property STATUS() As Boolean
            Get
                Return CType(Me(Me.tableV_PATIENT_INFO.STATUSColumn),Boolean)
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.STATUSColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property DISCH_DATE() As Date
            Get
                Try 
                    Return CType(Me(Me.tableV_PATIENT_INFO.DISCH_DATEColumn),Date)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'DISCH_DATE' in table 'V_PATIENT_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_PATIENT_INFO.DISCH_DATEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsPER_ADDNull() As Boolean
            Return Me.IsNull(Me.tableV_PATIENT_INFO.PER_ADDColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetPER_ADDNull()
            Me(Me.tableV_PATIENT_INFO.PER_ADDColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsPHONENull() As Boolean
            Return Me.IsNull(Me.tableV_PATIENT_INFO.PHONEColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetPHONENull()
            Me(Me.tableV_PATIENT_INFO.PHONEColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsCELLNull() As Boolean
            Return Me.IsNull(Me.tableV_PATIENT_INFO.CELLColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetCELLNull()
            Me(Me.tableV_PATIENT_INFO.CELLColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsEMAILNull() As Boolean
            Return Me.IsNull(Me.tableV_PATIENT_INFO.EMAILColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetEMAILNull()
            Me(Me.tableV_PATIENT_INFO.EMAILColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsDISEASE_DESCNull() As Boolean
            Return Me.IsNull(Me.tableV_PATIENT_INFO.DISEASE_DESCColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetDISEASE_DESCNull()
            Me(Me.tableV_PATIENT_INFO.DISEASE_DESCColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsDISCH_DATENull() As Boolean
            Return Me.IsNull(Me.tableV_PATIENT_INFO.DISCH_DATEColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetDISCH_DATENull()
            Me(Me.tableV_PATIENT_INFO.DISCH_DATEColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class V_PATIENT_INFORowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As V_PATIENT_INFORow
        
        Private eventAction As System.Data.DataRowAction
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As V_PATIENT_INFORow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As V_PATIENT_INFORow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Action() As System.Data.DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
