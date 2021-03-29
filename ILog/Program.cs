using System;
using System.Collections.Generic;

namespace ILog
{
    class Program
    {
        static void Main()
        {
            Logger log = new Logger();
            Dictionary<object, object> newOne = new Dictionary<object, object>();
            newOne.Add('b', 4);
            newOne.Add('a', 4);
            newOne.Add('c', 4);
            newOne.Add('v', 4);
            log.SystemInfo("oh...", newOne);
        }
    }
}
