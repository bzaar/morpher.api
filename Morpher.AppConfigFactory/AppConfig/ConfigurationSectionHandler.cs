using System.Configuration;

namespace Morpher.AppConfig
{
    class ConfigurationSectionHandler : IConfigurationSectionHandler
    {
        object IConfigurationSectionHandler.Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            return section;
        }
    }
}
