using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;

namespace SilaAPI.Client
{
    public interface IApiAccessor
    {
        Configuration Configuration { get; set; }
        String GetBasePath();
        ExceptionFactory ExceptionFactory { get; set; }
    }
}
