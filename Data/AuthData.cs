using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tests.Data;

public class AuthData
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    public static AuthData LoadFromFile(string filePath = "Data/authData.json")
    {
        if (!File.Exists(filePath))
        {
            // Fallback for full path if executed from different relative root
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var fullPath = Path.Combine(baseDir, filePath);
            if (File.Exists(fullPath))
            {
                filePath = fullPath;
            }
            else
            {
                var projectDir = Path.GetFullPath(Path.Combine(baseDir, "../../../"));
                filePath = Path.Combine(projectDir, "Data", "authData.json");
            }
        }

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<AuthData>(json) ?? new AuthData();
    }
}
