using System;
using pi193_03.Model;

namespace pi193_03
{
  class Program
  {
    static void Main(string[] args)
    {
      BusRoute pBus1 = new BusRoute();
      BusRoute pBus2 = new BusRoute();


      pBus1.Number = "130";
      pBus2.Number = "131";

      Console.WriteLine(pBus1.Number);

      Console.ReadKey();
    }
  }
}
