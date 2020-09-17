using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi192_02
{
  class Program
  {
    static void Main(string[] args)
    {
      // h_TestArray();
      // h_TestArrayList();
      h_TestList();
      Console.ReadKey();
    }

    private static void h_TestList()
    {
      // демонстрация работы с нетипизированными массивами
      List<string> ar = null;
      ar = new List<string>();

      ar.Add("qweqweqwe");
      ar.Add("123");
      ar.Insert(0, "1");
      ar.RemoveAt(1);
      ar.Remove("123");

      int iMaxLen = 0;
      for (int i = 0; i < ar.Count; i++)
      {
        string sWord = ar[i];
        if (sWord.Length > iMaxLen)
        {
          iMaxLen = sWord.Length;
        }
        Console.WriteLine(sWord);
      }
      Console.WriteLine($"Max length is {iMaxLen}");

    }

    private static void h_TestArray()
    {
      // демонстрация работы с массивами
      string[] arWords1;
      arWords1 = new string[5];
      arWords1 = new string[10];

      string sText = "демонстрация работы с массивами";
      string[] arWords =
        sText.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        // { "123", "sqd", "fff" };


      int iMaxLen = 0;
      foreach (string sWord in arWords)
      {
        if (sWord.Length > iMaxLen)
        {
          iMaxLen = sWord.Length;
        }
      }

      Console.WriteLine($"Max length is {iMaxLen}");
    }
  }
}
