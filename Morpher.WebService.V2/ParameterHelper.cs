using System;
using System.Xml;

namespace Morpher
{
    public static class ParameterHelper
    {
        public static string GetAttributeOrNull (this XmlNode parameters, string name)
        {
            if (parameters == null || parameters.Attributes == null)
            {
                return null;
            }

            var attribute = parameters.Attributes [name];
            return attribute == null ? null : attribute.Value;
        }

        public static string GetAttribute (this XmlNode parameters, string name)
        {
            var param = parameters.GetAttributeOrNull ("key");

            if (param == null)
            {
                throw new Exception ("Parameter '" + name + "' is required.");
            }

            return param;
        }
    }
}