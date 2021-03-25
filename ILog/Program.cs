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
            logger.Warning("ЯЖИВ2Error");
        }
    }
}
