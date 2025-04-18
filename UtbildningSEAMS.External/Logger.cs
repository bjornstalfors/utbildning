using UtbildningSEAMS.Business.Application.Ports;

namespace UtbildningSEAMS.External;

public class Logger : ILogger
{
    public void LogInfo(string info)
    {
        Console.WriteLine("!");
    }    
}