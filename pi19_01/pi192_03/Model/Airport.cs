using System;
using System.Collections.Generic;

namespace pi192_03.Model
{
  /// <summary>
  /// Аэропорт (класс)
  /// </summary>
  internal class Airport
  {
    #region static variables
    /// <summary>
    /// Мест на аэродроме, которые зарезервированы
    /// </summary>
    private static readonly int VIPReservation = 4;
    private const int VIPReservationConst = 4;
    #endregion

    #region constructors
    /// <summary>
    /// Конструктор
    /// </summary>
    public Airport(int iPlaneCapacity, string sName, string sCity)
    {
      AirplaneCapacity = iPlaneCapacity;
      Name = sName;
      this.City = sCity;
      AirplaneList = new List<Airplane>();
    }
    #endregion

    #region public properties
    public string Name { get; set; }
    public string City { get; set; }
    /// <summary>
    /// Предельное количество самолетов на аэродроме
    /// </summary>
    public int AirplaneCapacity { get; set; }
    /// <summary>
    /// Предельное количество самолетов на аэродроме
    /// </summary>
    public int AirplaneMondayAdditionalCapacity { get; set; }
    /// <summary>
    /// Список самолетов
    /// </summary>
    public List<Airplane> AirplaneList { get; }
    /// <summary>
    /// Есть ли место для самолетов на аэродроме
    /// </summary>
    public bool IsFull => h_IsAeroportFull();

    #endregion

    #region private method
    private bool h_IsAeroportFull(/*Airport this*/)
    {
      int iMaxCapacity = this.AirplaneCapacity;
      if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) {
        iMaxCapacity -= Airport.VIPReservation;
      }
      if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) {
        iMaxCapacity += AirplaneMondayAdditionalCapacity;
      }

      if (DateTime.Now.Year == 2001)
      {
        iMaxCapacity = 1;
      }
      return (AirplaneList?.Count >= iMaxCapacity);
    }
    #endregion

    #region public methods
    /// <summary>
    /// Получить количество самолетов заданного типа
    /// </summary>
    /// <returns></returns>
    public List<Airplane> GetAirplaneByFilter(EPlaneType enType, int iMinCapacity)
    {
      List<Airplane> ar = new List<Airplane>();
      foreach (Airplane pP in AirplaneList) {
        if (pP.AirplaneType == enType && pP.PassengerCapacity > iMinCapacity) {
          ar.Add(pP);
        }
      }

      return ar;
    }
    #endregion

  }
}
