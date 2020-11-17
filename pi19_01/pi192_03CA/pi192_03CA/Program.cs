using Newtonsoft.Json;
using pi192_03DLL.Memo;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace pi192_03CA
{
  internal class Program
  {
    private static Field _field;

    private static void Main(string[] args)
    {
      _field = new Field(3, 3);

      AppDomain.CurrentDomain.UnhandledException += h_OnUnhandled;
      // h_Start();
      // h_Xml();

      try {
        try {
          h_Exceptions();
        }
        finally {
          Console.WriteLine("it's over");
        }
      }
      catch {
      }
    }

    private static void h_OnUnhandled(object sender, UnhandledExceptionEventArgs e)
    {
      // ...
    }

    private static void h_Exceptions()
    {
      int[] arInt = new[] { 1, 2, 3, 4, 5, 6, 0, 7, -3, -6 };
      try {
        try {
          h_SumPositive(arInt);

        }
        finally {
          Console.WriteLine("sum is over");
        }
      }
      catch (CNegativeException e) {
        Console.WriteLine($"{e.Message} / {e.Title}");
        throw;
      }
      catch (Exception e) {
        Console.WriteLine($"{e.Message}...");
        throw;
      }
    }

    private static long h_SumPositive(int[] arInt)
    {
      long result = 0;
      for (int ii = 0; ii < arInt.Length; ii++) {
        if (arInt[ii] < 0) {
          throw new CNegativeException(ii.ToString());
        }
        if (arInt[ii] == 0) {
          throw new CZeroException();
        }

        result += arInt[ii];
      }

      return result;
    }

    private static void h_Start()
    {
      while (true) {
        h_DrawField();
        Console.WriteLine("Enter command..");
        string sCmd = Console.ReadLine();
        if (String.IsNullOrEmpty(sCmd)) {
          break;
        }

        if (sCmd.Equals("s")) {
          _field.Save($"{DateTime.Now:yyyy.MM.dd}.txt");
          continue;
        }
        if (sCmd.Equals("l")) {
          _field.Load($"{DateTime.Now:yyyy.MM.dd}.txt");
          continue;
        }

        string[] ar = sCmd.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (ar.Length != 2) {
          continue;
        }
        int iN1, iN2;
        if (!Int32.TryParse(ar[0], out iN1)) {
          continue;
        }
        if (!Int32.TryParse(ar[1], out iN2)) {
          continue;
        }

        _field.Click(new Coord(iN1, iN2));
      }
    }

    private static void h_DrawField()
    {
      Console.Clear();
      ConsoleColor pCurrentColor = Console.ForegroundColor;
      foreach (Card pCard in _field.CardList) {
        if (pCard.IsFound) {
          Console.ForegroundColor = ConsoleColor.Black;
        }
        else {
          Console.ForegroundColor = pCard.IsOpened ? ConsoleColor.White : ConsoleColor.DarkGray;
        }
        Console.WriteLine(pCard);
      }
      Console.ForegroundColor = pCurrentColor;
    }


    #region XML
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
      // объект должен удовлетворять требованиям:
      //    должен быть конструктор по умолчанию (без параметров)
      using (Stream pFs = File.Create("XMLFile2.Serializer.xml")) {
        XmlSerializer pXmlSerializer = new XmlSerializer(typeof(Field));
        pXmlSerializer.Serialize(pFs, _field);
      }
      // десериализация
      using (Stream pFs = File.OpenRead("XMLFile2.Serializer.xml")) {
        XmlSerializer pXmlSerializer = new XmlSerializer(typeof(Field));
        Field pF2 = (Field)(pXmlSerializer.Deserialize(pFs));
      }
      #endregion

      #region JSON
      // .....
      // JSON
      // ....
      // + JsonSerializer
      using (TextWriter pT = File.CreateText("JsonFile2.Serializer.json")) {
        var pJson = JsonSerializer.Create();
        pJson.Serialize(pT, _field);
        // pJson.Deserialize()
      }
      #endregion
    }

    private static void h_ReadRoot(XmlReader pR)
    {
      string sValue = pR.GetAttribute("title");
      string sVersion = pR.GetAttribute("version");
      if (sVersion == "1") {
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
      for (int ii = 0; ii < 10; ii++) {
        pW.WriteStartElement("item");
        // pW.WriteElementString("item", (++ii).ToString());
        pW.WriteAttributeString("id", ii.ToString());
        pW.WriteAttributeString("title", ii.ToString());
        pW.WriteEndElement();
      }
    }
    #endregion
  }
}
