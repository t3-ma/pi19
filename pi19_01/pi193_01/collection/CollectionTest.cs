using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi193_01.collection
{
  public static class CollectionTest
  {

    public static void TestStaticArray()
    {
      string sText = "aaaaa aaa sss d";
      string[] ar = sText.Split(
          new[] { ' ', ',' },
          StringSplitOptions.RemoveEmptyEntries
        );
      string[] ar2 = new string[100];
      foreach(string sWord in ar)
      {
        Console.WriteLine(sWord);
      }
    }

    public static void TestUntypedArray()
    {
      ArrayList ar = new ArrayList();
      ar.Add("qweqwe");
      ar.Add("qweqwe");
      ar.Add("qweqwe");
      ar.Add("");
      ar.RemoveAt(0);
      ar.Remove("");
      ar.Insert(0, "wde");
      ar.Add(123123);
      ar.Add(true);
      ar.Add(ar);

      foreach (object sWord in ar)
      {
        Console.WriteLine(sWord);
      }


    }

    public static void TestTypedArray()
    {
      List<string> ar = new List<string>();
      ar.Add("qweqwe");
      ar.Add("qweqwe");
      ar.Add("qweqwe");
      ar.Add("");
      ar.Insert(0, "wde");

      foreach (string sWord in ar)
      {
        Console.WriteLine(sWord);
      }


    }

  }
}
