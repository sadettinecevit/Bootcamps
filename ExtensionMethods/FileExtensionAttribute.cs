using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    //FileUpload
    //id, name, exte, size, format
    //dosya formatını kontrol edecek
    [AttributeUsage(AttributeTargets.Property)] // | AttributeTargets.Property şeklinde kullanımı arttırılabilir.
    public class FileExtensionAttribute : Attribute
    {
        public string Extensions { get; }
        public FileExtensionAttribute(string extensions)
        {
            Extensions = extensions;
        }

        public class FileUpload
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [FileExtension("jpg,png,pdf")]
            public string Format { get; set; }
        }
    }
}
