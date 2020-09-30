#region usings
using System;
using System.Collections.Generic;
#endregion

namespace pi192_02
{
  internal static class CArSpeedTest
  {
    #region private variables
    private static Random pRandom = new Random();
    #endregion

    #region public methods
    public static void TestHashSet()
    {
      const int RoomCount = 999999;
      // # в гостинице
      HashSet<int> arHashSet = new HashSet<int>();
      DateTime dtStart = DateTime.Now;
      for (int ii = 0; ii < RoomCount; ii++) {
        if (pRandom.Next(0, 100) < 5) {
          continue;
        }
        arHashSet.Add(ii);
      } // end for
      Console.WriteLine($"#2: hashset: Fill: {arHashSet.Count} комнат // {DateTime.Now - dtStart}");

      dtStart = DateTime.Now;
      const int LoopCount = 9999999;
      long iSum = 0;
      for (int ii = 0; ii < LoopCount; ii++) {
        if (arHashSet.Contains(ii)) {
          iSum++;
        }
      }

      Console.WriteLine($"#2: hashset: Seek+Sum[{LoopCount} раз в {arHashSet.Count} комнатах]: {DateTime.Now - dtStart}");

    }

    public static void TestArray()
    {
      const int RoomCount = 999999;
      // # в гостинице, Фамилия гостя
      string[] arArray = new string[RoomCount];
      DateTime dtStart = DateTime.Now;
      for (int ii = 0; ii < RoomCount; ii++) {
        arArray[ii] = h_GetFio();
      } // end for
      Console.WriteLine($"#0: array: Fill: {arArray.Length} комнат // {DateTime.Now - dtStart}");

      dtStart = DateTime.Now;
      const int LoopCount = 9999;
      for (int ii = 0; ii < LoopCount; ii++) {
        string sFio = h_GetFio();
        for (int jj = 0; jj < arArray.Length; jj++) {
          if (arArray[jj] == sFio) {
            break;
          }
        }
      }

      Console.WriteLine($"#0: array: Seek+Sum[{LoopCount} раз в {arArray.Length} комнатах]: {DateTime.Now - dtStart}");
    }

    public static void TestDictionary()
    {
      // # в гостинице, Фамилия гостя
      Dictionary<int, string> arDictionary = new Dictionary<int, string>();
      //arDictionary[1] = "Иванов Сергей Петрович";
      //arDictionary[3] = "Сидоренко Сергей Петрович";
      //arDictionary[999999] = "Сидоренко Сергей Петрович";

      DateTime dtStart = DateTime.Now;
      const int RoomCount = 999999;
      for (int ii = 0; ii < RoomCount; ii++) {
        if (pRandom.Next(0, 100) < 0) {
          continue;
        }

        arDictionary[ii] = h_GetFio();
      } // end for
      Console.WriteLine($"#1: Fill: {arDictionary.Count} комнат // {DateTime.Now - dtStart}");

      dtStart = DateTime.Now;
      const int LoopCount = 9999999;
      long iSum = 0;
      for (int ii = 0; ii < LoopCount; ii++) {
        if (arDictionary.ContainsKey(ii)) {
          iSum += arDictionary[ii].Length;
        }
      }

      Console.WriteLine($"#1: Seek+Sum[{LoopCount} раз в {arDictionary.Count} комнатах]: {iSum} // {DateTime.Now - dtStart}");
    }

    #endregion

    #region private methods
    private static string h_GetFio()
    {
      string[] arSurname =
          new[] { "Иванов", "Иваненко", "Иванович", "Сидоров", "Сидоренко", "Петров" };
      string[] arName =
          new[] { "Иван", "Петр", "Павел", "Михаил", "Василиса", "Алиса" };
      string sSurname = arSurname[
          pRandom.Next(0, arSurname.Length)];
      string sName = arName[
          pRandom.Next(0, arName.Length)];

      return $"{sSurname} {sName}-{pRandom.Next(1, 999)}";
    }
    #endregion
  }
}
