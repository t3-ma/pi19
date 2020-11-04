using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using pi191_03CL.Model;
using pi191_03CL.Model2;
using pi191_03CL.ModelXO;
using Newtonsoft.Json;

namespace pi191_03CA
{
  class Program
  {
    private static Field m_pField;

    static void Main(string[] args)
    {
      m_pField = new Field(true);

      // h_TestPolymorph();
      // h_TestMailServer();
      // Console.ReadKey();
      //h_TestXO();

      //h_TestIO();
      //h_TestStream();
      h_Xml();
    }

    private static void h_Xml()
    {
      #region DOM
      // DOM - Document object model
      XmlDocument pX = new XmlDocument();
      pX.Load("XMLFile1.xml");
      XmlNodeList arNodes = pX.SelectNodes("//root/array/item");
      foreach (XmlNode pNode in arNodes) {
        XmlAttribute pAttr = pNode.Attributes[0];
        pAttr.Value += "2";
      }
      pX.Save("XMLFile2.xml");
      // XmlNode arParentNode = pX.SelectSingleNode("//root/array");
      // arParentNode.AppendChild(new XmlElement());
      // new XmlNode(arParentNode)
      #endregion

      #region SAX
      // SAX - Simple API XML 
      // + writer
      using (MemoryStream pMs = new MemoryStream()) {
        XmlWriterSettings pSt = new XmlWriterSettings()
        {
          Indent = true,
        };
        using (XmlWriter pW = XmlWriter.Create(pMs, pSt)) {
          pW.WriteStartDocument();
          // --- root
          h_WriteRoot(pW);
          pW.WriteEndDocument();

          pW.Flush();

          pMs.Seek(0, SeekOrigin.Begin);
          File.WriteAllBytes("XMLFile3.xml", pMs.ToArray());
        }
      }
      // + reader
      using (Stream pMs = File.OpenRead("XMLFile3.xml")) {
        using (XmlReader pR = XmlReader.Create(pMs)) {
          // pR.MoveToElement("root");
          while (pR.Read()) {
            if (pR.NodeType == XmlNodeType.Element) {
              if (pR.Name == "root") {
                h_ReadRoot(pR);
                // --- root
              }
            }
          }
        }
      }
      #endregion

      #region XmlSerializer

      // Стандартную сериализацию в XML - подходит, когда нет жестких требований к структуре
      // сериализация
      Field pF = new Field(true);
      // объект должен удовлетворять требованиям:
      //    должен быть конструктор по умолчанию (без параметров)
      using (Stream pFs = File.Create("XMLFile.Serializer.xml")) {
        XmlSerializer pXmlSerializer = new XmlSerializer(typeof(Field));
        pXmlSerializer.Serialize(pFs, pF);
      }
      // десериализация
      using (Stream pFs = File.OpenRead("XMLFile.Serializer.xml")) {
        XmlSerializer pXmlSerializer = new XmlSerializer(typeof(Field));
        Field pF2 = (Field)(pXmlSerializer.Deserialize(pFs));
      }
      #endregion

      #region JSON
      // .....
      // JSON
      // ....
      // + JsonSerializer
      using (TextWriter pT = File.CreateText("JsonFile.Serializer.json")) {
        var pJson = JsonSerializer.Create();
        pJson.Serialize(pT, pF);
      }
      // pJson.Deserialize()
      #endregion
    }

    private static void h_ReadRoot(XmlReader pR)
    {
      string sValue = pR.GetAttribute("title");
      string sVersion = pR.GetAttribute("version");
      while (pR.Read()) {
        if (pR.NodeType == XmlNodeType.Element) {
          if (pR.Name == "array") {
            // var xNewReader = pR.ReadSubtree();

            // --- array
            // h_ReadArray(pR);
            // --- /array
          }
        }
      }

    }

    private static void h_WriteRoot(XmlWriter pW)
    {
      pW.WriteStartElement("root");

      pW.WriteAttributeString("version", "1");
      pW.WriteAttributeString("title", "test");

      // -- array
      pW.WriteStartElement("array");
      h_WriteArrayItem(pW);
      // -- /array
      pW.WriteEndElement();

      // --- /root
      pW.WriteEndElement();
    }

    private static void h_WriteArrayItem(XmlWriter pW)
    {
      // ...
    }

    private static void h_TestStream()
    {
      using (FileStream pFs = File.Create("$data1.txt")) {
        using (MemoryStream pMs = new MemoryStream()) {
          // pMs.WriteByte(32);
          // pMs.Seek(0, SeekOrigin.Begin);
          using (StreamWriter pSw = new StreamWriter(pMs)) {
            pSw.WriteLine(" ");
          }
          pMs.Seek(0, SeekOrigin.Begin);
          pMs.CopyTo(pFs);
        }
      }
    }

