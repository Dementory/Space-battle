namespace SpaceBattle.Utilities
{
    public class UnitConverter
    {
        public static float FromMetersPerSecondToKilometersPerHour(float speedInMetersPerSecond)
        {

            return FromMetersToKilometers(speedInMetersPerSecond) * 3600;
        }

        public static float FromKilometersPerHourToMetersPerSecond(float speedInKilometersPerHour)
        {
            return FromKilometersToMeters(speedInKilometersPerHour) / 3600;
        }

        public static float FromMetersToKilometers(float distanceInMeters) => distanceInMeters / 1000;

        public static float FromKilometersToMeters(float distanceInKilometers) => distanceInKilometers * 1000;
    }
}
