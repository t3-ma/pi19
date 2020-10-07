using System;
using System.Collections.Generic;

namespace pi193_03.Model
{
  /*
   
   	Рейс автобуса
		  Номер 
		  Время выезда
		  Время приезда
		  Пассажир[]
		  СколькоНесовершеннолетнихЗайцевСегодня()

   */

  /// <summary>
  /// Рейс автобуса
  /// </summary>
  public class BusRoute
  {
    #region consts
    /// <summary>
    /// m_dTransferPayment
    /// </summary>
    private const double TransferPayment = 20;
    #endregion

    #region variables
    // поле:: номер
    private string _number;


    /// <summary>
    /// свойство:: Номер 
    /// </summary>
    public string Number
    {
      get {
        return _number;
      }
      set {
        if (value != "") {
          _number = value;
        }
      }
    }

    /// <summary>
    /// Время выезда
    /// </summary>
    public DateTime DateFrom { get; set; }
    /// <summary>
    /// Время приезда
    /// </summary>
    public DateTime DateTo; // { get; set; }
    /// <summary>
    /// Пассажир[]
    /// </summary>
    public List<Passenger> PassengerList { get; set; }
    #endregion

    #region constructors
    /// <summary>
    /// Constructor
    /// </summary>
    internal BusRoute()
    {
      PassengerList = new List<Passenger>();
    }
    #endregion

    #region public methods
    /// <summary>
    /// Получить список необилеченных несовершеннолетних пассажиров
    /// </summary>
    /// <returns></returns>
    public List<Passenger> GetUnticketedList()
    {
      List<Passenger> arResult = new List<Passenger>();
      //...
      foreach (Passenger pP in PassengerList) {
        if (pP.Age < 18 && !pP.HadPaid) {
          arResult.Add(pP);
        }
      }
      return arResult;
    }
    #endregion

  }
}
