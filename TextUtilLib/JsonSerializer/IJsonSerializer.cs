namespace TextUtilLib.JsonSerializer
{
    public interface IJsonSerializer
    {
        /// <summary>
        /// Returns the passed generic object serialized as JSON
        /// </summary>
        string Serialize<T>(T inputObject);
    }
}
