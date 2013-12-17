using System;
using System.Reflection;
using System.ServiceModel;
using System.Xml;
using Morpher.WebService.V2.MorpherWebService;

namespace Morpher.WebService.V2
{
    public class Client
        : Russian.IDeclension
        , Ukrainian.IDeclension
        , Russian.INumberSpelling
        , Ukrainian.INumberSpelling
    {
        private readonly WebServiceSoapClient soapClient;
        private readonly Credentials credentials;

        public Client () : this ((Parameters) null)
        {
        }

        public Client (Parameters parameters)
        {
            parameters = parameters ?? new Parameters ();

            string url = parameters.Url ?? "http://morpher.ru/WebService.asmx";

            soapClient = new WebServiceSoapClient (new BasicHttpBinding (),
                                                   new EndpointAddress (new Uri (url)));

            soapClient.Endpoint.Behaviors.Add (new HttpUserAgentEndpointBehavior (Assembly.GetExecutingAssembly().FullName));

            credentials = new Credentials 
            {
                Username = parameters.Username, 
                Password = parameters.Password
            };
        }

        public Client (XmlNode parameters)
            : this (new Parameters {
                Url      = parameters.GetAttributeOrNull ("url"),
                Username = parameters.GetAttributeOrNull ("username"),
                Password = parameters.GetAttributeOrNull ("password")})
        {
        }

        Russian.IParse Russian.IDeclension.Parse(string s, Russian.ParseArgs args)
        {
            return new Russian.Parse (soapClient.GetXml (credentials, s), s);
        }

        Ukrainian.IParse Ukrainian.IDeclension.Parse(string s, Ukrainian.ParseArgs args)
        {
            return new Ukrainian.Parse (soapClient.GetXmlUkr (credentials, s), s);
        }

        string Russian.INumberSpelling.Spell (decimal n, ref string unit, ICase<Russian.IParadigm> @case)
        {
            var result = soapClient.Propis (credentials, (uint) n, unit);

            unit = new Russian.UnitParadigm (result.unit).Get(@case);

            return new Russian.UnitParadigm (result.n).Get(@case);
        }

        string Ukrainian.INumberSpelling.Spell (decimal n, ref string unit, ICase<Ukrainian.IParadigm> @case)
        {
            var result = soapClient.PropisUkr (credentials, (uint) n, unit);

            unit = new Ukrainian.Paradigm (result.unit).Get (@case);

            return new Ukrainian.Paradigm (result.n).Get (@case);
        }
    }
}
