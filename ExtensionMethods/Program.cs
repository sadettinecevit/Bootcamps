using System;
using System.Linq;
using System.Reflection;
using static ExtensionMethods.FileExtensionAttribute;

namespace ExtensionMethods
{
    /*
    
    ------------ SOLID Principle --------------
    //Single Responsibility : Fonksiyonları mümkün olduğunca küçültmeliyiz. Fonksiyon tek satırda olsa sadece bir işi yapmalı.
    //Open-Close Principle : Yeni bir türk eklenince kodu hiç değiştirmeden kullanılabilecek
    //Liskov Substitution Principle : Alt sınıf kullanarak üst sınıfları tanımlayabilmek. ILogger logger = new XmlLogger() gibi.
    //Interface Segregation Principle : Her ihtiyaç grubuna özel olarak interface oluşturmak
    //Dependency Inversion Prenciple : Bağımlılıkları azaltma. (Dependecy Injection bunun uygulamasıdır.)
    */
    class Program
    {
        static void Main(string[] args)
        {
            LSP lsp = new LSP();    

            "test".FirstChar();

            FileUpload fi = new FileUpload();
            fi.Name = "deneme";
            fi.Format = "testresmi.jpg";

            Validate(fi);

            Console.WriteLine("Hello World!");

        }

        static bool Validate(FileUpload file)
        {
            string retVal = string.Empty;
            Type type = typeof(FileUpload);

            // ? nullable değer demek ?? ise eğer null değer dönerse verilecek değer.
            PropertyInfo? pi = type.GetProperty(nameof(FileUpload.Format)) ?? default;
            //pi? burada ? eğer null gelirse hata verme bu satırı çalıştırmadan devam et demek.
            var attr = pi?.GetCustomAttribute<FileExtensionAttribute>();

            string[] extensions = attr.Extensions.Split(',');

            var format = pi.GetValue(file, null).ToString();
            var ext = format.Split('.')[1];

            var result = extensions.Contains(ext);

            if (!result) throw new Exception($"{ext} olarak gönderilen dosya formatı geçerli değildir.");

            return true;
        }

    }
}
