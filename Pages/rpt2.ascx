<%@ Control Language="VB" AutoEventWireup="false" CodeFile="rpt2.ascx.vb" Inherits="Pages_rpt2" %>

<table style="border-width: 0px; background-color:White; width: 21cm; height: 15cm; vertical-align: top; font-family: 標楷體; font-size: 12px;" 
        cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td>
                <p align="center">
                    <b>
                    <span style="font-size:20pt; font-family: 標楷體;">財團法人陽光社會福利基金會<br />獎助學金申請書</span></b></p>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" >
                    <tr>
                           <td style="font-size:16pt; font-family: 標楷體;">
                            編號：<asp:Label ID="lbNo" runat="server" Text="Label"></asp:Label>
             
                        </td>
                                    <td style="font-size:16pt; font-family: 標楷體;" align="right">
                            申請日期:中華民國 <asp:Label ID="lbYear" runat="server" Text="Label"></asp:Label>年
                            <asp:Label ID="lbMon" runat="server" Text="Label"></asp:Label>月
                            <asp:Label ID="lbDay" runat="server" Text="Label"></asp:Label>日</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>                
                    <table border="1" cellpadding="0" cellspacing="0" 
                    style="mso-table-layout-alt: fixed; mso-border-alt: solid windowtext .5pt; mso-padding-alt: 0cm 1.4pt 0cm 1.4pt; mso-border-insideh: .5pt solid windowtext; mso-border-insidev: .5pt solid windowtext" 
                    width="100%">
                    <tr>
                        <td rowspan="6" bgcolor="#D9D9D9">
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">基<span 
                                    lang="EN-US"><o:p></o:p></span></span></p>
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">本<span 
                                    lang="EN-US"><o:p></o:p></span></span></p>
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">資<span 
                                    lang="EN-US"><o:p></o:p></span></span></p>
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">料<span 
                                    lang="EN-US"><o:p></o:p></span></span></p>
                        </td>
                        <td colspan="2" bgcolor="#D9D9D9" rowspan="2" style="font-size:14pt;font-family:標楷體;">
                            <p align="center" >
                                姓名</p>
                        </td>
                        <td  rowspan="2" colspan="2" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="lbName" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lbOldName" runat="server" Text="Label" Visible ="false"></asp:Label>
                            </td>
                        <td bgcolor="#D9D9D9" rowspan="2" style="font-size:14pt;font-family:標楷體;">
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">性別</span></p>
                        </td>
                        <td rowspan="2" colspan="2" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <p align="center" >                               
                                    <asp:Label ID="lbMan" runat="server" Text="□"></asp:Label>男
                                    <asp:Label ID="lbFman" runat="server" Text="□"></asp:Label>女</p>
                        </td>
                        <td bgcolor="#D9D9D9" colspan="2">
                            <p align="center" >
                                <span style="font-size:14pt;font-family:
  標楷體">出生年月日<span lang="EN-US"><o:p></o:p></span></span></p>
                        </td>
                        <td colspan="3" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="Lb_Birthday_Y" runat="server" Text="Label"></asp:Label>年<asp:Label ID="Lb_Birthday_M" runat="server" Text="Label"></asp:Label>月<asp:Label ID="Lb_Birthday_D" runat="server" Text="Label"></asp:Label>日</td>
                    </tr>
                    <tr style="mso-yfti-irow:1;page-break-inside:avoid;height:27.5pt">
                        <td bgcolor="#D9D9D9" colspan="2">
                            <p align="center" >
                                <span style="font-size:14pt;font-family:
  標楷體">身分證字號<span lang="EN-US"><o:p></o:p></span></span></p>
                        </td>
                        <td colspan="3" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="lbUID" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr style="mso-yfti-irow:3;page-break-inside:avoid;height:36.9pt">
                        <td bgcolor="#D9D9D9" colspan="2" style="font-size: 14pt;font-family:標楷體;">
                                <b>聯絡地址</b>(獎助相關資料寄送處)
                        </td>
                        <td colspan="5" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="Lb_Address" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td bgcolor="#D9D9D9" colspan="2">
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">電話（日）<span 
                                    lang="EN-US"><o:p></o:p></span></span></p>
                        </td>
                        <td  colspan="3" style="font-size:17pt;font-family:標楷體; padding-left: 5px;" >
                            <asp:Label ID="Lb_Tel_D" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#D9D9D9" colspan="2" style="font-size:14pt;font-family:標楷體; font-weight: 700;" align="center">
                              戶籍地址</td>
                        <td  colspan="5" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="Lb_RAddress" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td bgcolor="#D9D9D9" colspan="2" >
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體">電話（夜）</p>
                        </td>
                        <td colspan="3" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="Lb_Tel_N" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#D9D9D9" colspan="2"  style="font-size:14pt;font-family:標楷體;" align="center" >電子郵件
                        </td>
                        <td colspan="5" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="Lb_Email" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td bgcolor="#D9D9D9" colspan="2" >
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">手機</span></p>
                        </td>
                        <td colspan="3" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <asp:Label ID="Lb_Mobile_Confirm" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#D9D9D9" colspan="2" style="font-size:14pt;font-family:標楷體;">
                            <p >
                                <b style="mso-bidi-font-weight:normal"><u>
                                <span >現在</span></u></b>就讀（畢）學校</span>
                        </td>
                        <td colspan="5" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <p >學校名稱：<asp:Label ID="Lb_School" runat="server" Text="Label"></asp:Label>
                                </p>
                            <p >科系：<asp:Label ID="Lb_Dep" runat="server" Text="Label"></asp:Label>
                             </p>
                            <p >年級：<asp:Label ID="Lb_Grade_Confirm" runat="server" Text="Label"></asp:Label>
                              </p>
                        </td>
                        <td bgcolor="#D9D9D9" colspan="2" >
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;
  ">申請次數<span lang="EN-US"><o:p></o:p></span></span></p>
                        </td>
                        <td colspan="3" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <p ><asp:Label ID="lbFirst" runat="server" Text="□"></asp:Label>初次申請</p>
                            <p ><asp:Label ID="lbMulti" runat="server" Text="□"></asp:Label>多次申請</p><br />
                        </td>
                    </tr>                    
                <tr><td colspan="3" bgcolor="#D9D9D9"  style="font-size:14pt;font-family:標楷體;" align="center">申請組別<br />(以成績單年級勾選)</td>
                    <td colspan="10"  style="font-size:14pt;font-family:標楷體;" ><asp:Label ID="lbClass1" runat="server" Text="□"></asp:Label>國小組   <asp:Label ID="lbClass2" runat="server" Text="□"></asp:Label>國中組   <asp:Label ID="lbClass3" runat="server" Text="□"></asp:Label>高中組   <asp:Label ID="lbClass4" runat="server" Text="□"></asp:Label>大專組(不含五專1~3年級)   <asp:Label ID="lbClass5" runat="server" Text="□"></asp:Label>研究所碩士班   <asp:Label ID="lbClass6" runat="server" Text="□"></asp:Label>博士班
                </td></tr>
                    </table>
            </td>
        </tr>
        <tr><td>
        <table border="1" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td bgcolor="#D9D9D9" style="font-size:14pt;font-family:標楷體;" rowspan="6">
                            <p align="center" >申︵</p>
                            <p align="center" >請詳</p>
                            <p align="center" >獎見</p>
                            <p align="center" >項申</p>
                            <p align="center" >︵請</p>
                            <p align="center">勾簡</p>
                            <p align="center" >選章</p>
                            <p align="center" >一︶</p>
                            <p align="center" >種&nbsp;&nbsp;</p>
                            <p align="center" >︶&nbsp;&nbsp;</p>
                        </td>
                        <td style="font-size:17pt;font-family:標楷體;padding-left: 5px;">
                                    <asp:Label ID="lblAward1" runat="server" Text="■" Visible="False"></asp:Label></td>
                        <td style="font-size:14pt;font-family:標楷體;padding-left: 5px;" colspan="7">(一)特殊才藝優秀獎學金
                        </td>
                        <td colspan="4" rowspan="6" width="33%">
                            <table border="1" cellpadding="0" cellspacing="0"  width="100%" style="height: 100%">                                
                                <tr>
                                    <td align="center" bgcolor="#D9D9D9"><span style="font-size:14pt;font-family:標楷體;">損傷</span></p>
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體;">類別</span></p>
                            &nbsp;</td>
                                    <td colspan="5" style="padding-left: 5px;">
                            <p >
                                <asp:Label ID="lbD1" runat="server" Text="□"></asp:Label><span style="font-size:14pt;
  font-family:標楷體">灼燙傷</span></p>
                            <p >
                                <asp:Label ID="lbD20" runat="server" Text="□"></asp:Label><span style="font-size:14pt;font-family:標楷體">顏面損傷(請務必勾選下列類別)</span></p>
                            <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>
                                <asp:Label ID="lbD21" runat="server" Text="□"></asp:Label>
