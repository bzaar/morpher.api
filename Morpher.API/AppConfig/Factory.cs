using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Xml;

namespace Morpher.AppConfig
{
    class Factory
    {
        static Dictionary <Type, Lazy<object>> GetObjects ()
        {
            var section = (XmlNode) ConfigurationManager.GetSection("morpher");

            if (section == null) throw new Exception("<morpher> app.config section is missing.  An example app.config can be found at http://morpher.ru/dotnetapi#appconfig");

            var objects = new Dictionary <string, Lazy<object>> ();

            foreach (XmlNode objNode in section.SelectNodes ("objects//add"))
            {
                string objectName = objNode.Attributes["name"].Value;
                string typeName   = objNode.Attributes["type"].Value;

                var args = objNode.SelectNodes("parameters").Cast <XmlNode> ().ToArray();

                objects.Add(objectName, new Lazy <object> (() => CreateInstance (typeName, args), LazyThreadSafetyMode.ExecutionAndPublication));
            }

            var dictionary = new Dictionary <Type, Lazy<object>> ();

            foreach (XmlNode node in section.SelectNodes ("interfaces//add"))
            {
                string typeName   = node.Attributes["interface"].Value;
                string objectName = node.Attributes["object"].Value;

                dictionary.Add(GetType(typeName), objects[objectName]);
            }

            return dictionary;
        }

        private static object CreateInstance (string typeName, object [] args)
        {
            return Activator.CreateInstance (GetType (typeName), args);
        }

        private static Type GetType (string typeName)
        {
            return Type.GetType(typeName, true, false);
        }

        /// <summary>
        /// Key is the interface type and value is the object that implements it.
        /// </summary>
        readonly Dictionary <Type, Lazy <object>> objects = GetObjects ();

        internal T GetInterface <T> ()
        {
            return (T) objects[typeof(T)].Value;
        }
    }
}