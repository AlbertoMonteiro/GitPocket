using System.Xml.Schema;
using System.Xml.Serialization;

namespace ResourceAutomation
{
    /// <remarks />
    [XmlType(AnonymousType = true)]
    public class Data
    {
        /// <remarks />
        [XmlElement("value")]
        public string Value { get; set; }

        /// <remarks />
        [XmlText]
        public string[] Text { get; set; }

        /// <remarks />
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <remarks />
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace", AttributeName = "space")]
        public string Space { get; set; }

        public override string ToString()
        {
            return string.Format("{0} => {1}", Name, Value);
        }

        public Data WithValue(string value)
        {
            Value = value;
            return this;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var data = obj as Data;
            if (data == null)
                return false;

            return data.Name == Name;
        }
    }
}