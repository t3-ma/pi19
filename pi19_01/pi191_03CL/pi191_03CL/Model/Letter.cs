namespace pi191_03CL.Model
{
  /// <summary>
  /// Письмо
  /// </summary>
  public class Letter
  {

    #region constructor
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="sSender"></param>
    /// <param name="sReceiver"></param>
    /// <param name="sSubject"></param>
    public Letter(
      string sSender, 
      string sReceiver, 
      string sSubject)
    {
      Sender = sSender;
      Receiver = sReceiver;
      Subject = sSubject;
    }
    #endregion
    
    #region public properties
    /// <summary>
    /// Отправитель
    /// </summary>
    public string Sender { get; set; }
    /// <summary>
    /// Получатель
    /// </summary>
    public string Receiver { get; set; }
    /// <summary>
    /// Тема
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Флаг прочтения письма
    /// </summary>
    public bool FlagRead { get; set; }

    #endregion
  }
}
