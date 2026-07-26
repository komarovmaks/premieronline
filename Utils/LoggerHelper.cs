

using Microsoft.Extensions.Logging;

namespace Tests.Utils;
 
public static class LoggerHelper
{
    private static readonly ILogger Logger =
        LoggerFactory.Create(builder => builder.AddConsole())
                     .CreateLogger("Tests");
 
    public static void Info(string message)
    {
        Logger.LogInformation(message);
    }
}