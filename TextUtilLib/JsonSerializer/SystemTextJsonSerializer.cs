namespace TextUtilLib.JsonSerializer
{
    public class SystemTextJsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// Serializes a generic object to JSON using the Microsoft's System.Text.Json library
        /// </summary>
        public string Serialize<T>(T inputObject)
        {
            return System.Text.Json.JsonSerializer.Serialize(inputObject);
        }
    }
}
