namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using Travel.Entities.Airplanes;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
			switch (type)
			{
				case "LightAirplane":
					return new LigthAirplane();
				case "MediumAirplane":
					return new MediumAirplane();
				default:
					return null; //TODO what to return for default Airplane factory output
			}
		}
	}
}