using System;
using System.Reflection;
using System.ServiceModel;
using System.Xml;
using Morpher.MorpherWebService;

namespace Morpher
{
    public class WebServiceClient
        : Russian.IDeclension
        , Ukrainian.IDeclension
        , Russian.INumberSpelling
        , Ukrainian.INumberSpelling
    {
        private readonly WebServiceSoapClient soapClient;
        private readonly Credentials credentials;

        public WebServiceClient () : this ((WebServiceParameters) null)
        {
        }

        public WebServiceClient (WebServiceParameters parameters)
        {
            parameters = parameters ?? new WebServiceParameters ();

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

        public WebServiceClient (XmlNode parameters)
            : this (new WebServiceParameters {
                Url      = parameters.GetAttributeOrNull ("url"),
                Username = parameters.GetAttributeOrNull ("username"),
                Password = parameters.GetAttributeOrNull ("password")})
        {
        }

        Russian.IFullParadigm Russian.IDeclension.Analyse(string s)
        {
            return new Russian.FullParadigm (soapClient.GetXml (credentials, s), s);
        }

        Ukrainian.IFullParadigm Ukrainian.IDeclension.Analyse(string s)
        {
            return new Ukrainian.FullParadigm (soapClient.GetXmlUkr (credentials, s), s);
        }

        string Russian.INumberSpelling.Spell (decimal n, ref string unit, ICase<Russian.IParadigm> @case)
        {
            var result = soapClient.Propis (credentials, (uint) n, unit);

            unit = new RussianUnitParadigm (result.unit).Get(@case);

            return new RussianUnitParadigm (result.n).Get(@case);
        }

        string Ukrainian.INumberSpelling.Spell (decimal n, ref string unit, ICase<Ukrainian.IParadigm> @case)
        {
            var result = soapClient.PropisUkr (credentials, (uint) n, unit);

            unit = new Ukrainian.Paradigm (result.unit).Get (@case);

            return new Ukrainian.Paradigm (result.n).Get (@case);
        }

        class RussianUnitParadigm : Russian.Paradigm
        {
            private readonly Forms forms;

            public RussianUnitParadigm (Forms forms) : base (forms.И)
            {
                this.forms = forms;
            }

            protected override Forms Forms
            {
                get { return forms; }
            }

            protected override string Locative
            {
                get { return forms.П; } // Совпадает с предложным.
            }
        }
    }
}
