namespace Meteo_Lib
{
    public struct Coordinates
    {
        public double NALL { get; set; }

        public double EALL { get; set; }

        public Coordinates()
        {
            NALL = 0.0;
            EALL = 0.0;
        }

        public Coordinates(double NALL, double EALL)
        {
            this.NALL = NALL;
            this.EALL = EALL;
        }
    }
}
