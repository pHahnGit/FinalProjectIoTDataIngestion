using System.Text.Json;


namespace FinalProjectLibrary.Helpers
{
    /// <summary>
    /// Helper class that can contain static methods used to handle sources
    /// </summary>
    public class SourceHelper
    {
        /// <summary>
        /// Finds the EUI or dev_id value in the root level of a json document
        /// </summary>
        /// <param name="input"> JsonDocument</param>
        /// <returns></returns>
        public static string? FindSourceID(JsonDocument input)
        {
            var rootElement = input.RootElement;

            if (rootElement.TryGetProperty("EUI", out var eui))
            {
                return eui.ToString();
            }
            else if (rootElement.TryGetProperty("dev_id", out var devId))
            {
                return devId.ToString();
            }
            else if (rootElement.TryGetProperty("id", out var id))
            {
                return id.ToString();
            }
            else if (rootElement.TryGetProperty("probe_id", out var probeId))
            {
                return probeId.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
