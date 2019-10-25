using Newtonsoft.Json;
using SilaAPI.silamoney.client.domain;
using SilaApiTest;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Http;

namespace WebServer
{
    public class TestHttpServer : HttpServer
    {
        public static void Listener(string[] prefixes)
        {
            HttpListener listener = new HttpListener();

            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            BuildResponse(context, request);

            listener.Stop();

            listener.Close();
        }

        private static void BuildResponse(HttpListenerContext context, HttpListenerRequest request)
        {
            #region Read Body
            Stream body = request.InputStream;
            Encoding encoding = request.ContentEncoding;
            StreamReader reader = new StreamReader(body, encoding);

            string s = reader.ReadToEnd();

            reader.Close();
            body.Close();
            #endregion

            HeaderMsg HeaderMsg;
            EntityMsg entityMsg;
            LinkAccountMsg linkAccountMsg;
            GetAccountsMsg getAccountsMsg;
            IssueMsg issueMsg;
            TransferMsg transferMsg;
            RedeemMsg redeemMsg;
            GetTransactionsMsg getTransactionsMsg;

            switch (request.RawUrl)
            {
                case "/check_handle":
                    HeaderMsg = JsonConvert.DeserializeObject<HeaderMsg>(s);
                    GetCheckHandleResponse(context, HeaderMsg);
                    break;
                case "/register":
                    entityMsg = JsonConvert.DeserializeObject<EntityMsg>(s);
                    GetRegisterResponse(context, entityMsg);
                    break;
                case "/request_kyc":
                    HeaderMsg = JsonConvert.DeserializeObject<HeaderMsg>(s);
                    GetRequestKYCResponse(context, HeaderMsg);
                    break;
                case "/check_kyc":
                    HeaderMsg = JsonConvert.DeserializeObject<HeaderMsg>(s);
                    GetCheckKYCResponse(context, HeaderMsg);
                    break;
                case "/link_account":
                    linkAccountMsg = JsonConvert.DeserializeObject<LinkAccountMsg>(s);
                    GetLinkAccountResponse(context, linkAccountMsg);
                    break;
                case "/get_accounts":
                    getAccountsMsg = JsonConvert.DeserializeObject<GetAccountsMsg>(s);
                    GetGetAccountsResponse(context, getAccountsMsg);
                    break;
                case "/issue_sila":
                    issueMsg = JsonConvert.DeserializeObject<IssueMsg>(s);
                    GetIssueMsgResponse(context, issueMsg);
                    break;
                case "/transfer_sila":
                    transferMsg = JsonConvert.DeserializeObject<TransferMsg>(s);
                    GetTransferMsgResponse(context, transferMsg);
                    break;
                case "/redeem_sila":
                    redeemMsg = JsonConvert.DeserializeObject<RedeemMsg>(s);
                    GetRedeemMsgResponse(context, redeemMsg);
                    break;
                case "/get_transactions":
                    getTransactionsMsg = JsonConvert.DeserializeObject<GetTransactionsMsg>(s);
                    GetGetTransactionsMsgResponse(context, getTransactionsMsg);
                    break;
                case "/silaBalance":
                    GetSilaBalanceResponse(context);
                    break;
                default:
                    break;
            }
        }

        private static void GetSilaBalanceResponse(HttpListenerContext context)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            response.StatusCode = 200;
            response.StatusDescription = "OK";
            string responseString = "1000";

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();
        }

