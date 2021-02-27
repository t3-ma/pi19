#region Using

using System;

#endregion

namespace pi192_03CA
{
  #region Class CNegativeException 

  /// <summary>
  /// ClassDisc
  /// </summary>
  internal class CNegativeException: Exception
  {
    public CNegativeException(string title): base("Отрицательные значения не поддерживаются")
    {
      Title = title;
    }

    #region Variables
    /// <summary>
    /// Название поля
    /// </summary>
    public string Title { get; set; }

    #endregion
  }

  #endregion
}