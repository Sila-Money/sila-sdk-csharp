using Newtonsoft.Json;
using SilaAPI.silamoney.client.domain;
using SilaApiTest;
using System;
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

            HttpListenerResponse response = buildResponse(context, request);

            listener.Close();
        }

        private static HttpListenerResponse buildResponse(HttpListenerContext context, HttpListenerRequest request)
        {
            HttpListenerResponse response = context.Response;

            #region Read Body
            Stream body = request.InputStream;
            Encoding encoding = request.ContentEncoding;
            StreamReader reader = new StreamReader(body, encoding);

            string s = reader.ReadToEnd();

            body.Close();
            reader.Close();
            #endregion

            HeaderMsg headerMsg;
            EntityMsg entityMsg;
            LinkAccountMsg linkAccountMsg;
            GetAccountsMsg getAccountsMsg;
            IssueMsg issueMsg;
            TransferMsg transferMsg;
            RedeemMsg redeemMsg;
            GetTransactionsMsg getTransactionsMsg;
            SilaBalanceRequest silaBalanceRequest;

            switch (request.RawUrl)
            {
                case "/check_handle":
                    headerMsg = JsonConvert.DeserializeObject<HeaderMsg>(s);
                    return getCheckHandleResponse(context, headerMsg);
                case "/register":
                    entityMsg = JsonConvert.DeserializeObject<EntityMsg>(s);
                    return getRegisterResponse(context, entityMsg);
                case "/request_kyc":
                    headerMsg = JsonConvert.DeserializeObject<HeaderMsg>(s);
                    return getRequestKYCResponse(context, headerMsg);
                case "/check_kyc":
                    headerMsg = JsonConvert.DeserializeObject<HeaderMsg>(s);
                    return getCheckKYCResponse(context, headerMsg);
                case "/link_account":
                    linkAccountMsg = JsonConvert.DeserializeObject<LinkAccountMsg>(s);
                    return getLinkAccountResponse(context, linkAccountMsg);
                case "/get_accounts":
                    getAccountsMsg = JsonConvert.DeserializeObject<GetAccountsMsg>(s);
                    return getGetAccountsResponse(context, getAccountsMsg);
                case "/issue_sila":
                    issueMsg = JsonConvert.DeserializeObject<IssueMsg>(s);
                    return getIssueMsgResponse(context, issueMsg);
                case "/transfer_sila":
                    transferMsg = JsonConvert.DeserializeObject<TransferMsg>(s);
                    return getTransferMsgResponse(context, transferMsg);
                case "/redeem_sila":
                    redeemMsg = JsonConvert.DeserializeObject<RedeemMsg>(s);
                    return getRedeemMsgResponse(context, redeemMsg);
                case "/get_transactions":
                    getTransactionsMsg = JsonConvert.DeserializeObject<GetTransactionsMsg>(s);
                    return getGetTransactionsMsgResponse(context, getTransactionsMsg);
                case "/silaBalance":
                    silaBalanceRequest = JsonConvert.DeserializeObject<SilaBalanceRequest>(s);
                    return getSilaBalanceResponse(context, silaBalanceRequest);
                default:
                    break;
            }

            return null;
        }

        private static HttpListenerResponse getSilaBalanceResponse(HttpListenerContext context, SilaBalanceRequest silaBalanceRequest)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            response.StatusCode = 200;
            response.StatusDescription = "OK";
            responseString = "1000";

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getGetTransactionsMsgResponse(HttpListenerContext context, GetTransactionsMsg getTransactionsMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!getTransactionsMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (getTransactionsMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";

                    responseString = "{\"reference\": \"ref\",\"message\": " + JsonConvert.SerializeObject(ModelsUtilities.createTransactionResult()) + ",\"status\": \"SUCCESS\"}";
                }
                else if (getTransactionsMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 403;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"Bad or absent signature header.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getRedeemMsgResponse(HttpListenerContext context, RedeemMsg redeemMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!redeemMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (redeemMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Redemption process started.\",\"status\": \"SUCCESS\"}";
                }
                else if (redeemMsg.header.userHandle.Equals("notStarted.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Redemption process not started; see message attribute.\",\"status\": \"FAILURE\"}";
                }
                else if (redeemMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature or usersignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getTransferMsgResponse(HttpListenerContext context, TransferMsg transferMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!transferMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (transferMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Transfer process started.\",\"status\": \"SUCCESS\"}";
                }
                else if (transferMsg.header.userHandle.Equals("notStarted.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Transfer process not started; see message attribute.\",\"status\": \"FAILURE\"}";
                }
                else if (transferMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature or usersignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getIssueMsgResponse(HttpListenerContext context, IssueMsg issueMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!issueMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (issueMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Issuance process started.\",\"status\": \"SUCCESS\"}";
                }
                else if (issueMsg.header.userHandle.Equals("notStarted.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Issuance process not started; see message attribute.\",\"status\": \"FAILURE\"}";
                }
                else if (issueMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature or usersignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getGetAccountsResponse(HttpListenerContext context, GetAccountsMsg getAccountsMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!getAccountsMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (getAccountsMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": " + JsonConvert.SerializeObject(ModelsUtilities.createGetAccountsResult()) + ",\"status\": \"SUCCESS\"}";
                }
                else if (getAccountsMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature or usersignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getLinkAccountResponse(HttpListenerContext context, LinkAccountMsg linkAccountMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!linkAccountMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (linkAccountMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Bank account successfully linked.\",\"status\": \"SUCCESS\"}";
                }
                else if (linkAccountMsg.header.userHandle.Equals("notlinked.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Bank account not successfully linked (public token may have expired. "
                        + "Tokens expire in 30 minutes after creation).\",\"status\": \"FAILURE\"}";
                }
                else if (linkAccountMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature or usersignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getCheckKYCResponse(HttpListenerContext context, HeaderMsg headerMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!headerMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (headerMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": \"The user handle has successfully passed KYC verification.\",\"status\": \"SUCCESS\"}";
                }
                else if (headerMsg.header.userHandle.Equals("notverified.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"The user handle has not successfully passed KYC verification (may be pending, not have been "
                        + "registered, or have failed.).\",\"status\": \"FAILURE\"}";
                }
                else if (headerMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature or usersignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getRequestKYCResponse(HttpListenerContext context, HeaderMsg headerMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!headerMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (headerMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": \"The verification process for the user registered under header.user_handle has been successfully started.\",\"status\": \"SUCCESS\"}";
                }
                else if (headerMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature or usersignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getRegisterResponse(HttpListenerContext context, EntityMsg entityMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!entityMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (entityMsg.header.userHandle.Equals("user.silamoney.eth"))
                {
                    response.StatusCode = 200;
                    response.StatusDescription = "SUCCESS";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Handle successfully added to system with KYC data.\",\"status\": \"SUCCESS\"}";
                }
                else if (entityMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Invalid request body format, handle already in use, or blockchain address already in use.\",\"status\": \"FAILURE\"}";
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"authsignature header was absent or incorrect.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }

        private static HttpListenerResponse getCheckHandleResponse(HttpListenerContext context, HeaderMsg headerMsg)
        {
            string responseString = "";
            byte[] buffer;
            HttpListenerResponse response = context.Response;

            if (!headerMsg.header.userHandle.Equals("wrongSignature.silamoney.eth"))
            {
                if (headerMsg.header.userHandle.Equals(""))
                {
                    response.StatusCode = 400;
                    response.StatusDescription = "FAILURE";
                    responseString = "{\"reference\": \"ref\",\"message\": \"Handle sent in header.user_handle is a reserved handle according to our JSON schema. (Or: request body otherwise does not conform to JSON schema.)\",\"status\": \"FAILURE\"}";
                }
                else
                {
                    if (headerMsg.header.userHandle.Equals("user.silamoney.eth"))
                    {
                        response.StatusCode = 200;
                        response.StatusDescription = "SUCCESS";
                        responseString = "{\"reference\": \"ref\",\"message\": \"Handle sent in header.user_handle is available.\",\"status\": \"SUCCESS\"}";
                    }
                    else if (headerMsg.header.userHandle.Equals("taken.silamoney.eth"))
                    {
                        response.StatusCode = 200;
                        response.StatusDescription = "FAILURE";
                        responseString = "{\"reference\": \"ref\",\"message\": \"Handle sent in header.user_handle is taken.\",\"status\": \"FAILURE\"}";
                    }
                }
            }
            else
            {
                response.StatusCode = 401;
                response.StatusDescription = "FAILURE";
                responseString = "{\"reference\": \"ref\",\"message\": \"Auth signature is absent or derived address does not belong to auth_handle.\",\"status\": \"FAILURE\"}";
            }

            buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return response;
        }
    }
}