using System.Collections.Generic;

namespace pi191_03CL.Model
{
  /// <summary>
  /// Почтовый сервер
  /// </summary>
  public class MailServer
  {
    #region constructors
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="address"></param>
    public MailServer(string address)
    {
      Address = address;
      MailboxList = new List<Mailbox>();
    }
    #endregion

    #region public properties
    /// <summary>
    /// Адрес почтового сервера
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Список ящиков
    /// </summary>
    public List<Mailbox> MailboxList { get; }
    #endregion
  }


  public class TestMailServer : MailServer
  {
    #region constructors
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="address"></param>
    public TestMailServer(string address) :
      base(address)
    {
      h_TestFill();
    }
    #endregion

    #region private methods
    private void h_TestFill()
    {
      Mailbox item1 = new Mailbox("1@mail.ru");
      item1.LetterList.Add(new Letter("2@mail.ru", "1@mail.ru", "Test"));
      item1.LetterList.Add(new Letter("3@mail.ru", "1@mail.ru", "Test read")
      {
        FlagRead = true
      });

      MailboxList.Add(item1);

      Mailbox item2 = new Mailbox("2@mail.ru");
      MailboxList.Add(item2);
    }
    #endregion
  }

}