    private static void h_TestIO()
    {
      /*
       // Информационные классы: DirectoryInfo, FileInfo, Path, DriveInfo
      // DirectoryInfo pDi = new DirectoryInfo(".");
      FileInfo pFi = new FileInfo(typeof(Program).Assembly.Location);
      // Path.Combine("d:\\", "1", "2"); // d:\1\2\
      string sExeName = typeof(Program).Assembly.Location;
      string sExeDir = Path.GetDirectoryName(sExeName);
      string sExeDirPlus = Path.Combine(sExeDir, "../data");
      string sTxtFn = Path.ChangeExtension(sExeName, ".txt");
      DriveInfo pDI = new DriveInfo("d");
      */
      // активные: Directory, File
      // Directory
      //  -- создание
      if (!Directory.Exists("$data")) {
        Directory.CreateDirectory("$data");
        // Directory.Delete("$data");
        Directory.Move("$data", "$data2");
      }
      //  -- поиск файлов
      string[] arFiles = Directory.GetFiles("$data", "*.*", SearchOption.AllDirectories);
      foreach (string sFn in arFiles) {
        // ..
      }
      IEnumerable<string> arFilesEnumerate = Directory.EnumerateFiles("$data", "*.*", SearchOption.AllDirectories);
      foreach (string sFn in arFilesEnumerate) {
        // ..
      }

      // File
      if (!File.Exists("$data.txt")) {

        using (FileStream pF = File.Create("$data.txt")) {
          // pF.CanSeek, pF.CanRead, pF.CanWrite
          pF.Seek(0, SeekOrigin.Begin);
          pF.WriteByte(32);
          pF.Seek(0, SeekOrigin.Begin);
          int iBt = pF.ReadByte();
          pF.Close();
        }
        using (StreamWriter pF = File.CreateText("$data.txt")) {
          pF.WriteLine(" ");
          pF.Write(" ");
          pF.Close();
        }
        using (FileStream pP = File.Open("$data.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.Read)) {
        }
        using (StreamReader pP = File.OpenText("$data.txt")) {
          string sLine = pP.ReadLine();
          string sWholeFile = pP.ReadToEnd();
        }


        // Directory.Delete("$data");
        File.Move("$data.txt", "$data2.txt");
      }
      // ----
      File.WriteAllBytes("$data.txt", new byte[] { 32 });
      File.WriteAllText("$data.txt", " ", Encoding.UTF8);
      File.WriteAllLines("$data.txt", new[] { " " }, Encoding.UTF8);

      // ... File.AppendAllLines

      string sTxt = File.ReadAllText("$data.txt", Encoding.UTF8);
      byte[] bt = File.ReadAllBytes("$data.txt");
      string[] arTxt = File.ReadAllLines("$data.txt", Encoding.UTF8);
      // ---
    }

    private static void h_TestXO()
    {
      while (true) {
        h_RefreshFieldXO();
        Console.WriteLine("Enter command...");
        string sCmd = Console.ReadLine();
        if (String.IsNullOrEmpty(sCmd)) {
          break;
        }

        if (sCmd.Equals("s")) {
          m_pField.Save("filename.txt");
          continue;
        }
        else
        if (sCmd.Equals("l")) {
          m_pField.Load("filename.txt");
          continue;
        }

        string[] ar = sCmd.Split(new[] { ',', ';' });
        if (ar.Length != 2) {
          continue;
        }
        int iX, iY;
        if (!Int32.TryParse(ar[0], out iX)) {
          continue;
        }
        if (!Int32.TryParse(ar[1], out iY)) {
          continue;
        }
        m_pField.SetValue(iX, iY);
      }
    }

    private static void h_RefreshFieldXO()
    {
      Console.Clear();
      Console.WriteLine(m_pField.GetInfo());
      ConsoleColor pColor = Console.ForegroundColor;
      foreach (Cell pCell in m_pField.CellList) {
        ConsoleColor pCellColor = pCell.Value == EValue.O ? ConsoleColor.Green : ConsoleColor.White;
        Console.ForegroundColor = pCellColor;
        Console.WriteLine(pCell);
      }
      Console.ForegroundColor = pColor;
    }

    private static void h_TestMailServer()
    {
      TestMailServer pMailServer = new TestMailServer("mail.ru");

      int ii = 0;
      foreach (Mailbox pMb in pMailServer.MailboxList) {
        Console.WriteLine((++ii).ToString());
        Console.WriteLine(pMb.Address);
        Console.WriteLine($"{pMb.GetUnreadCount()} / {pMb.LetterList.Count}");
      }
    }

    private static void h_TestPolymorph()
    {
      Animal pAnimal;
      pAnimal = new Cow();
      h_MakeNoise(pAnimal);
      pAnimal = new Parrot();
      h_MakeNoise(pAnimal);
    }

    private static void h_MakeNoise(Animal pAnimal)
    {
      Console.WriteLine($"{pAnimal.GetType().Name}: {pAnimal.Say()}");
      Console.WriteLine($"{pAnimal.GetType().Name}: {pAnimal.Say("R!")}");
    }
  }
}
