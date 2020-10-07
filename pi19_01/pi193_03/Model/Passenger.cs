using System;

namespace pi193_03.Model
{
  public class Passenger
  {

    #region private variables
    private readonly DateTime m_dtBirthDate;

    private readonly double m_dTransferPayment;
    #endregion

    #region public properties

    /*
    		# карта
		Возраст
		Заплатил/не заплатил
		Сумма оплаты
    
       * */

    /// <summary>
    /// Номер карты
    /// </summary>
    public string CardNumber { get; set; }
    /// <summary>
    /// Возраст
    /// </summary>
    public int Age => h_GetFullYears();
    public int AgeStatic => h_GetFullYears(m_dtBirthDate);
    public double Payment { get; set; }
    /// <summary>
    /// Заплатил/нет
    /// </summary>
    public bool HadPaid => h_HasPaid();
    
    #endregion

    #region constructors

    public Passenger(
      string sCardNumber, DateTime dtBirthDate, double dTransferPayment)
    {
      CardNumber = sCardNumber;
      m_dtBirthDate = dtBirthDate;
      this.m_dTransferPayment = dTransferPayment;
    }

    #endregion

    #region private methods
    private int h_GetFullYears()
    {
      DateTime dtFrom = DateTime.Now;
      int iCurrentYear = dtFrom.Year;
      int iBirthYear = m_dtBirthDate.Year;
      int iAge = iCurrentYear - iBirthYear;
      if (dtFrom.DayOfYear < m_dtBirthDate.DayOfYear) {
        iAge--;
      }

      return iAge;
    }

    private static int h_GetFullYears(DateTime dtBirthDate)
    {
      DateTime dtFrom = DateTime.Now;
      int iCurrentYear = dtFrom.Year;
      int iBirthYear = dtBirthDate.Year;
      int iAge = iCurrentYear - iBirthYear;
      if (dtFrom.DayOfYear < dtBirthDate.DayOfYear) {
        iAge--;
      }

      return iAge;
    }

    private bool h_HasPaid()
    {
      double dRate = m_dTransferPayment;
      if (Age > 65) {
        dRate *= 0.5;
      }

      if (Age < 12) {
        dRate = 0;
      }

      if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
      {
        dRate = 0;
      }
      return (Payment >= dRate);
    }
    #endregion

  }
}