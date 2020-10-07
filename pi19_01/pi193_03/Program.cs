using pi193_03.Model;
using System;
using System.Collections.Generic;

namespace pi193_03
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      BusRoute pBus1 = new BusRoute();
      Passenger pPassenger1 = new Passenger("0001", new DateTime(1991, 8, 19), 20);
      Passenger pPassenger2 = new Passenger("0002", new DateTime(1993, 10, 1), 22);
      Passenger pPassenger3 = new Passenger("0003", new DateTime(2005, 10, 1), 22);
      pBus1.PassengerList.Add(pPassenger1);
      pBus1.PassengerList.Add(pPassenger2);
      pBus1.PassengerList.Add(pPassenger3);
      pBus1.PassengerList.Add(pPassenger3);
      pBus1.Number = "130";

      List<Passenger> pList = pBus1.GetUnticketedList();
      Console.WriteLine($"Пассажиров-молодых зайцев: {pList.Count} шт.");
      foreach (Passenger pAr in pList) {
        Console.WriteLine(pAr.CardNumber);
      }
      /*

      BusRoute pBus2 = new BusRoute();
      pBus2.Number = "131";
      pBus2.PassengerList.Add(pPassenger3);
      pBus2.PassengerList.Add(pPassenger3);
      pBus2.PassengerList.Add(pPassenger3);


      Console.WriteLine(pBus1.Number);
      */
      Console.ReadKey();
    }
  }
}
