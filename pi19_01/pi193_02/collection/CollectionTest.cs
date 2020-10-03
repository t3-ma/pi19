using System;
using System.Collections;
using System.Collections.Generic;

namespace pi193_02.collection
{
  public static class CollectionTest
  {
    const int ItemCount = 9999999;

    public static void TestStaticArray()
    {
      //string sText = "aaaaa aaa sss d";
      //string[] ar = sText.Split(
      //    new[] { ' ', ',' },
      //    StringSplitOptions.RemoveEmptyEntries
      //  );
      //string[] ar2 = new string[100];
      //foreach (string sWord in ar)
      //{
      //  Console.WriteLine(sWord);
      //}


      Random pR = new Random();
      DateTime dtFrom = DateTime.Now;
      int iLoopCount = 9999;
      int[] ar = new int[iLoopCount * 10];
      for (int ii = 0; ii < ar.Length; ii++)
      {
        ar[ii] = pR.Next(1, iLoopCount * 100);
      }

      Int64 iSum = 0;
      for (int ii = 0; ii < iLoopCount; ii++)
      {
        for (int jj = 0; jj < ar.Length; jj++)
        {
          if (ar[jj] == 99)
          {
            iSum++;
          }
        }
      }

      Console.WriteLine($"#3: Array seek: {DateTime.Now - dtFrom} // {iSum}");


    }

    internal static void TestHashSet()
    {
      Random pRandom = new Random();
      HashSet<int> arHashset = new HashSet<int>();
      for (int ii = 0; ii < ItemCount; ii++)
      {
        int iRandKey = pRandom.Next(1, ItemCount * 10);
        arHashset.Add(iRandKey);
      }
      DateTime dtFrom = DateTime.Now;

      long iSum = 0;
      int iLoopCount = ItemCount / 10;
      for (int ii = 0; ii < iLoopCount; ii++)
      {
        if (arHashset.Contains(ii))
        {
          iSum ++;
        }
      }

      Console.WriteLine($"HashSet#1: Contains: {DateTime.Now - dtFrom} // {iSum}");
    }

    internal static void TestDictionary()
    {
      Random pRandom = new Random();
      Dictionary<int, string> arDictionary = new Dictionary<int, string>();
      for (int ii = 0; ii < ItemCount; ii++)
      {
        int iRandKey = pRandom.Next(1, ItemCount * 10);
        arDictionary[iRandKey] = ii.ToString();
      }
      DateTime dtFrom = DateTime.Now;

      long iSum = 0;
      int iLoopCount = ItemCount / 10;
      for (int ii = 0; ii < iLoopCount; ii++)
      {
        if (arDictionary.ContainsKey(ii))
        {
          // iSum++; iSum += 1;
          iSum += arDictionary[ii].Length;
        }
      }

      // arDictionary.Add(9999999, "33");
      // arDictionary.Remove(100);

      Console.WriteLine($"#1: ContainsKey: {DateTime.Now - dtFrom} // {iSum}");
      dtFrom = DateTime.Now;

      iSum = 0;
      for (int ii = 0; ii < iLoopCount; ii++)
      {
        if (arDictionary.ContainsValue("22"))
        {
          // iSum++; iSum += 1;
          iSum ++;
        }
      }

      Console.WriteLine($"#2: ContainsValue: {DateTime.Now - dtFrom} // {iSum}");

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