        private static void GetGetTransactionsMsgResponse(HttpListenerContext context, GetTransactionsMsg getTransactionsMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            GetTransactionsResponse responseObject = new GetTransactionsResponse();

            if (!getTransactionsMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (getTransactionsMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        ModelsUtilities.CreateTransactionResult(),
                        "SUCCESS");
                }
                else if (string.IsNullOrEmpty(getTransactionsMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                }
            }
            else
            {
                response.StatusCode = 403;
                response.StatusDescription = "FAILURE";
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetRedeemMsgResponse(HttpListenerContext context, RedeemMsg redeemMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!redeemMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (redeemMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Redemption process started.",
                        "SUCCESS");
                }
                else if (redeemMsg.Header.UserHandle.Equals("notStarted.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Redemption process not started; see message attribute.",
                        "FAILURE");
                }
                else if (string.IsNullOrEmpty(redeemMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetTransferMsgResponse(HttpListenerContext context, TransferMsg transferMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!transferMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (transferMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Transfer process started.",
                        "SUCCESS");
                }
                else if (transferMsg.Header.UserHandle.Equals("notStarted.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Transfer process not started; see message attribute.",
                        "FAILURE");
                }
                else if (string.IsNullOrEmpty(transferMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetIssueMsgResponse(HttpListenerContext context, IssueMsg issueMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!issueMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (issueMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Issuance process started.",
                        "SUCCESS");
                }
                else if (issueMsg.Header.UserHandle.Equals("notStarted.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Issuance process not started; see message attribute.",
                        "FAILURE");
                }
                else if (string.IsNullOrEmpty(issueMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetGetAccountsResponse(HttpListenerContext context, GetAccountsMsg getAccountsMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            List<Account> responseObject = new List<Account>();

            if (!getAccountsMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (getAccountsMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                }
                else if (string.IsNullOrEmpty(getAccountsMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetLinkAccountResponse(HttpListenerContext context, LinkAccountMsg linkAccountMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!linkAccountMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (linkAccountMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Bank account successfully linked.",
                        "SUCCESS");
                }
                else if (linkAccountMsg.Header.UserHandle.Equals("notlinked.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Bank account not successfully linked (public token may have expired. Tokens expire in 30 minutes after creation).",
                        "FAILURE");
                }
                else if (string.IsNullOrEmpty(linkAccountMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Invalid request body format.",
                        "FAILURE");
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseObject = ModelsUtilities.CreateResponse("ref",
                        "authsignature or usersignature Header was absent or incorrect.",
                        "FAILURE");
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetCheckKYCResponse(HttpListenerContext context, HeaderMsg HeaderMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!HeaderMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (HeaderMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "The user handle has successfully passed KYC verification.",
                        "SUCCESS");
                }
                else if (HeaderMsg.Header.UserHandle.Equals("notverified.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "The user handle has not successfully passed KYC verification (may be pending, not have been registered, or have failed.).",
                        "FAILURE");
                }
                else if (string.IsNullOrEmpty(HeaderMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Invalid request body format.",
                        "FAILURE");
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseObject = ModelsUtilities.CreateResponse("ref",
                        "authsignature or usersignature Header was absent or incorrect.",
                        "FAILURE");
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetRequestKYCResponse(HttpListenerContext context, HeaderMsg HeaderMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!HeaderMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (HeaderMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "The verification process for the user registered under Header.user_handle has been successfully started.",
                        "SUCCESS");
                }
                else if (string.IsNullOrEmpty(HeaderMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Invalid request body format.",
                        "FAILURE");
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseObject = ModelsUtilities.CreateResponse("ref",
                        "authsignature or usersignature Header was absent or incorrect.",
                        "FAILURE");
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetRegisterResponse(HttpListenerContext context, EntityMsg entityMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!entityMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (entityMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Handle successfully added to system with KYC data.",
                        "SUCCESS");
                }
                else if (string.IsNullOrEmpty(entityMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseObject = ModelsUtilities.CreateResponse("ref",
                        "Invalid request body format, handle already in use, or blockchain address already in use.",
                        "FAILURE");
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseObject = ModelsUtilities.CreateResponse("ref",
                        "authsignature Header was absent or incorrect.",
                        "FAILURE");
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            
        }

        private static void GetCheckHandleResponse(HttpListenerContext context, HeaderMsg HeaderMsg)
        {
            byte[] buffer;
            HttpListenerResponse response = context.Response;
            BaseResponse responseObject = new BaseResponse();

            if (!HeaderMsg.Header.UserHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (string.IsNullOrEmpty(HeaderMsg.Header.UserHandle))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                }
                else
                {
                    if (HeaderMsg.Header.UserHandle.Equals("user.silamoney.eth"))
                    {
                        response.StatusCode = 200;
                        response.StatusDescription = "SUCCESS";
                        responseObject = ModelsUtilities.CreateResponse("ref", "Handle sent in Header.user_handle is available.", "SUCCESS");
                    }
                    else if (HeaderMsg.Header.UserHandle.Equals("taken.silamoney.eth"))
                    {
                        response.StatusCode = 200;
                        response.StatusDescription = "FAILURE";
                        responseObject = ModelsUtilities.CreateResponse("ref", "Handle sent in Header.user_handle is taken.", "FAILURE");
                    }
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
            }

            string responseString = JsonConvert.SerializeObject(responseObject);
            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();


        }
    }
}