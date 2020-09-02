namespace TextUtilLib.JsonSerializer
{
    public class Utf8JsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// Serializes a generic object to JSON using the Utf8Json library
        /// </summary>
        public string Serialize<T>(T inputObject)
        {
            return Utf8Json.JsonSerializer.ToJsonString(inputObject);
        }
    }
}
