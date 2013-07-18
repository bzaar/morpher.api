using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Morpher
{
    class HttpUserAgentMessageInspector : IClientMessageInspector
    {
        private const string USER_AGENT_HTTP_HEADER = "User-Agent";
 
        private readonly string m_userAgent;
 
        public HttpUserAgentMessageInspector(string userAgent)
        {
            this.m_userAgent = userAgent;
        }
 
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
 
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            HttpRequestMessageProperty httpRequestMessage;
            object httpRequestMessageObject;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = (HttpRequestMessageProperty) httpRequestMessageObject;
                if (string.IsNullOrEmpty(httpRequestMessage.Headers[USER_AGENT_HTTP_HEADER]))
                {
                    httpRequestMessage.Headers[USER_AGENT_HTTP_HEADER] = this.m_userAgent;
                }
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add(USER_AGENT_HTTP_HEADER, this.m_userAgent);
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }
            return null;
        }
    }
}