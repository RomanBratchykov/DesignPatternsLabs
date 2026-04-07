using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Adapter
{
    public class LegacyLoggerAdapter : ILogger
{
    private readonly LegacyLogger _legacy;

    public LegacyLoggerAdapter(LegacyLogger legacy)
        => _legacy = legacy;

    public void Log(string message)
        => _legacy.WriteEntry("App", message, 1);
}
}