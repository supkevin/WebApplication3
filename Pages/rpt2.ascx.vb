
Partial Class Pages_rpt2
    Inherits System.Web.UI.UserControl
    Public Const ChkFlag As String = "■"
    Public Const UnChkFlag As String = "□"

    Public Sub SetValues()
        lbYear.Text = DateTime.Now.Year - 1911
        lbMon.Text = DateTime.Now.Month.ToString
        lbDay.Text = DateTime.Now.Day.ToString

        '編號
        lbNo.Text = Session("CApplyNo")

        '性別
        If Session("RdButton_Sex_Confirm") = "M" Then
            lbMan.Text = ChkFlag
        Else
            lbFman.Text = ChkFlag
        End If

        lbName.Text = Session("Lb_Name_Confirm") '姓名
        lbOldName.Text = Session("Lb_OldName_Confirm") '2017/9/4 gin 改名前之姓名 
        lbUID.Text = Session("Lb_Id_Confirm") '身分證號碼
        Lb_Account.Text = Session("Lb_Account") ''匯款帳號
        Lb_Account_Name.Text = Session("Lb_Account_Name") '戶名
        Lb_Address.Text = Session("Lb_Address") '聯絡地址
        Lb_RAddress.Text = Session("Lb_RAddress") '戶籍聯絡地址
        Lb_Tel_D.Text = Session("Lb_Tel_D") '電話(日)
        Lb_Tel_N.Text = Session("Lb_Tel_N") '電話(夜)
        Lb_Mobile_Confirm.Text = Session("Lb_Mobile_Confirm") '手機
        Lb_Email.Text = Session("Lb_Email") '電子信箱
        Lb_School.Text = Session("Lb_School") '學校名稱
        Lb_Dep.Text = Session("Lb_Dep") '科系名稱
        Lb_Grade_Confirm.Text = Session("Lb_Grade_Confirm") '年級
        Lb_Bank_No.Text = Session("Lb_Bank_No")
        Lb_Birthday_Y.Text = Trim(Session("Lb_Birthday_Y")) '出生年月日的年
        Lb_Birthday_M.Text = Trim(Session("Lb_Birthday_M")) '出生年月日的月
        Lb_Birthday_D.Text = Trim(Session("Lb_Birthday_D")) '出生年月日的日
        'DpDownList_Awards_Confirm.SelectedValue = Session("DpDownList_Awards_Confirm") '申請組別
        'RdButton_Sex_Confirm.SelectedValue = Session("RdButton_Sex_Confirm") '性別
        'RdButton_Damage_Confirm.SelectedValue = Session("RdButton_Damage_Confirm") '確認申請資料的損傷類別
        '損傷類別
        Select Case Session("RdButton_Damage_Confirm")
            Case "B0"
                lbD1.Text = ChkFlag
            Case "F1"
                lbD20.Text = ChkFlag
                lbD21.Text = ChkFlag
            Case "F2"
                lbD20.Text = ChkFlag
                lbD22.Text = ChkFlag
            Case "F3"
                lbD20.Text = ChkFlag
                lbD23.Text = ChkFlag
            Case "F4"
                lbD20.Text = ChkFlag
                lbD24.Text = ChkFlag
            Case "F5"
                lbD20.Text = ChkFlag
                lbD25.Text = ChkFlag
            Case "F6"
                lbD20.Text = ChkFlag
                lbD26.Text = ChkFlag
                lbD26Other.Text = Session("Lb_Damage")    'todo
        End Select

        '初次
        If Session("RdButton_ApplyTime_Confirm") = "1" Then
            lbFirst.Text = ChkFlag
        Else
            lbMulti.Text = ChkFlag
        End If

        '獎項 
        Select Case Session("AppleMode")
            Case "S1"
                lblAward1.Visible = True
            Case "S2"
                lblAward2.Visible = True
            Case "S3"
                lblAward3.Visible = True
            Case "S4"
                lblAward4.Visible = True
            Case "S5"
                lblAward5.Visible = True
                showParent()
            Case "S6"
                lblAward6.Visible = True
                showParent()
            Case Else
                Response.Write("錯誤獎項，AppleMode=" + Session("AppleMode"))
                Response.End()
        End Select

        '申請人
        If Session("RdButton_Mode_Confirm") = "1" Then
            lbSelfApply.Text = ChkFlag
        Else
            lbRecApply.Text = ChkFlag
            Lb_recommend.Text = Session("Lb_recommend")
            Lb_Rec_Name.Text = Session("Lb_Rec_Name")
            Lb_Rec_Position.Text = Session("Lb_Rec_Position")
            Lb_Rec_Tel.Text = Session("Lb_Rec_Tel")
        End If

        '申請組別
        Select Case Session("DpDownList_Awards_Confirm")
            Case "1"
                lbClass1.Text = ChkFlag
            Case "2"
                lbClass2.Text = ChkFlag
            Case "3"
                lbClass3.Text = ChkFlag
            Case "4"
                lbClass4.Text = ChkFlag
            Case "5"
                lbClass5.Text = ChkFlag
            Case "6"
                lbClass6.Text = ChkFlag
        End Select
    End Sub

    Private Sub showParent()
        '傷者姓名
        If Session("RdButton_Parents_Confirm") = "1" Then
            '父
            lbFatherName.Text = Session("Lb_PName")
            lbFather.Text = ChkFlag
        Else
            '母
            lbMontherName.Text = Session("Lb_PName")
            lbMonther.Text = ChkFlag
        End If
    End Sub
End Class