&nbsp;1.</span><span 
                                    style="font-size:14pt;font-family:標楷體">顱顏畸型<span lang="EN-US">(</span>含小耳症<span 
                                    lang="EN-US">)<o:p></o:p></span></span></p>
                            <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>
                                <asp:Label ID="lbD22" runat="server" Text="□"></asp:Label>
&nbsp;2.</span><span 
                                    style="font-size:14pt;font-family:標楷體">腫瘤病變<span lang="EN-US">(</span>含血管瘤<span 
                                    lang="EN-US">)<o:p></o:p></span></span></p>
                            <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>
                                <asp:Label ID="lbD23" runat="server" Text="□"></asp:Label>
&nbsp;3.</span><span 
                                    style="font-size:14pt;font-family:標楷體">口腔癌<span lang="EN-US"><o:p></o:p></span></span></p>
                            <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>
                                <asp:Label ID="lbD24" runat="server" Text="□"></asp:Label>
&nbsp;4.</span><span 
                                    style="font-size:14pt;font-family:標楷體">嚴重外傷<span lang="EN-US"><o:p></o:p></span></span></p>
                            <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>
                                <asp:Label ID="lbD25" runat="server" Text="□"></asp:Label>
&nbsp;5.</span><span 
                                    style="font-size:14pt;font-family:標楷體">皮膚病變<span lang="EN-US">(</span>含魚鱗癬</span><span style="font-size:14pt;
  font-family:標楷體">症、胎記、太田母斑<span lang="EN-US">)<o:p></o:p></span></span></p>
                            <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp; </span>
                                <asp:Label ID="lbD26" runat="server" Text="□"></asp:Label>
&nbsp;6.</span><span 
                                    style="font-size:14pt;font-family:標楷體">其他<asp:Label ID="lbD26Other" 
                                    runat="server" Text="___________" Font-Underline="True"></asp:Label>
                                </span></p>
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td style="font-size:17pt;font-family:標楷體;padding-left: 5px;">
                                    <asp:Label ID="lblAward2" runat="server" Text="■" Visible="False"></asp:Label></td>
                        <td style="font-size:14pt;font-family:標楷體;padding-left: 5px;"  colspan="7">
                             (二)優  秀  獎  學  金</td>
                    </tr>
                    <tr>
                        <td style="font-size:17pt;font-family:標楷體;padding-left: 5px;">
                                    <asp:Label ID="lblAward3" runat="server" Text="■" Visible="False"></asp:Label></td>
                        <td style="font-size:14pt;font-family:標楷體;padding-left: 5px;"  colspan="7">
                             (三)升  學  獎  學  金</td>
                    </tr>
                    <tr>
                        <td style="font-size:17pt;font-family:標楷體;padding-left: 5px;">
                                    <asp:Label ID="lblAward4" runat="server" Text="■" Visible="False"></asp:Label></td>
                        <td style="font-size:14pt;font-family:標楷體;padding-left: 5px;"  colspan="7">
                             (四)助      學      金</td>
                    </tr>
                    <tr>
                        <td style="font-size:17pt;font-family:標楷體;padding-left: 5px;">
                                    <asp:Label ID="lblAward5" runat="server" Text="■" Visible="False"></asp:Label></td>
                        <td style="font-size:14pt;font-family:標楷體;padding-left: 5px;"  colspan="4">
                                <p>
                                <span style="font-size:14pt;font-family: 標楷體">(五)勇源-陽光子女助學金</span></p>
                            </td>
                        <td style="font-size:14pt;font-family:標楷體;padding-left: 5px;" rowspan="2"  colspan="3">
                             損傷者姓名(必填)<br />
                             <asp:Label ID="lbFather" runat="server" Text="□"></asp:Label>父:<span 
                                    style="font-size:14pt;font-family:標楷體"><asp:Label ID="lbFatherName" runat="server" Text="___________"></asp:Label>
                                </span>或<br />
                             <asp:Label ID="lbMonther" runat="server" Text="□"></asp:Label>母:<span 
                                    style="font-size:14pt;font-family:標楷體"><asp:Label ID="lbMontherName" runat="server" Text="___________"></asp:Label>
                                </span>
                             </td>
                    </tr>
                    <tr>
                        <td style="font-size:17pt;font-family:標楷體;padding-left: 5px;">
                                    <asp:Label ID="lblAward6" runat="server" Text="■" Visible="False"></asp:Label></td>
                        <td style="font-size:14pt;font-family:標楷體;padding-left: 5px;"  colspan="4" >
                             (六)明閱科技-陽光子女特殊才藝獎學金</td>
                    </tr>
                            </table>
        </td>
        </tr>
        <tr><td><table border="1" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                        <td bgcolor="#D9D9D9" style="font-size:14pt;font-family:標楷體;" width="5%">
                            <p align="center" >申</p>
                            <p align="center" >請</p>
                            <p align="center" >人</p>
                        </td>
                        <td colspan="12" style="padding-left: 5px;">
                            <p >
                                <span style="font-size:14pt;font-family:標楷體;">
                                <asp:Label ID="lbSelfApply" runat="server" Text="□"></asp:Label>
                                自行申請</span></p>
                            <p >
                                <span style="font-size:14pt;font-family:標楷體;">
                                <asp:Label ID="lbRecApply" runat="server" Text="□"></asp:Label>
                                推薦單位：<asp:Label ID="Lb_recommend" runat="server" Text="__________"></asp:Label>
                                &nbsp;&nbsp;推薦人姓名：<asp:Label ID="Lb_Rec_Name" runat="server" Text="__________"></asp:Label>
                                &nbsp;&nbsp;推薦人職務：<asp:Label ID="Lb_Rec_Position" runat="server" Text="__________"></asp:Label>
                                &nbsp;&nbsp;電話：<asp:Label ID="Lb_Rec_Tel" runat="server" Text="__________"></asp:Label>
                                </span>
                            </p>
                        </td>
            </tr></table></td></tr>
        <tr>
            <td>
                <table border="1" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                <table border="1" cellpadding="0" cellspacing="0" width="100%">
<tr>
                        <td bgcolor="#D9D9D9" colspan="1">
                            <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體">帳戶資料<span lang="EN-US"><o:p></o:p></span></span></p>
                            <p align="center" >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">(</span><span 
                                    style="font-size:14pt;font-family:標楷體">請填申請人資料<span lang="EN-US">)<o:p></o:p></span></span></p>
                        </td>
                        <td colspan="4" style="font-size:17pt;font-family:標楷體; padding-left: 5px;">
                            <p >銀行代碼：<asp:Label ID="Lb_Bank_No" runat="server" Text="_______________"></asp:Label>
