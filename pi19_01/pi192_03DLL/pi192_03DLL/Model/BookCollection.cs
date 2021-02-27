using System.Collections.Generic;

namespace pi192_03DLL.Model
{
  public class BookCollection
  {
    #region constructor
    public BookCollection(string sOwner)
    {
      Owner = sOwner;
      BookList = new List<Book>();
    }
    #endregion

    #region public properties
    /// <summary>
    /// Владелец (ФИО)
    /// </summary>
    public string Owner { get; set; }
    /// <summary>
    /// Коллекция книг
    /// </summary>
    public List<Book> BookList { get; set; }
    #endregion
  }
}
