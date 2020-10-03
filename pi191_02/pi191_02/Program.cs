using System;
using System.Collections;
using System.Collections.Generic;

namespace pi191_02
{
  class Program
  {
    static void Main(string[] args)
    {
      // массивы
      h_TestArray();
      // нетипизированные массивы
      h_TestArrayList();
      // типизированные массивы
      h_TestList();

      Console.ReadKey();
    }

    private static void h_TestList()
    {
      // инициализация
      List<int> arInts = new List<int>();
      // заполнение
      arInts.Add(1);
      arInts.Add(2);
      // работа
      arInts.RemoveAt(0);
      //arInts.Remove(1);
      arInts[1] = 1;
      // цикл
      foreach (int iValue in arInts)
      {
        // вывод на экран
        Console.WriteLine(iValue);
      }
    }

    private static void h_TestArrayList()
    {
      // инициализация
      ArrayList arInts = new ArrayList();
      // заполнение
      arInts.Add(1);
      arInts.Add('1');
      arInts.Add(false);
      arInts.Insert(0, "2");
      arInts.Insert(0, arInts);
      arInts.Insert(0, arInts);
      //      ((ArrayList)arInts[0])[0];
      // работа
      arInts.RemoveAt(0);
      //arInts.Remove(1);
      arInts[1] = 1;
      // цикл
      foreach (object iValue in arInts)
      {
        if (iValue is int)
        {
          // int iV = iValue as int;// для ссылочных типов
          int iV = (int)iValue;
          continue;
          //...
        }
        // вывод на экран
        Console.WriteLine(iValue);
      }
    }

    private static void h_TestArray()
    {
      // инициализация
      int[] arInts = new[] { 1, 2, 3, 4, 5, 6 };
      arInts[1] = 1;
      // цикл
      foreach (int iValue in arInts)
      {
        // вывод на экран
        Console.WriteLine(iValue);
      }
    }
  }
}
