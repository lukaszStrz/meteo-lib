namespace Meteo_Lib
{
    public class Coordinates
    {
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        /// <param name="lat">Latitude</param>
        /// <param name="lng">Longitude</param>
        public Coordinates(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }
}
