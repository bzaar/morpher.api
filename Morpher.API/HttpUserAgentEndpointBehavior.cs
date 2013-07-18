using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Morpher
{
    class HttpUserAgentEndpointBehavior : IEndpointBehavior
    {
        private readonly string m_userAgent;
 
        public HttpUserAgentEndpointBehavior(string userAgent)
        {
            this.m_userAgent = userAgent;
        }
 
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
 
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            HttpUserAgentMessageInspector inspector = new HttpUserAgentMessageInspector(this.m_userAgent);
            clientRuntime.MessageInspectors.Add(inspector);
        }
 
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
 
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}