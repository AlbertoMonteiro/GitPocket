using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ResourceAutomation
{
    /// <remarks />
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "root")]
    public class Root
    {
        /// <remarks />
        [XmlElement("resheader")]
        public Header[] Header { get; set; }

        /// <remarks />
        [XmlElement("data")]
        public List<Data> Datas { get; set; }

        [XmlIgnore]
        public string Path { get; private set; }

        public Root WithPath(string path)
        {
            Path = path;
            return this;
        }
        public Root WithNewDatas(List<Data> datas)
        {
            Datas.AddOnlyNewItens(datas, dts => dts.Select(d => d.WithValue("")));
            return this;
        }
    }
}
