using System;
using System.IO;

namespace ILog
{
    class Program
    {
        static void Main()
        {

            //Пока что папка log должна существовать изначально в файлах, могу добавить и её создание
            Logger logger = new Logger();
            //logger.Error("ЯЖИВ2Error");
            //logger.Debug("ЯЖИВ2Error");
            logger.Fatal("ЯЖИВ2Error");
            //logger.Info("ЯЖИВ2Error");
            //logger.Warning("ЯЖИВУРЯЯЯ");
        }
    }
}
