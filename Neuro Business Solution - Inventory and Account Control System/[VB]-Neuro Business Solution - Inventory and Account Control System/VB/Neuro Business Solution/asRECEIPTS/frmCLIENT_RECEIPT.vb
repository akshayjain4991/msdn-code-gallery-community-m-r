Imports SDS = System.Data.SqlClient
Public Class frmCLIENT_RECEIPT

#Region "VARIABLES"
    Dim asConn As New AssConn
    Dim asInsert As New AssInsert
    Dim asUpdate As New AssUpdate
    Dim asDelete As New AssDelete
    Dim asSELECT As New AssSelect
    Dim asTXT As New AssTextBox
    Dim asNum As New AssNumPress
    Dim asMAX As New AssMaxNo
    Dim Rd As System.Data.SqlClient.SqlDataReader

#End Region

#Region "FORM CONTROL"
    Private Sub frmCLIENT_RECEIPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SqlConnection1.ConnectionString = Me.asConn.Conn.ConnectionString
        Me.FillComboBox_Employee()
        Me.FillComboBox_Group()
        Me.FillComboBox_Client()
        Me.FillComboBox_BankAccount()
        Me.TxtDate.Text = Date.Now.ToString("dd-MMM-yyyy")

        Me.daNS_DEFAULT.Fill(Me.DsNS_DEFAULT1.NS_DEFAULT)

        Me.Default_Setting()
    End Sub

    Private Sub frmCLIENT_RECEIPT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Me.asNum.EnterTab(e)
    End Sub
#End Region

#Region "TextBox Control"
    'Got and LostFocus
    Private Sub Txt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBankPmt.GotFocus, TxtCashPmt.GotFocus, TxtChequeDate.GotFocus, TxtChequeNo.GotFocus, TxtChequeType.GotFocus, TxtDate.GotFocus, TxtDescription.GotFocus
        CType(sender, TextBox).BackColor = Color.LightSteelBlue
        CType(sender, TextBox).SelectAll()
    End Sub
    Private Sub Txt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBankPmt.LostFocus, TxtCashPmt.LostFocus, TxtChequeDate.LostFocus, TxtChequeNo.LostFocus, TxtChequeType.LostFocus, TxtDate.LostFocus, TxtDescription.LostFocus
        CType(sender, TextBox).BackColor = Color.White
        Dim Ctrl As Control = sender
        Try
            Select Case Ctrl.Name
                Case "TxtDate"
                    If sender.TextLength > 0 Then
                        sender.Text = CDate(sender.text).ToString("dd-MMM-yyyy")
                    End If

                Case "TxtChequeDate"
                    If sender.TextLength > 0 Then
                        sender.Text = CDate(sender.text).ToString("dd-MMM-yyyy")
                    End If

            End Select
        Catch ex As Exception
            sender.Text = Nothing
            sender.Focus()
        End Try
    End Sub
    Private Sub TxtBankPmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBankPmt.Leave, TxtCashPmt.Leave
        If sender.Text = Nothing Or Val(sender.Text) = 0 Then
            sender.Text = "0.00"
        End If
    End Sub

    'KeyPress Numeric With DOT
    Private Sub Txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBankPmt.KeyPress, TxtCashPmt.KeyPress
        Me.asNum.NumPressDot(e)
    End Sub
#End Region

