using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace RawDataManager.Handlers
{
    public interface IRawDataHandler
    {
        Task<IActionResult> NewMeasurement(JsonDocument input);
    }
}