using System;
using System.Collections.Generic;
using System.IO;

namespace ILog
{
    /// <summary>Класс работы с логом</summary>
    class Logger : ILog
    {
        private List<string> errorUnique = new List<string>();
        private List<string> warningUnique = new List<string>();
        /// <summary>Создание папки под даты</summary>
        void CreatDirection()
        {
            string currentPath = @"..\..\..\..\logs\" + DateTime.Today.Date.ToString("d");
            DirectoryInfo directionInfo = new DirectoryInfo(currentPath);
            if (!directionInfo.Exists)
            {
                directionInfo.Create();
            }
        }

        //Создание файлов под даты для всех видов логов
        FileInfo CreatDirectionFatal()
        {
            CreatDirection();
            string currentPath = string.Concat(@"..\..\..\..\logs\", DateTime.Today.Date.ToString("d"), @"\Fatal.txt");
            FileInfo fileInfo = new FileInfo(currentPath);
            if (!fileInfo.Exists)
            {
                FileStream fs = fileInfo.Create();
                fs.Close();
            }
            return fileInfo;
        }

        FileInfo CreatDirectionError()
        {
            CreatDirection();
            string currentPath = string.Concat(@"..\..\..\..\logs\", DateTime.Today.Date.ToString("d"), @"\Error.txt");
            FileInfo fileInfo = new FileInfo(currentPath);
            if (!fileInfo.Exists)
            {
                FileStream fs = fileInfo.Create();
                fs.Close();
            }
            return fileInfo;
        }

        FileInfo CreatDirectionWarning()
        {
            CreatDirection();
            string currentPath = string.Concat(@"..\..\..\..\logs\", DateTime.Today.Date.ToString("d"), @"\Warning.txt");
            FileInfo fileInfo = new FileInfo(currentPath);
            if (!fileInfo.Exists)
            {
                FileStream fs = fileInfo.Create();
                fs.Close();
            }
            
            return fileInfo;
        }

        FileInfo CreatDirectionInfo()
        {
            CreatDirection();
            string currentPath = string.Concat(@"..\..\..\..\logs\", DateTime.Today.Date.ToString("d"), @"\Info.txt");
            FileInfo fileInfo = new FileInfo(currentPath);
            if (!fileInfo.Exists)
            {
                FileStream fs = fileInfo.Create();
                fs.Close();
            }
            return fileInfo;
        }

        FileInfo CreatDirectionDebug()
        {
            CreatDirection();
            string currentPath = string.Concat(@"..\..\..\..\logs\", DateTime.Today.Date.ToString("d"), @"\Debug.txt");
            FileInfo fileInfo = new FileInfo(currentPath);
            if (!fileInfo.Exists)
            {
                FileStream fs = fileInfo.Create();
                fs.Close();
            }
            return fileInfo;
        }


        //Реализация интерфейсов
        //  1/16
        public void Fatal(string message)
        {
            var path = CreatDirectionFatal();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Fatal): {message}");
            streamWriter.Close();
        }

        // 2/16
        public void Fatal(string message, Exception e)
        {
            var path = CreatDirectionFatal();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Fatal): ошибка '{e.Message}' {message}");
            streamWriter.Close();
        }


        // 3/16
        public void Error(string message)
        {
            var path = CreatDirectionError();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Error): {message}");
            streamWriter.Close();
        }

        // 4/16
        public void Error(string message, Exception e)
        {
            var path = CreatDirectionError();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Error): ошибка '{e.Message}' {message}");
            streamWriter.Close();
        }

        // 5/16
        public void Error(Exception ex)
        {
            var path = CreatDirectionError();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Error): ошибка '{ex.Message}'");
            streamWriter.Close();
        }
        // 6/16
        public void ErrorUnique(string message, Exception e)
        {
            if (!errorUnique.Contains($"{e.Message}; {DateTime.Today}"))
            {
                errorUnique.Add($"{e.Message}; {DateTime.Today}");
                var path = CreatDirectionWarning();
                StreamWriter streamWriter = path.AppendText();
                streamWriter.WriteLine($"{DateTime.Now} (Unique_Error): ошибка '{e.Message}' {message}");
                streamWriter.Close();
            }
        }

        // 7/16
        public void Warning(string message)
        {
            var path = CreatDirectionWarning();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Warning): {message}");
            streamWriter.Close();
        }

        // 8/16
        public void Warning(string message, Exception e)
        {
            var path = CreatDirectionWarning();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Warning): ошибка '{e.Message}' {message}");
            streamWriter.Close();
        }

        // 9/16
        public void WarningUnique(string message)
        {
            if (!warningUnique.Contains($"{message}; {DateTime.Today}"))
            {
                warningUnique.Add($"{message}; {DateTime.Today}");
                var path = CreatDirectionWarning();
                StreamWriter streamWriter = path.AppendText();
                streamWriter.WriteLine($"{DateTime.Now} (Unique_Warning): {message}");
                streamWriter.Close();
            }
        }

        // 10/16
        public void Info(string message)
        {
            var path = CreatDirectionInfo();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Info): {message}");
            streamWriter.Close();
        }

        // 11/16
        public void Info(string message, Exception e)
        {
            var path = CreatDirectionInfo();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Info): исключение '{e.Message}' {message}");
            streamWriter.Close();
        }

        // 12/16
        public void Info(string message, params object[] args)
        {
            string argsString = String.Join(", ", args);
            var path = CreatDirectionInfo();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Debug): {message}; {argsString}");
            streamWriter.Close();
        }


        // 13/16
        public void Debug(string message)
        {
            var path = CreatDirectionDebug();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Debug): {message}");
            streamWriter.Close();
        }

        // 14/16
        public void Debug(string message, Exception e)
        {
            var path = CreatDirectionDebug();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Debug): исключение '{e.Message}' {message}");
            streamWriter.Close();
        }

        // 15/16
        public void DebugFormat(string message, params object[] args)
        {
            string argsString = String.Join(", ", args);
            var path = CreatDirectionDebug();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (Debug): {message}; {argsString}");
            streamWriter.Close();
        }

        // 16/16
        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            string propertiesString = String.Join(", ", properties);
            var path = CreatDirectionInfo();
            StreamWriter streamWriter = path.AppendText();
            streamWriter.WriteLine($"{DateTime.Now} (System_Info): {message}; {propertiesString}");
            streamWriter.Close();
        }
    }
}