#Region "Lable Control"
    Private Sub LblID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblID.TextChanged
        If Me.LblID.Text.Length > 0 Then
            Me.BttnDelete.Enabled = True
            Dim Str1 As String = "SELECT ID, CLIENT_ID, CLIENT_NAME, SHOP_NAME, R_DATE, CONVERT(NUMERIC(18,2),CASH_AMT) AS CASH_AMT, CHEQ_NO, CHEQ_TYPE, CHEQ_DATE, CONVERT(NUMERIC(18,2), BANK_AMT) AS BANK_AMT, SINV_NO, CASE CHEQ_STATUS WHEN '1' THEN 'STAND BY' WHEN '2' THEN 'DEPOSITED' WHEN '3' THEN 'CLEARED' WHEN '4' THEN 'BOUNCED' WHEN '5' THEN 'CANCELLED' END AS CHEQ_STATUS, STATUS_DATE, STATUS_DESC, BANK_ACC, BANK_NAME, EMP_NAME, USER_NAME, GROUP_NAME, DESCRIPTION, TOT_RECEIPT, GROUP_ID FROM V_CLIENT_RECEIPT WHERE ID=" & Val(Me.LblID.Text) & " ORDER BY ID DESC"

            Dim SqlCmd1 As New SDS.SqlCommand(Str1, Me.SqlConnection1)
            Me.daCLIENT_RECEIPT = New SDS.SqlDataAdapter(SqlCmd1)

            Me.DsCLIENT_RECEIPT1.Clear()
            Me.daCLIENT_RECEIPT.Fill(Me.DsCLIENT_RECEIPT1.V_CLIENT_RECEIPT)
            Dim StrCmb As String

            On Error GoTo Fix

            StrCmb = Me.CmbEmployee.Text
            Me.CmbEmployee.SelectedIndex = -1
            Me.CmbEmployee.SelectedIndex = Me.CmbEmployee.FindString(StrCmb)

            StrCmb = Me.CmbGroup.Text
            Me.CmbGroup.SelectedIndex = -1
            Me.CmbGroup.SelectedIndex = Me.CmbGroup.FindString(StrCmb)

            StrCmb = Me.CmbClient.Text
            Me.CmbClient.SelectedIndex = -1
            Me.CmbClient.SelectedIndex = Me.CmbClient.FindString(StrCmb)

            StrCmb = Me.CmbBankAccount.Text
            Me.CmbBankAccount.SelectedIndex = -1
            Me.CmbBankAccount.SelectedIndex = Me.CmbBankAccount.FindString(StrCmb)
Fix:
        Else
            Me.BttnDelete.Enabled = False
            Me.DsCLIENT_RECEIPT1.Clear()
        End If
    End Sub
#End Region

#Region "ComboBox Controls"
    'Got and LostFocus
    Private Sub Cmb_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEmployee.GotFocus, CmbGroup.GotFocus, CmbBankAccount.GotFocus
        CType(sender, ComboBox).BackColor = Color.LightSteelBlue
        CType(sender, ComboBox).SelectAll()
    End Sub
    Private Sub Cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEmployee.LostFocus, CmbGroup.LostFocus, CmbBankAccount.LostFocus
        CType(sender, ComboBox).BackColor = Color.White
    End Sub
#End Region