&nbsp;帳號：<asp:Label ID="Lb_Account" runat="server" Text="_______________"></asp:Label>                                
                            </p>
                            <p >戶名：<asp:Label ID="Lb_Account_Name" runat="server" Text="_______________"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    </table>
                        
                            </td>
                    </tr>
                    
                    <tr><td><table border="3" cellpadding="0" cellspacing="0" width="100%" style="padding-left: 5px;">
                                        <tr><td colspan="15" align="center"  style="font-size:14pt;font-family:標楷體" >附         件        名        稱 (本欄粗框內為審核欄，申請者免填)<br /></td></tr>
                                        <tr>
                        <td rowspan="4" style="font-size:14pt;font-family:標楷體;" align="center" colspan="2">收件紀錄</td>
                        <td colspan="13">
                            <p >
                                <span lang="EN-US" style="font-size: 14pt; font-family: 標楷體"><span style="mso-spacerun:yes">□</span></span><span style="font-size:14pt;font-family:標楷體">資料齊全 <span lang="EN-US"><o:p></o:p></span></span>
                            </p>
                            <p >
                                <span style="font-size:14pt;
  font-family:標楷體">□資料未齊備：<span lang="EN-US" style="font-size: 14pt; font-family: 標楷體"><span style="mso-spacerun:yes">□</span></span></span><span 
                                    lang="EN-US" style="font-size:14pt;font-family:標楷體">1</span><span 
                                    style="font-size:14pt;font-family:標楷體">、本會申請書<span lang="EN-US"><span 
                                    style="mso-spacerun:yes">&nbsp;&nbsp; □</span></span></span><span lang="EN-US" style="font-size:14pt;font-family:標楷體">2</span><span style="font-size:14pt;
  font-family:標楷體">、成績單<span lang="EN-US"><span style="mso-spacerun:yes">&nbsp;&nbsp;<span lang="EN-US" style="font-size: 14pt; font-family: 標楷體">□</span></span></span></span><span 
                                    lang="EN-US" style="font-size:14pt;font-family:標楷體">3</span><span 
                                    style="font-size:14pt;font-family:標楷體">、自傳<span lang="EN-US"><span 
                                    style="mso-spacerun:yes">&nbsp; □</span></span></span><span lang="EN-US" style="font-size:14pt;font-family:標楷體">4</span><span style="font-size:14pt;
  font-family:標楷體">、損傷證明文件 <span lang="EN-US"><o:p></o:p></span></span>
                            </p>
                            <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                □</span>5</span><span style="font-size:14pt;
  font-family:標楷體">、近三個月內戶籍謄本<span lang="EN-US"><span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                □</span></span></span><span lang="EN-US" style="font-size:14pt;font-family:標楷體">6</span><span style="font-size:14pt;
  font-family:標楷體">、特殊才藝得獎證明<span lang="EN-US"><o:p></o:p></span></span></p>
  <p >
                                <span lang="EN-US" style="font-size:14pt;font-family:標楷體">
                                <span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                □</span>7</span><span style="font-size:14pt;
  font-family:標楷體">、學生證影本or在學證明書正本</span></p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="13">
                            <br />
                            <p >
                                <span style="font-size:14pt;font-family:標楷體">閱件日期：<span lang="EN-US"><o:p></o:p></span></span></p>
                        </td>
                    </tr>
                    <tr >
                        <td colspan="13"><br /><p>
                                <span style="font-size:14pt;font-family:標楷體">備註：</span><u><span lang="EN-US" 
                                    style="mso-bidi-font-size:12.0pt;font-family:標楷體"><span 
                                    style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp; </span></span></u>
                                <span style="font-size:14pt;font-family:標楷體">年<u><span lang="EN-US"><span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp; </span>
                                </span></u>月<u><span lang="EN-US"><span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;
                                </span></span></u>日，通知補件方式：□</span><span style="font-size:14pt;
  font-family:標楷體">電話 □</span><span 
                                    style="font-size:14pt;font-family:標楷體">簡訊 □</span><span lang="EN-US" style="font-size:14pt;font-family:標楷體">e-mail</span></p></td>
                    </tr>
                    <tr>
                        <td colspan="13">
                        </br>
                            <p><span style="font-size:14pt;font-family:標楷體">補件日期：</span></p></td>
                    </tr>
                    </table>
                    </td></tr>
                    <tr><td>                <table border="3" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td rowspan="2" style="font-size:14pt;font-family:標楷體;" align="center" colspan="2">
                              審核結果
                        </td>
                        <td colspan="13" style="font-size:14pt;font-family:標楷體">
                            <br /><p>
                                <span >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;□ 通　過&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;□ 未　通　過，原因：</span><u><span 
                                    lang="EN-US" style="font-size:14pt;font-family:標楷體;mso-hansi-font-family:
  華康細圓體"><span style="mso-spacerun:yes">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </span></span></u></p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" ><br />
                            <p align="center" >
                                <span style="font-size:14pt;font-family: 標楷體">初　審</span>&nbsp;</p><br />
                        </td>
                        <td colspan="4"></td>
                        <td colspan="2"><br />
                        <p align="center" >
                                <span style="font-size:14pt;font-family:標楷體">複　審</span></p><br />
                            </td>
                        <td colspan="5">&nbsp;<br /></td>
                    </tr>
                    </table>
                    </td></tr>
                    <tr>
                        <td style="font-size:14pt">
                            <p>
                           <span lang="EN-US" style="font-size:14pt;">一. </span><span style="font-size:14pt;font-family: 標楷體">申請期間：<b style="mso-bidi-font-weight:normal"><u><span style="font-size:14pt; font-family: &quot;新細明體&quot;,&quot;serif&quot;; mso-ascii-font-family: &quot;Arial Black&quot;; mso-hansi-font-family: &quot;Arial Black&quot;; mso-bidi-font-family: &quot;Times New Roman&quot;; background: #D9D9D9; mso-shading: white; mso-pattern: gray-15 auto; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-TW; mso-bidi-language: AR-SA">即日起</span><span lang="EN-US" style="font-family: &quot;Arial Black&quot;,&quot;sans-serif&quot;; mso-fareast-font-family: Gungsuh; mso-bidi-font-family: &quot;Times New Roman&quot;; background: #D9D9D9; mso-shading: white; mso-pattern: gray-15 auto; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-TW; mso-bidi-language: AR-SA">~</span><span lang="EN-US" style="font-family: &quot;Arial Black&quot;,&quot;sans-serif&quot;; mso-fareast-font-family: 新細明體; mso-bidi-font-family: &quot;Times New Roman&quot;; background: #D9D9D9; mso-shading: white; mso-pattern: gray-15 auto; mso-font-kerning: 1.0pt; mso-ansi-language: EN-US; mso-fareast-language: ZH-TW; mso-bidi-language: AR-SA">09/30</span></u></b></span><span style="font-family:標楷體">，以郵戳為憑，<b style="mso-bidi-font-weight:normal"><u>逾期恕不受理</u></b></span>。<span lang="EN-US"></span></span></p>
                            <p >
                                <![if !supportLists]>
                                <span lang="EN-US" style="font-size:14pt;mso-fareast-font-family:標楷體;mso-bidi-font-family:
  標楷體"><span style="mso-list:Ignore">二.</span></span><![endif]><span style="font-size:14pt;font-family:標楷體"> 多次申請者，若曾有更改姓名之況，請特別註明<span lang="EN-US">(</span>新名<span lang="EN-US">&amp;</span>舊名<span lang="EN-US">)</span>以方便作業。<span 
                                    lang="EN-US"><o:p></o:p></span></span></p>
                            <p >
                                <![if !supportLists]>
                                <span lang="EN-US" style="font-size:14pt;mso-fareast-font-family:標楷體;mso-bidi-font-family:
  標楷體"><span style="mso-list:Ignore">三. </span></span><![endif]>
                                <span style="font-size:14pt;font-family:
  標楷體">畢<span lang="EN-US">/</span>肄業學校及系別請詳細寫明，不得簡寫，如係分部、分校或夜間部及補校學生亦請詳細寫明。<span lang="EN-US"><o:p></o:p></span></span></p>
                            <p >
                                <![if !supportLists]>
                                <span lang="EN-US" style="font-size:14pt;mso-fareast-font-family:標楷體;mso-bidi-font-family:
  標楷體"><span style="mso-list:Ignore">四. </span></span><![endif]>
                                <span style="font-size:14pt;font-family:
  標楷體"><span style="font-size:14pt;font-family:標楷體;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-TW;mso-bidi-language:AR-SA">成績單務必加註成績分數，如為影本請 <b style="mso-bidi-font-weight:normal"><u>加蓋學校證明章。</u></b></span></span></p>
                            <p >
                                <![if !supportLists]>
                                <span lang="EN-US" style="font-size:14pt;mso-fareast-font-family:標楷體;mso-bidi-font-family:
  標楷體"><span style="mso-list:Ignore">五. </span></span><![endif]>
                                <span style="font-size:14pt;font-family:
  標楷體"><span style="font-size:14.0pt;font-family:標楷體;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-TW;mso-bidi-language:AR-SA">檢附資料時，請依上欄「應附文件」順序排列。各項證件請不要用訂書機裝訂，無關資料免送。申請文件建議以<b style="mso-bidi-font-weight:normal"><u>掛號</u></b>方式寄送，以免遺失造成困擾。</span></span></p>
                            <p >
                                <![if !supportLists]>
                                <span lang="EN-US" style="font-size:14pt;mso-fareast-font-family:標楷體;mso-bidi-font-family:
  標楷體"><span style="mso-list:Ignore">六. </span></span><![endif]>
                                <span style="font-size:14pt;font-family:
  標楷體;"><span style="font-size:14pt;font-family:標楷體;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-TW;mso-bidi-language:AR-SA">請參閱本會「獎助學金申請簡章」後再填寫申請書，相關資訊歡迎上本會網頁查詢，網址<span lang="EN-US">:www.sunshine.org.tw</span></span></span></p>
                            <p >
                                <![if !supportLists]>
                                <span lang="EN-US" style="font-size:14pt;mso-fareast-font-family:標楷體;mso-bidi-font-family:
  標楷體"><span style="mso-list:Ignore">七. </span></span><![endif]>
                                <span style="font-size:14pt;font-family:標楷體;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-font-kerning:1.0pt;mso-ansi-language:
EN-US;mso-fareast-language:ZH-TW;mso-bidi-language:AR-SA">備妥文件請寄：<b style="mso-bidi-font-weight:normal"><u><span lang="EN-US">81358</span>高雄市左營區安吉街<span lang="EN-US">449</span>號，電話：<span lang="EN-US">(07)558-7166</span>，南區中心 高嘉穗、林鈺蕙小姐</u></b></span></p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        </table>

