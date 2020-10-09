namespace pi192_03.Model
{
  internal class Airplane
  {
    #region constructors
    public Airplane(EPlaneType airplaneType, string registrationNumber, int passengerCapacity)
    {
      AirplaneType = airplaneType;
      RegistrationNumber = registrationNumber;
      PassengerCapacity = passengerCapacity;
    }
    #endregion

    #region private variables
    private EPlaneType _airplaneType;
    #endregion

    #region public properties

    public EPlaneType AirplaneType
    {
      get { return _airplaneType; }
      set { _airplaneType = value; }
    }

    public string RegistrationNumber { get; set; }
    public int PassengerCapacity { get; set; }
    #endregion
  }
}