using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public class PDF : System.Web.UI.Page
{
    public void Save(String strHTML,String strFileName)
    {
        {
            MemoryStream outputStream = new MemoryStream();//要把PDF寫到哪個串流
            byte[] data = System.Text.Encoding.UTF8.GetBytes(strHTML);//字串轉成byte[]
            MemoryStream st = new MemoryStream(data);

            //Stream st =  strHTML;
            //String st = Server.MapPath("/") + "Pages\\pdf.html";
            //String st_out = Request.PhysicalApplicationPath + "Pages\\test.pdf";
            String st_out = Server.MapPath("") + "\\" + strFileName + ".pdf";
            //讀取html檔,由於html檔的儲存內容編碼是utf-8,此處StreamReader編碼設定為utf-8
            StreamReader sr = new StreamReader(st, System.Text.Encoding.UTF8);
            //StreamReader sr = new StreamReader(st);

            //建立Document,HTMLWorker及PdfWriter物件,並指定寫出PDF檔的路徑
            //文件格式為橫式A4,若建構式不加引數,預設為直式A4
            Document doc = new Document(PageSize.A3);
            HTMLWorker hw = new HTMLWorker(doc);
            PdfWriter.GetInstance(doc, new FileStream(st_out,
            System.IO.FileMode.Create));

            //取得作業系統中有安裝的字型,通常在C:\WINDOWS\Fonts目錄下
            //取"windir"這一個環境變數,設定為C:\WINDOWS
            //若要觀看字型檔案的檔名,在C:\WINDOWS\Fonts目錄中以滑鼠右鍵點選檔案並按下內容
            //tc  不使用此字型
            //FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
            //@"\Fonts\simhei.ttf");//SimHei字體(中易黑體)
            FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
            @"\Fonts\MINGLIU.TTC");//細明體 & 新細明體
            FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
            @"\Fonts\KAIU.TTF");//標楷體

            //建立樣式格式
            StyleSheet style = new StyleSheet();
            //設定html tag應用什麼樣式來解析
            //根據測試,LoadTagStyle(...)的參數意思如下:
            //第一個參數: html標籤名稱
            //第二個參數: 屬性名稱,目前解讀如下:
            //            "face" 使用的字型(但要先取得系統字型)
            //            "encoding" 字型編碼,Identity-H代表
            //            The Unicode encoding with horizontal writing.
            //            "leading" 列的高度

            //目前測試,標楷體尚無法寫出
            /*
            style.LoadTagStyle("body", "face", "KAIU");
            style.LoadTagStyle("body", "encoding", "Identity-H");
            style.LoadTagStyle("body", "leading", "50,0");
            */

            //body tag設定
            style.LoadTagStyle("body", "face", "SIMHEI");
            style.LoadTagStyle("body", "encoding", "Identity-H");
            style.LoadTagStyle("body", "leading", "12,0");

            //td tag設定,會蓋過body tag的設定
            style.LoadTagStyle("td", "face", "MINGLIU");
            style.LoadTagStyle("td", "encoding", "Identity-H");
            style.LoadTagStyle("td", "leading", "18,0");

            //開啟Document文件,並使用HTMLWorker解析html檔案的輸入串流後,匯出PDF檔
            doc.Open();

            //根據iTextSharp的解析,html的tag會解析成不同的iTextSharp物件,
            //ParseToList(...)第一個引數為html文件的輸入串流,第二個引數為樣式設定
            List<IElement> htmlElement = HTMLWorker.ParseToList(sr, style);
            for (int i = 0; i < htmlElement.Count; i++)
            {
                //以這一份html檔,iTextSharp將其解讀為iTextSharp.text.Paragraph與
                //iTextSharp.text.pdf.PdfPTable物件
                System.Console.WriteLine("第" + (i + 1) + "個物件為: " + htmlElement[i]);
                //將每個被HTMLWorker解析的物件加到Document物件中
                doc.Add(htmlElement[i]);
            }

            doc.Close();
            sr.Close();

            //tc  PDF產生完後，另外產生 .f 檔做記錄。
            String st_finish = Server.MapPath("") + "\\" + strFileName + ".f";
            FileStream fileStream = new FileStream(st_finish, FileMode.Create);
            fileStream.Close();   //切記開了要關,不然會被佔用而無法修改喔!!!

            System.Console.WriteLine("匯出PDF成功");
            System.Console.ReadLine();
        }
    }

    public void SaveFromFile(String strFileHTML, String strFileName)
    {
        {
            //MemoryStream outputStream = new MemoryStream();//要把PDF寫到哪個串流
            //byte[] data = System.Text.Encoding.UTF8.GetBytes(strHTML);//字串轉成byte[]
            //MemoryStream st = new MemoryStream(data);

            //Stream st =  strHTML;
            String st = Server.MapPath("") + "\\"+strFileHTML;
            //String st_out = Request.PhysicalApplicationPath + "Pages\\test.pdf";
            String st_out = Server.MapPath("") + "\\" + strFileName + ".pdf";
            //讀取html檔,由於html檔的儲存內容編碼是utf-8,此處StreamReader編碼設定為utf-8
            StreamReader sr = new StreamReader(st, System.Text.Encoding.UTF8);
            //StreamReader sr = new StreamReader(st);

            //建立Document,HTMLWorker及PdfWriter物件,並指定寫出PDF檔的路徑
            //文件格式為橫式A4,若建構式不加引數,預設為直式A4
            Document doc = new Document(PageSize.A3);
            HTMLWorker hw = new HTMLWorker(doc);
            PdfWriter.GetInstance(doc, new FileStream(st_out,
            System.IO.FileMode.Create));

            //取得作業系統中有安裝的字型,通常在C:\WINDOWS\Fonts目錄下
            //取"windir"這一個環境變數,設定為C:\WINDOWS
            //若要觀看字型檔案的檔名,在C:\WINDOWS\Fonts目錄中以滑鼠右鍵點選檔案並按下內容
            FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
            @"\Fonts\simhei.ttf");//SimHei字體(中易黑體)
            FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
            @"\Fonts\MINGLIU.TTC");//細明體 & 新細明體
            FontFactory.Register(System.Environment.GetEnvironmentVariable("windir") +
            @"\Fonts\KAIU.TTF");//標楷體

            //建立樣式格式
            StyleSheet style = new StyleSheet();
            //設定html tag應用什麼樣式來解析
            //根據測試,LoadTagStyle(...)的參數意思如下:
            //第一個參數: html標籤名稱
            //第二個參數: 屬性名稱,目前解讀如下:
            //            "face" 使用的字型(但要先取得系統字型)
            //            "encoding" 字型編碼,Identity-H代表
            //            The Unicode encoding with horizontal writing.
            //            "leading" 列的高度

            //目前測試,標楷體尚無法寫出
            /*
            style.LoadTagStyle("body", "face", "KAIU");
            style.LoadTagStyle("body", "encoding", "Identity-H");
            style.LoadTagStyle("body", "leading", "50,0");
            */

            //body tag設定
            style.LoadTagStyle("body", "face", "SIMHEI");
            style.LoadTagStyle("body", "encoding", "Identity-H");
            style.LoadTagStyle("body", "leading", "12,0");

            //td tag設定,會蓋過body tag的設定
            style.LoadTagStyle("td", "face", "MINGLIU");
            style.LoadTagStyle("td", "encoding", "Identity-H");
            style.LoadTagStyle("td", "leading", "18,0");

            //開啟Document文件,並使用HTMLWorker解析html檔案的輸入串流後,匯出PDF檔
            doc.Open();

            //根據iTextSharp的解析,html的tag會解析成不同的iTextSharp物件,
            //ParseToList(...)第一個引數為html文件的輸入串流,第二個引數為樣式設定
            List<IElement> htmlElement = HTMLWorker.ParseToList(sr, style);
            for (int i = 0; i < htmlElement.Count; i++)
            {
                //以這一份html檔,iTextSharp將其解讀為iTextSharp.text.Paragraph與
                //iTextSharp.text.pdf.PdfPTable物件
                System.Console.WriteLine("第" + (i + 1) + "個物件為: " + htmlElement[i]);
                //將每個被HTMLWorker解析的物件加到Document物件中
                doc.Add(htmlElement[i]);
            }

            doc.Close();
            sr.Close();

            //tc  PDF產生完後，另外產生 .f 檔做記錄。
            String st_finish = Server.MapPath("") + "\\" + strFileName + ".f";
            FileStream fileStream = new FileStream(st_finish, FileMode.Create);
            fileStream.Close();   //切記開了要關,不然會被佔用而無法修改喔!!!

            System.Console.WriteLine("匯出PDF成功");
            System.Console.ReadLine();
        }
    }    
}

