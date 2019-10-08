using SilaAPI.com.silamoney.client.api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Http;

namespace WebServer
{
    public class MyHttpServer : HttpServer
    {
        public static void SimpleListenerExample(string[] prefixes)
        {
            HttpListener listener = new HttpListener();

            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            HttpListenerResponse response = buildResponse(context, request);
        }

        private static HttpListenerResponse buildResponse(HttpListenerContext context, HttpListenerRequest request) {
            HttpListenerResponse response = context.Response;

            Stream body = request.InputStream;
            Encoding encoding = request.ContentEncoding;
            StreamReader reader = new StreamReader(body, encoding);

            string s = reader.ReadToEnd();

            body.Close();
            reader.Close();

            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }
    }
}