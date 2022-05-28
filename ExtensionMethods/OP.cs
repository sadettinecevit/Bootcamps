using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{    
    //Open-Close Principle : Yeni bir türk eklenince kodu hiç değiştirmeden kullanılabilecek

    public class OP
    {
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class DbLogger : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class XmlLogger : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
    /*
     * Ödev: bu sistem otomatik olarak bütün loggerları bulsun ve loglama işini yapsın.
        public void Log(string message)
        {
            List<ILoggers> loggers = // bunu bi yerden dolduracaksın. (Büyük ihtimalle reflection)
            foreach (ILogger logger in loggers)
            {
                logger.Log(message);
            }

        }
    */
    public class LogManager
    {
        public void Log(List<ILogger> loggers, string message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Log(message);
            }

        }
    }
}
