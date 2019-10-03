using System;
using RestSharp;

namespace SilaAPI.Client
{
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response);
}
