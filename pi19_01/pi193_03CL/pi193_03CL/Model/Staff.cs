
using System;

namespace pi193_03CL
{
  /// <summary>
  /// Сотрудник
  /// </summary>
  public class CStaff
  {
    /// <summary>
    /// ФИО
    /// </summary>
    public string Fio { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    public string RankTitle { get; set; }
  }
}
