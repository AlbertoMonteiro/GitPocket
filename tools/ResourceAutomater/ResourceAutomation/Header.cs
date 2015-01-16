using System.Xml.Serialization;

namespace ResourceAutomation
{
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class Header
    {
        /// <remarks />
        [XmlElement("value")]
        public string Value { get; set; }

        /// <remarks />
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}