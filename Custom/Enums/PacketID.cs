namespace TerraTemp.Custom.Enums {

    /// <summary>
    /// Enum containing all the possible different packets used by this mod.
    /// </summary>
    public enum PacketID : byte {
        WeeklyTemperatureDeviations,
        WeeklyHumidityDeviations,
        RequestServerTemperatureValues,
        ReceiveServerTemperatureValues
    }
}