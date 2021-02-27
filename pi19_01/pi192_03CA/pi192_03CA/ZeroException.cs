#region Using

using System;

#endregion

namespace pi192_03CA
{
  #region Class CzeroException 

  /// <summary>
  /// CzeroException
  /// </summary>
  internal class CZeroException : Exception
  {
    public CZeroException() : base("Нулевые значения не поддерживаются")
    {
    }

  }

  #endregion
}