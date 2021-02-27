using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pi192_03.Model;

namespace pi192_03
{
  class Program
  {
    static void Main(string[] args)
    {
      Airport pAirport1 = new Airport(10, "Жуковский", "Москва");
      Airplane pPlane1 = new Airplane(EPlaneType.A320, "MY-AIR", 250);
      Airplane pPlane2 = new Airplane(EPlaneType.A319, "MY-ART", 200);
      pAirport1.AirplaneList.Add(pPlane1);
      pAirport1.AirplaneList.Add(pPlane2);

      Airport pAirport2 = new Airport(20, "им А.С. Леонова", "Кемерово");

      Console.WriteLine($"Аэропорт {pAirport1.Name} в г. {pAirport1.City} {(pAirport1.IsFull ? "переполнен" : "не заполнен")}");
      EPlaneType enRequestType = EPlaneType.A310;

      List<Airplane> pList1 = pAirport1.GetAirplaneByFilter(enRequestType, 100);
      List<Airplane> pList2 = h_GetAirplaneByFilter(enRequestType, 100, pAirport1.AirplaneList);
      Console.WriteLine($"Количество самолетов {enRequestType}: {pList1.Count} шт...");
      Console.ReadKey();
    }

    /// <summary>
    /// Получить количество самолетов заданного типа
    /// </summary>
    /// <returns></returns>
    private static List<Airplane> h_GetAirplaneByFilter(EPlaneType enType, int iMinCapacity, List<Airplane> pAirplaneList)
    {
      List<Airplane> ar = new List<Airplane>();
      foreach (Airplane pP in pAirplaneList) {
        if (pP.AirplaneType == enType && pP.PassengerCapacity > iMinCapacity) {
          ar.Add(pP);
        }
      }

      return ar;
    }

  }
}
