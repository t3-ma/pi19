using System.Collections.Generic;

namespace pi191_03CL.Model
{
  /// <summary>
  /// Почтовый ящик
  /// </summary>
  public class Mailbox
  {
    #region constructors
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="address"></param>
    public Mailbox(string address)
    {
      Address = address;
      LetterList = new List<Letter>();
    }

    #endregion
    
    #region public properties
    public string Address { get; set; }
    public List<Letter> LetterList { get; }
    #endregion

    #region public methods
    /// <summary>
    /// Количество непрочитанных писем в почтовом ящике
    /// </summary>
    /// <returns></returns>
    public int GetUnreadCount()
    {
      int ii = 0;
      foreach (var pL in LetterList)
      {
        if (!pL.FlagRead)
        {
          ii++;
        }
      }

      return ii;
    }
    #endregion
  }
}