#Region "Button Control"
    Private Sub BttnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnNew.Click
        'Me.TxtDate.Text = Nothing
        'Me.CmbGroup.SelectedIndex = -1
        'Me.CmbEmployee.SelectedIndex = -1
        'Me.CmbClient.SelectedIndex = -1
        'Me.TxtCashPmt.Text = "0.00"
        'Me.TxtBankPmt.Text = "0.00"

        'Me.CmbBankAccount.SelectedIndex = -1
        'Me.TxtChequeDate.Text = Nothing
        'Me.TxtChequeNo.Text = Nothing
        'Me.TxtChequeType.Text = Nothing

        'Me.TxtDescription.Text = Nothing

        Me.BttnSave.Enabled = True

        Me.LblID.Text = Nothing

        Me.DsCLIENT_RECEIPT1.Clear()
        Me.TxtDate.Text = Date.Now.ToString("dd-MMM-yyyy")
        Me.TxtDate.Focus()

        Me.Default_Setting()
    End Sub

    Private Sub BttnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnSearch.Click
        My.Forms.frmSEARCH_CLIENT_RECEIPT.ShowDialog(Me)
    End Sub

    Private Sub BttnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnSave.Click
        If Not Val(Me.LblID.Text) > 0 Then
            'FOR INSERT RECORD IN CLIENT RECEIPT
            If Me.TxtDate.Text = Nothing Or Me.CmbEmployee.SelectedIndex = -1 Or Me.CmbEmployee.Text = Nothing Or Me.CmbGroup.SelectedIndex = -1 Or Me.CmbGroup.Text = Nothing Or Me.CmbClient.SelectedIndex = -1 Or Me.CmbClient.Text = Nothing Then
                MsgBox("Please enter description OR select correct value!", MsgBoxStyle.Exclamation, "(NS) - Entry Required!")
                If Me.TxtDate.Text = Nothing Then
                    Me.TxtDate.Focus()

                ElseIf Me.CmbGroup.SelectedIndex = -1 Or Me.CmbGroup.Text = Nothing Then
                    Me.CmbGroup.Focus()

                ElseIf Me.CmbEmployee.SelectedIndex = -1 Or Me.CmbEmployee.Text = Nothing Then
                    Me.CmbEmployee.Focus()

                ElseIf Me.CmbClient.SelectedIndex = -1 Or Me.CmbClient.Text = Nothing Then
                    Me.CmbClient.Focus()

                End If

                'PAYMENT MADE VIA BANK ONLY
            ElseIf Val(Me.TxtBankPmt.Text) > 0 And Val(Me.TxtCashPmt.Text) <= 0 Then
                If Me.CmbBankAccount.SelectedIndex = -1 Or Me.TxtChequeNo.Text = Nothing Or Me.TxtChequeType.Text = Nothing Or Me.TxtChequeDate.Text = Nothing Then
                    If Me.CmbBankAccount.SelectedIndex = -1 Then
                        Me.CmbBankAccount.Focus()

                    ElseIf Me.TxtChequeNo.Text = Nothing Then
                        Me.TxtChequeNo.Focus()

                    ElseIf Me.TxtChequeType.Text = Nothing Then
                        Me.TxtChequeType.Focus()

                    ElseIf Me.TxtChequeDate.Text = Nothing Then
                        Me.TxtChequeDate.Focus()

                    End If

                ElseIf MsgBox("Do you want to save in BANK: '" & Me.TxtBankPmt.Text & "'", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "(NS) - Save?") = MsgBoxResult.Yes Then
                    Me.asInsert.SaveValueIN("INSERT INTO CLIENT_RECEIPT(nCLIENT_ID, dDATE, sCHEQUE_NO, sCHEQUE_TYPE, dCHEQUE_DATE, nCHEQUE_AMOUNT, nCHEQUE_STATUS, sACCOUNT_CODE, nEMP_CODE, nLOGIN_ID, nBUSINESS_CODE,sDESCRIPTON) VALUES(" & Val(Me.CmbClient.SelectedItem.Col3) & ", '" & CDate(Me.TxtDate.Text).ToString("MM-dd-yyyy") & "', '" & Me.TxtChequeNo.Text & "', '" & Me.TxtChequeType.Text & "', '" & CDate(Me.TxtChequeDate.Text).ToString("MM-dd-yyyy") & "', " & Val(Me.TxtBankPmt.Text) & ",1,'" & Me.CmbBankAccount.SelectedItem.Col1 & "', " & Val(Me.CmbEmployee.SelectedItem.Col3) & ",10," & Val(Me.CmbGroup.SelectedItem.Col3) & ",'" & Me.TxtDescription.Text & "')")
                    Me.BttnSave.Enabled = False
                    Me.BttnNew.Focus()

                End If

                'PAYMENT MADE VIA CASH ONLY
            ElseIf Val(Me.TxtBankPmt.Text) <= 0 And Val(Me.TxtCashPmt.Text) > 0 Then
                If MsgBox("Do you want to save CASH: '" & Me.TxtCashPmt.Text & "'", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "(NS) - Save?") = MsgBoxResult.Yes Then
                    Me.asInsert.SaveValueIN("INSERT INTO CLIENT_RECEIPT(nCLIENT_ID, dDATE, nCASH_AMOUNT, nEMP_CODE, nLOGIN_ID, nBUSINESS_CODE,sDESCRIPTON) VALUES(" & Val(Me.CmbClient.SelectedItem.Col3) & ",'" & CDate(Me.TxtDate.Text).ToString("MM-dd-yyyy") & "'," & Val(Me.TxtCashPmt.Text) & ", " & Val(Me.CmbEmployee.SelectedItem.Col3) & ",10," & Val(Me.CmbGroup.SelectedItem.Col3) & ",'" & Me.TxtDescription.Text & "')")
                    Me.BttnSave.Enabled = False
                    Me.BttnNew.Focus()

                End If

                'PAYMENT DATE VIA BOTH (CASH & BANK)
            ElseIf Val(Me.TxtBankPmt.Text) > 0 And Val(Me.TxtCashPmt.Text) > 0 Then

                If Me.CmbBankAccount.SelectedIndex = -1 Or Me.TxtChequeNo.Text = Nothing Or Me.TxtChequeType.Text = Nothing Or Me.TxtChequeDate.Text = Nothing Then
                    MsgBox("Please enter description OR select correct value!", MsgBoxStyle.Exclamation, "(NS) - Entry Required!")
                    If Me.CmbBankAccount.SelectedIndex = -1 Then
                        Me.CmbBankAccount.Focus()

                    ElseIf Me.TxtChequeNo.Text = Nothing Then
                        Me.TxtChequeNo.Focus()

                    ElseIf Me.TxtChequeType.Text = Nothing Then
                        Me.TxtChequeType.Focus()

                    ElseIf Me.TxtChequeDate.Text = Nothing Then
                        Me.TxtChequeDate.Focus()

                    End If

                ElseIf MsgBox("Do you want to save CASH: '" & Me.TxtCashPmt.Text & "' & BANK: '" & Me.TxtBankPmt.Text & "'", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "(NS) - Save?") = MsgBoxResult.Yes Then
                    Me.asInsert.SaveValueIN("INSERT INTO CLIENT_RECEIPT(nCLIENT_ID, dDATE, nCASH_AMOUNT, sCHEQUE_NO,sCHEQUE_TYPE, dCHEQUE_DATE, nCHEQUE_AMOUNT, nCHEQUE_STATUS, sACCOUNT_CODE, nEMP_CODE, nLOGIN_ID, nBUSINESS_CODE,sDESCRIPTON) VALUES(" & Val(Me.CmbClient.SelectedItem.Col3) & ", '" & CDate(Me.TxtDate.Text).ToString("MM-dd-yyyy") & "', " & Val(Me.TxtCashPmt.Text) & ", '" & Me.TxtChequeNo.Text & "', '" & Me.TxtChequeType.Text & "', '" & CDate(Me.TxtChequeDate.Text).ToString("MM-dd-yyyy") & "', " & Val(Me.TxtBankPmt.Text) & ",1,'" & Me.CmbBankAccount.SelectedItem.Col1 & "', " & Val(Me.CmbEmployee.SelectedItem.Col3) & ",10," & Val(Me.CmbGroup.SelectedItem.Col3) & ",'" & Me.TxtDescription.Text & "')")
                    Me.BttnSave.Enabled = False
                    Me.BttnNew.Focus()
                End If

            ElseIf Val(Me.TxtBankPmt.Text) <= 0 And Val(Me.TxtCashPmt.Text) <= 0 Then
                MsgBox("Please enter Cash Value OR Bank Value!", MsgBoxStyle.Exclamation, "(NS) - Entry Required!")
                Me.TxtCashPmt.Focus()

            End If

        ElseIf Val(Me.LblID.Text) > 0 Then

            'FOR UPDATE RECORD IN SUPPLIER PAYMENT
            If Me.TxtDate.Text = Nothing Or Me.CmbEmployee.SelectedIndex = -1 Or Me.CmbEmployee.Text = Nothing Or Me.CmbGroup.SelectedIndex = -1 Or Me.CmbGroup.Text = Nothing Or Me.CmbClient.SelectedIndex = -1 Or Me.CmbClient.Text = Nothing Then
                MsgBox("Please enter description OR select correct value!", MsgBoxStyle.Exclamation, "(NS) - Entry Required!")
                If Me.TxtDate.Text = Nothing Then
                    Me.TxtDate.Focus()

                ElseIf Me.CmbGroup.SelectedIndex = -1 Or Me.CmbGroup.Text = Nothing Then
                    Me.CmbGroup.Focus()

                ElseIf Me.CmbEmployee.SelectedIndex = -1 Or Me.CmbEmployee.Text = Nothing Then
                    Me.CmbEmployee.Focus()

                ElseIf Me.CmbClient.SelectedIndex = -1 Or Me.CmbClient.Text = Nothing Then
                    Me.CmbClient.Focus()

                End If

                'PAYMENT MADE VIA BANK ONLY
            ElseIf Val(Me.TxtBankPmt.Text) > 0 And Val(Me.TxtCashPmt.Text) <= 0 Then
                If Me.CmbBankAccount.SelectedIndex = -1 Or Me.TxtChequeNo.Text = Nothing Or Me.TxtChequeType.Text = Nothing Or Me.TxtChequeDate.Text = Nothing Then
                    If Me.CmbBankAccount.SelectedIndex = -1 Then
                        Me.CmbBankAccount.Focus()

                    ElseIf Me.TxtChequeNo.Text = Nothing Then
                        Me.TxtChequeNo.Focus()

                    ElseIf Me.TxtChequeType.Text = Nothing Then
                        Me.TxtChequeType.Focus()

                    ElseIf Me.TxtChequeDate.Text = Nothing Then
                        Me.TxtChequeDate.Focus()

                    End If

                ElseIf MsgBox("Do you want to update BANK: '" & Me.TxtBankPmt.Text & "'", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "(NS) - Update?") = MsgBoxResult.Yes Then
                    Me.asUpdate.UpdateValueIN("UPDATE CLIENT_RECEIPT SET nCLIENT_ID=" & Val(Me.CmbClient.SelectedItem.Col3) & ", dDATE='" & CDate(Me.TxtDate.Text).ToString("MM-dd-yyyy") & "', sCHEQUE_NO='" & Me.TxtChequeNo.Text & "', sCHEQUE_TYPE='" & Me.TxtChequeType.Text & "', dCHEQUE_DATE='" & CDate(Me.TxtChequeDate.Text).ToString("MM-dd-yyyy") & "', nCHEQUE_AMOUNT=" & Val(Me.TxtBankPmt.Text) & ", sACCOUNT_CODE='" & Me.CmbBankAccount.SelectedItem.Col1 & "', nEMP_CODE=" & Val(Me.CmbEmployee.SelectedItem.Col3) & ", nLOGIN_ID=10, nBUSINESS_CODE=" & Val(Me.CmbGroup.SelectedItem.Col3) & " ,sDESCRIPTON='" & Me.TxtDescription.Text & "', nCASH_AMOUNT=0 WHERE nID=" & Val(Me.LblID.Text) & "")
                    Me.BttnSave.Enabled = False
                    Me.BttnNew.Focus()

                End If

                'PAYMENT MADE VIA CASH ONLY
            ElseIf Val(Me.TxtBankPmt.Text) <= 0 And Val(Me.TxtCashPmt.Text) > 0 Then
                If MsgBox("Do you want to update CASH: '" & Me.TxtCashPmt.Text & "'", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "(NS) - Update?") = MsgBoxResult.Yes Then
                    Me.asUpdate.UpdateValueIN("UPDATE CLIENT_RECEIPT SET nCLIENT_ID=" & Val(Me.CmbClient.SelectedItem.Col3) & ", dDATE='" & CDate(Me.TxtDate.Text).ToString("MM-dd-yyyy") & "', sCHEQUE_NO=NULL, sCHEQUE_TYPE=NULL, dCHEQUE_DATE=NULL, nCHEQUE_AMOUNT=0, sACCOUNT_CODE=NULL, nEMP_CODE=" & Val(Me.CmbEmployee.SelectedItem.Col3) & ", nLOGIN_ID=10, nBUSINESS_CODE=" & Val(Me.CmbGroup.SelectedItem.Col3) & " ,sDESCRIPTON='" & Me.TxtDescription.Text & "', nCASH_AMOUNT=" & Val(Me.TxtCashPmt.Text) & " WHERE nID=" & Val(Me.LblID.Text) & "")
                    Me.BttnSave.Enabled = False
                    Me.BttnNew.Focus()

                End If

                'PAYMENT DATE VIA BOTH (CASH & BANK)
            ElseIf Val(Me.TxtBankPmt.Text) > 0 And Val(Me.TxtCashPmt.Text) > 0 Then

                If Me.CmbBankAccount.SelectedIndex = -1 Or Me.TxtChequeNo.Text = Nothing Or Me.TxtChequeType.Text = Nothing Or Me.TxtChequeDate.Text = Nothing Then
                    MsgBox("Please enter description OR select correct value!", MsgBoxStyle.Exclamation, "(NS) - Entry Required!")
                    If Me.CmbBankAccount.SelectedIndex = -1 Then
                        Me.CmbBankAccount.Focus()

                    ElseIf Me.TxtChequeNo.Text = Nothing Then
                        Me.TxtChequeNo.Focus()

                    ElseIf Me.TxtChequeType.Text = Nothing Then
                        Me.TxtChequeType.Focus()

                    ElseIf Me.TxtChequeDate.Text = Nothing Then
                        Me.TxtChequeDate.Focus()

                    End If

                ElseIf MsgBox("Do you want to update CASH: '" & Me.TxtCashPmt.Text & "' & BANK: '" & Me.TxtBankPmt.Text & "'", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "(NS) - Update?") = MsgBoxResult.Yes Then
                    Me.asUpdate.UpdateValueIN("UPDATE CLIENT_RECEIPT SET nCLIENT_ID=" & Val(Me.CmbClient.SelectedItem.Col3) & ", dDATE='" & CDate(Me.TxtDate.Text).ToString("MM-dd-yyyy") & "', sCHEQUE_NO='" & Me.TxtChequeNo.Text & "', sCHEQUE_TYPE='" & Me.TxtChequeType.Text & "', dCHEQUE_DATE='" & CDate(Me.TxtChequeDate.Text).ToString("MM-dd-yyyy") & "', nCHEQUE_AMOUNT=" & Val(Me.TxtBankPmt.Text) & ", sACCOUNT_CODE='" & Me.CmbBankAccount.SelectedItem.Col1 & "', nEMP_CODE=" & Val(Me.CmbEmployee.SelectedItem.Col3) & ", nLOGIN_ID=10, nBUSINESS_CODE=" & Val(Me.CmbGroup.SelectedItem.Col3) & " ,sDESCRIPTON='" & Me.TxtDescription.Text & "', nCASH_AMOUNT=" & Val(Me.TxtCashPmt.Text) & " WHERE nID=" & Val(Me.LblID.Text) & "")
                    Me.BttnSave.Enabled = False
                    Me.BttnNew.Focus()
                End If

            ElseIf Val(Me.TxtBankPmt.Text) <= 0 And Val(Me.TxtCashPmt.Text) <= 0 Then
                MsgBox("Please enter Cash Value OR Bank Value!", MsgBoxStyle.Exclamation, "(NS) - Entry Required!")
                Me.TxtCashPmt.Focus()

            End If
        End If

    End Sub
    Private Sub BttnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnClose.Click
        Me.Close()
    End Sub

    Private Sub BttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BttnDelete.Click
        If MsgBox("Are you sure to Delete this Receipt Record?", MsgBoxStyle.Critical + vbYesNo, "(NS) - Deletion!") = MsgBoxResult.Yes Then
            Me.asDelete.DeleteValue("DELETE FROM CLIENT_RECEIPT WHERE nID=" & Val(Me.LblID.Text) & "")
            Me.LblID.Text = Nothing
        End If
    End Sub
