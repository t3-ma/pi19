
using System;
using System.Collections.Generic;

namespace pi193_03CL
{
  /// <summary>
  /// БД Сотрудник
  /// </summary>
  public class CStaffDb
  {
    #region constructorD
    public CStaffDb(string sTitle)
    {
      Title = sTitle;
      StaffList = new List<CStaff>();
    }
    #endregion


    #region properties
    /// <summary>
    /// Наименование организации
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Список сотрудников
    /// </summary>
    public List<CStaff> StaffList { get; set; }
    #endregion

  }


  public class CTestStaffDb : CStaffDb
  {
    public CTestStaffDb(string sTitle) : base(sTitle)
    {
      h_TestFill();
    }

    private void h_TestFill()
    {
      StaffList.Add(new CStaff()
      {
        Fio = "q1 w e",
        BirthDate = new DateTime(2000, 10, 01),
        RankTitle = "rank1"
      });
      StaffList.Add(new CStaff()
      {
        Fio = "q2 w e",
        BirthDate = new DateTime(1990, 10, 01),
        RankTitle = "rank2"
      });
      StaffList.Add(new CStaff()
      {
        Fio = "q3 w e",
        BirthDate = new DateTime(2000, 10, 01),
        RankTitle = "rank3"
      });
    }
  }
}
