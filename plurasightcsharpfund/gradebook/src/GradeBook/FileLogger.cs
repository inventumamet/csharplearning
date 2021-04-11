using System.IO;

namespace GradeBook
{

    public class FileLogger
    {
        public FileLogger(string fileName)
        {
            this.fileHandle = new StreamWriter(fileName);
            this.fileHandle.AutoFlush = true;
        }

        public void writeLineToFile(string logMessage)
        {
            this.fileHandle.WriteLine(logMessage);
        }

        ~FileLogger() 
        {
            this.fileHandle.Close();    
        }

        StreamWriter fileHandle;
    }

}