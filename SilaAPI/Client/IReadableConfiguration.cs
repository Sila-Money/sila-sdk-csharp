using System.Collections.Generic;

namespace SilaAPI.Client
{
    public interface IReadableConfiguration
    {
        string BasePath { get; }
        int Timeout { get; }
        string UserAgent { get; }
    }
}
