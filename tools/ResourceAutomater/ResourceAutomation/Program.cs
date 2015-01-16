using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ResourceAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringsPath = @"C:\Projetos\GitPocket\source\GitPocket\GitPocket.Shared\Strings";
            if (args.Length > 0)
                stringsPath = args[0];

            var serializer = new XmlSerializer(typeof(Root));

            var allResources = Directory.EnumerateFiles(stringsPath, "*.resw", SearchOption.AllDirectories)
                                        .OrderByDescending(x => x.EndsWith(@"en\Resources.resw"))
                                        .Select(path => serializer.Deserialize<Root>(path).WithPath(path))
                                        .ToList();

            var enResource = allResources.First();
            allResources.Skip(1)
                .ToList()
                .ForEach(root => serializer.Serialize(root.WithNewDatas(enResource.Datas), root.Path));
            
            Console.WriteLine("Done");
        }
    }
}
