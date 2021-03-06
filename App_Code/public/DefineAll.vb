﻿Public Module DefineAll
    'tc 0823 PDF前置名稱
    Public Const PDF_PRE_NAME As String = "Sunshine_"

    '控制項的ID
    Public Const Txt_Name_Id As String = "Txt_Name"
    Public Const Txt_OldName_Id As String = "Txt_OldName" '2017/9/4 gin 改名前之姓名 
    Public Const RdButton_Sex_Id As String = "RdButton_Sex"
    Public Const Txt_Id_Id As String = "Txt_Id"
    Public Const DpDownList_Year_Id As String = "DpDownList_Year"
    Public Const DpDownList_Month_Id As String = "DpDownList_Month"
    Public Const DpDownList_Day_Id As String = "DpDownList_Day"
    Public Const TxtBox_Zid_Id As String = "TxtBox_Zid"
    Public Const TxtBox_Address_Id As String = "TxtBox_Address"
    Public Const TxtBox_RZip_Id As String = "TxtBox_RZip"
    Public Const TxtBox_RAddress_Id As String = "TxtBox_RAddress"
    Public Const CkBox_RAddress_Id As String = "CkBox_RAddress"
    Public Const TxtBox_Tel_1_Id As String = "TxtBox_Tel_1"
    Public Const TxtBox_Tel_2_Id As String = "TxtBox_Tel_2"
    Public Const TxtBox_Mobile_Id As String = "TxtBox_Mobile"
    Public Const TxtBox_Email_Id As String = "TxtBox_Email"
    Public Const RdButton_Damage_Id As String = "RdButton_Damage"
    Public Const TxtBox_Damage_Id As String = "TxtBox_Damage"
    Public Const TxtBox_School_Id As String = "TxtBox_School"
    Public Const TxtBox_Dep_Id As String = "TxtBox_Dep"
    Public Const TxtBox_Grage_Id As String = "TxtBox_Grage"
    Public Const RdButton_ApplyTimes_Id As String = "RdButton_ApplyTimes"
    Public Const DpDownList_Awards_Id As String = "DpDownList_Awards"
    Public Const Table_Apply_Item_S_Id As String = "Table_Apply_Item_S"
    Public Const RdButton_Apply_Item_S_Id As String = "RdButton_Apply_Item_S"
    Public Const RdButton_Apply_Item_Z_Id As String = "RdButton_Apply_Item_Z"
    Public Const RdButton_Apply_Item_M_Id As String = "RdButton_Apply_Item_M"
    Public Const RdButton_Mode_Id As String = "RdButton_Mode"
    Public Const RdButton_Parents_Id As String = "RdButton_Parents"
    Public Const TxtBox_PName_Id As String = "TxtBox_PName"
    Public Const TxtBox_PName_M_Id As String = "TxtBox_PName_M"

    Public Const TxtBox_Recommend_Id As String = "TxtBox_Recommend"
    Public Const TxtBox_Rec_Name_Id As String = "TxtBox_Rec_Name"
    Public Const TxtBox_Rec_Position_Id As String = "TxtBox_Rec_Position"
    Public Const TxtBox_Rec_Tel_Id As String = "TxtBox_Rec_Tel"
    Public Const TxtBox_Account_Name_Id As String = "TxtBox_Account_Name"
    Public Const DpDownList_Bank_Code_Id As String = "DpDownList_Bank_Code"
    Public Const TxtBox_Bank_Id As String = "TxtBox_Bank"
    Public Const TxtBox_Account_No_Id As String = "TxtBox_Account_No"

    '控制項的Name
    Public Const Txt_Name_Name As String = "姓名"
    Public Const Txt_OldName_Name As String = "改名前之姓名" '2017/9/4 gin 改名前之姓名 
    Public Const RdButton_Sex_Name As String = "性別"
    Public Const Txt_Id_Name As String = "身分證號碼"
    Public Const DpDownList_Year_Name As String = "出生年月日的年"
    Public Const DpDownList_Month_Name As String = "出生年月日的月"
    Public Const DpDownList_Day_Name As String = "出生年月日的日"
    Public Const TxtBox_Zid_Name As String = "郵遞區號"
    Public Const TxtBox_Address_Name As String = "聯絡地址"
    Public Const TxtBox_RZip_Name As String = "戶地址郵遞區號"
    Public Const CkBox_RAddress_Name As String = "戶地址聯絡地址"
    Public Const TxtBox_RAddress_Name As String = "戶地址聯絡地址"
    Public Const TxtBox_Tel_1_Name As String = "電話(日)"
    Public Const TxtBox_Tel_2_Name As String = "電話(夜)"
    Public Const TxtBox_Mobile_Name As String = "手機"
    Public Const TxtBox_Email_Name As String = "電子郵件信箱"
    Public Const RdButton_Damage_Name As String = "損傷類別"
    Public Const TxtBox_Damage_Name As String = "損傷類別的顏面損傷6.其他"
    Public Const TxtBox_School_Name As String = "學校名稱"
    Public Const TxtBox_Dep_Name As String = "科系名稱"
    Public Const TxtBox_Grage_Name As String = "年級"
    Public Const RdButton_ApplyTimes_Name As String = "申請次數"
    Public Const DpDownList_Awards_Name As String = "申請組別"
    Public Const Table_Apply_Item_S_Name As String = "申請獎項"
    Public Const RdButton_Apply_Item_S_Name As String = "申請獎項"  '陽光
    Public Const RdButton_Apply_Item_Z_Name As String = "申請獎項"  '仁寶
    Public Const RdButton_Apply_Item_M_Name As String = "申請獎項"  '明閱
    Public Const TxtBox_PName_Name As String = "子女助學金之損傷者姓名"
    Public Const TxtBox_PName_M_Name As String = "子女助學金之損傷者姓名"
    Public Const RdButton_Parents_Name As String = "子女助學金之親屬關係"
    Public Const RdButton_Mode_Name As String = "申請方式"
    Public Const TxtBox_Recommend_Name As String = "申請方式的推薦單位"
    Public Const TxtBox_Rec_Name_Name As String = "申請方式的推薦人姓名"
    Public Const TxtBox_Rec_Position_Name As String = "申請方式的推薦人職務"
    Public Const TxtBox_Rec_Tel_Name As String = "申請方式的推薦人電話"
    Public Const TxtBox_Account_Name_Name As String = "戶名"
    Public Const DpDownList_Bank_Code_Name As String = "銀行代碼"
    Public Const TxtBox_Bank_Name As String = "銀行代碼"
    Public Const TxtBox_Account_No_Name As String = "銀行帳號"

    '對應的欄位名稱
    Public Const ApplyNo_CName As String = "apply_no"
    Public Const ApplyDate_CName As String = "apply_date"
    Public Const Txt_Name_CName As String = "name"
    Public Const Txt_OldName_CName As String = "OriginalName" '2017/9/4 gin 改名前之姓名 
    Public Const RdButton_Sex_CName As String = "sex"
    Public Const Txt_Id_CName As String = "id_no"
    Public Const DpDownList_Birthday_CName As String = "birthday"
    Public Const TxtBox_Zid_CName As String = "czip"
    Public Const TxtBox_Address_CName As String = "caddress"
    Public Const TxtBox_RZip_CName As String = "rzip"
    Public Const CkBox_RAddress_CName As String = "raddress"
    Public Const TxtBox_RAddress_CName As String = "raddress"
    Public Const TxtBox_Tel_1_CName As String = "tel1"
    Public Const TxtBox_Tel_2_CName As String = "tel2"
    Public Const TxtBox_Mobile_CName As String = "mobile"
    Public Const TxtBox_Email_CName As String = "email"
    Public Const RdButton_Damage_CName As String = "trauma_type"
    Public Const TxtBox_Damage_CName As String = "trauma_remark" '沒有設，待查
    Public Const TxtBox_School_CName As String = "school"
    Public Const TxtBox_Dep_CName As String = "department"
    Public Const TxtBox_Grage_CName As String = "grade"
    Public Const RdButton_ApplyTimes_CName As String = "apply_times"
    Public Const DpDownList_Awards_CName As String = "groups"
    Public Const FpDownList_Birthday_CName As String = "birthday"
    Public Const RdButton_Apply_Item_Z_CName As String = "awards" '陽光
    Public Const RdButton_Apply_Item_M_CName As String = "awards" '仁寶
    Public Const RdButton_Apply_Item_S_CName As String = "awards" '明閱
    Public Const TxtBox_PName_CName As String = "parents_name"
    Public Const TxtBox_PName_M_CName As String = "parents_name"
    Public Const RdButton_Parents_CName As String = "parents"
    Public Const RdButton_Mode_CName As String = "apply_mode"
    Public Const TxtBox_Recommend_CName As String = "recommend"
    Public Const TxtBox_Rec_Name_CName As String = "rec_name"
    Public Const TxtBox_Rec_Position_CName As String = "rec_position"
    Public Const TxtBox_Rec_Tel_CName As String = "rec_tel"
    Public Const TxtBox_Account_Name_CName As String = "account_name"
    Public Const DpDownList_Bank_Code_CName As String = "bank_code"
    Public Const TxtBox_Bank_CName As String = "bank_code"
    Public Const TxtBox_Account_No_CName As String = "account_no"

End Module