#End Region

#Region "Sub and Functions"
    Private Sub FillComboBox_Client()
        Dim Str1 As String = "SELECT ID, NAME, SHOP_NAME, SHOP_ADD, AREA, HOME_ADD, SHOP_PH, HOME_PH, CELL_NO, FAX_NO, E_MAIL, WEB_SITE, CASE STATUS WHEN '0' THEN 'No' WHEN '1' THEN 'Yes' END AS STATUS, CLIENT_CAT, CLIENT_GD, CLIENT_TYPE, CONVERT(NUMERIC(18,2), CREDIT_LIM) AS CREDIT_LIM, GST_NO, CONVERT(NUMERIC(18,2), OPEN_BAL) AS OPEN_BAL, VISIT_TYPE, NO_VISIT, ROUTE FROM V_CLIENT_INFO WHERE STATUS='1' ORDER BY SHOP_NAME"
        Dim SqlCmd1 As New SDS.SqlCommand(Str1, Me.SqlConnection1)
        Me.daCLIENT_INFO = New SDS.SqlDataAdapter(SqlCmd1)

        Me.DsCLIENT_INFO1.Clear()
        Me.daCLIENT_INFO.Fill(Me.DsCLIENT_INFO1.V_CLIENT_INFO)

        Dim dtLoading As New DataTable("V_CLIENT_INFO")

        dtLoading.Columns.Add("ID", System.Type.GetType("System.String"))
        dtLoading.Columns.Add("NAME", System.Type.GetType("System.String"))
        dtLoading.Columns.Add("SHOP_NAME", System.Type.GetType("System.String"))

        Dim Cnt As Integer

        For Cnt = 0 To Me.DsCLIENT_INFO1.V_CLIENT_INFO.Count - 1
            Dim dr As DataRow
            dr = dtLoading.NewRow

            dr("ID") = Me.DsCLIENT_INFO1.V_CLIENT_INFO.Item(Cnt).Item(0).ToString
            dr("NAME") = Me.DsCLIENT_INFO1.V_CLIENT_INFO.Item(Cnt).Item(1).ToString
            dr("SHOP_NAME") = Me.DsCLIENT_INFO1.V_CLIENT_INFO.Item(Cnt).Item(2).ToString

            dtLoading.Rows.Add(dr)
        Next

        Me.CmbClient.SelectedIndex = -1
        Me.CmbClient.Items.Clear()
        Me.CmbClient.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
        Me.CmbClient.SourceDataString = New String(2) {"SHOP_NAME", "NAME", "ID"}
        Me.CmbClient.SourceDataTable = dtLoading
    End Sub
    Private Sub FillComboBox_Group()
        Dim Str1 As String = "SELECT nID, sGROUP_NAME, sGROUP_DEALER, sSTATUS sBUSINESS_NAME FROM V_BUSINESS_GROUP WHERE sSTATUS='1'"
        Dim SqlCmd1 As New SDS.SqlCommand(Str1, Me.SqlConnection1)
        Me.daLUP_BUSINESS_GROUP = New SDS.SqlDataAdapter(SqlCmd1)

        Me.DsLUP_BUSINESS_GROUP1.Clear()
        Me.daLUP_BUSINESS_GROUP.Fill(Me.DsLUP_BUSINESS_GROUP1.V_BUSINESS_GROUP)

        Dim dtLoading As New DataTable("V_BUSINESS_GROUP")

        dtLoading.Columns.Add("nID", System.Type.GetType("System.String"))
        dtLoading.Columns.Add("sGROUP_NAME", System.Type.GetType("System.String"))
        dtLoading.Columns.Add("sGROUP_DEALER", System.Type.GetType("System.String"))

        Dim Cnt As Integer

        For Cnt = 0 To Me.DsLUP_BUSINESS_GROUP1.V_BUSINESS_GROUP.Count - 1
            Dim dr As DataRow
            dr = dtLoading.NewRow

            dr("nID") = Me.DsLUP_BUSINESS_GROUP1.V_BUSINESS_GROUP.Item(Cnt).Item(0).ToString
            dr("sGROUP_NAME") = Me.DsLUP_BUSINESS_GROUP1.V_BUSINESS_GROUP.Item(Cnt).Item(1).ToString
            dr("sGROUP_DEALER") = Me.DsLUP_BUSINESS_GROUP1.V_BUSINESS_GROUP.Item(Cnt).Item(2).ToString

            dtLoading.Rows.Add(dr)
        Next

        Me.CmbGroup.SelectedIndex = -1
        Me.CmbGroup.Items.Clear()
        Me.CmbGroup.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
        Me.CmbGroup.SourceDataString = New String(2) {"sGROUP_NAME", "sGROUP_DEALER", "nID"}
        Me.CmbGroup.SourceDataTable = dtLoading
    End Sub
    Private Sub FillComboBox_Employee()
        Dim Str1 As String = "SELECT CODE, NAME, FATHER_NAME, NIC, HOME_PH, CELL, PRE_ADD, PER_ADD, DESIGNATION, APP_DATE, PAY, STATUS, LEAVE_DATE, EMAIL_ADD, BANK_ACC, BANK_ADD FROM V_EMPLOYEE_INFO WHERE STATUS='1'"
        Dim SqlCmd1 As New SDS.SqlCommand(Str1, Me.SqlConnection1)
        Me.daLUP_EMPLOYEE = New SDS.SqlDataAdapter(SqlCmd1)

        Me.DsLUP_EMPLOYEE1.Clear()
        Me.daLUP_EMPLOYEE.Fill(Me.DsLUP_EMPLOYEE1.V_EMPLOYEE_INFO)

        Dim dtLoading As New DataTable("V_EMPLOYEE_INFO")

        dtLoading.Columns.Add("CODE", System.Type.GetType("System.String"))
        dtLoading.Columns.Add("NAME", System.Type.GetType("System.String"))
        dtLoading.Columns.Add("DESIGNATION", System.Type.GetType("System.String"))

        Dim Cnt As Integer

        For Cnt = 0 To Me.DsLUP_EMPLOYEE1.V_EMPLOYEE_INFO.Count - 1
            Dim dr As DataRow
            dr = dtLoading.NewRow

            dr("CODE") = Me.DsLUP_EMPLOYEE1.V_EMPLOYEE_INFO.Item(Cnt).Item(0).ToString
            dr("NAME") = Me.DsLUP_EMPLOYEE1.V_EMPLOYEE_INFO.Item(Cnt).Item(1).ToString
            dr("DESIGNATION") = Me.DsLUP_EMPLOYEE1.V_EMPLOYEE_INFO.Item(Cnt).Item(8).ToString

            dtLoading.Rows.Add(dr)
        Next

        Me.CmbEmployee.SelectedIndex = -1
        Me.CmbEmployee.Items.Clear()
        Me.CmbEmployee.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
        Me.CmbEmployee.SourceDataString = New String(2) {"NAME", "DESIGNATION", "CODE"}
        Me.CmbEmployee.SourceDataTable = dtLoading
    End Sub
    Private Sub FillComboBox_BankAccount()
        Dim Str1 As String = "SELECT sACCOUNT_NO, sBANK_NAME, sBRANCH_NAME, sBRANCH_code, sADDRESS, sCONTACT1, sCONTACT2, sMANAGER_NAME, sMANAGER_PH, sMANAGER_CELL, sSTATUS FROM LUP_BANK WHERE sSTATUS='1'"
        Dim SqlCmd1 As New SDS.SqlCommand(Str1, Me.SqlConnection1)
        Me.daLUP_BANK = New SDS.SqlDataAdapter(SqlCmd1)

        Me.DsLUP_BANK1.Clear()
        Me.daLUP_BANK.Fill(Me.DsLUP_BANK1.LUP_BANK)

        Dim dtLoading As New DataTable("LUP_BANK")

        dtLoading.Columns.Add("sACCOUNT_NO", System.Type.GetType("System.String"))
        dtLoading.Columns.Add("sBANK_NAME", System.Type.GetType("System.String"))

        Dim Cnt As Integer

        For Cnt = 0 To Me.DsLUP_BANK1.LUP_BANK.Count - 1
            Dim dr As DataRow
            dr = dtLoading.NewRow

            dr("sACCOUNT_NO") = Me.DsLUP_BANK1.LUP_BANK.Item(Cnt).Item(0).ToString
            dr("sBANK_NAME") = Me.DsLUP_BANK1.LUP_BANK.Item(Cnt).Item(1).ToString

            dtLoading.Rows.Add(dr)
        Next

        Me.CmbBankAccount.SelectedIndex = -1
        Me.CmbBankAccount.Items.Clear()
        Me.CmbBankAccount.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
        Me.CmbBankAccount.SourceDataString = New String(1) {"sACCOUNT_NO", "sBANK_NAME"}
        Me.CmbBankAccount.SourceDataTable = dtLoading
    End Sub

    Private Sub Default_Setting()
        On Error GoTo Fix
        Dim StrCMB As String

        StrCMB = Me.DsNS_DEFAULT1.NS_DEFAULT.Item(0).Item("GROUP").ToString
        Me.CmbGroup.SelectedIndex = -1
        If Not StrCMB = Nothing Then
            Me.CmbGroup.SelectedIndex = Me.CmbGroup.FindString(StrCMB)
        End If

        StrCMB = Me.DsNS_DEFAULT1.NS_DEFAULT.Item(0).Item("R_MAN").ToString
        Me.CmbEmployee.SelectedIndex = -1
        If Not StrCMB = Nothing Then
            Me.CmbEmployee.SelectedIndex = Me.CmbEmployee.FindString(StrCMB)
        End If

        StrCMB = Me.DsNS_DEFAULT1.NS_DEFAULT.Item(0).Item("CLIENT").ToString
        Me.CmbClient.SelectedIndex = -1
        If Not StrCMB = Nothing Then
            Me.CmbClient.SelectedIndex = Me.CmbClient.FindString(StrCMB)
        End If

        StrCMB = Me.DsNS_DEFAULT1.NS_DEFAULT.Item(0).Item("BANK_ACC").ToString
        Me.CmbBankAccount.SelectedIndex = -1
        If Not StrCMB = Nothing Then
            Me.CmbBankAccount.SelectedIndex = Me.CmbBankAccount.FindString(StrCMB)
        End If

Fix:
    End Sub
#End Region


End Class