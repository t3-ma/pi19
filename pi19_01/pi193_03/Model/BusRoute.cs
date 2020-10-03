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
    // поле:: номер
    private string _number;


    /// <summary>
    /// свойство:: Номер 
    /// </summary>
    public string Number
    {
      get
      {
        return _number;
      }
      set
      {
        if (value != "")
        {
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
  }
}
