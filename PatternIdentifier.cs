using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilePatternIdentifier
{
    class PatternIdentifier
    {
        // Returns the first n_bytes of the file specified by path.
        private byte[] getBytes(string path, int n_bytes)
        {
            byte[] buffer = new byte[n_bytes];
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            int bytes_read = fileStream.Read(buffer, 0, n_bytes);
            fileStream.Close();

            return buffer;
        }

        // Prints the filename and first n_bytes of each file located in root_path.
        private void printFilePatternInfo(string [] filePaths, int n_bytes)
        {
            foreach (string file_path in filePaths)
            {
                byte[] buffer = getBytes(file_path, n_bytes);
                string hex_string = Convert.ToHexString(buffer);
                FileInfo fileInfo = new FileInfo(file_path);

                Console.WriteLine(fileInfo.Name + ": " + hex_string);
            }
        }
        
        public void IdentifyPatterns(string root_path, int n_bytes)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(root_path, "", SearchOption.TopDirectoryOnly);
                printFilePatternInfo(filePaths, n_bytes);
                
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(String.Format("The entered path: {0} is not a valid directory.", root_path));
                Console.WriteLine("Press enter to exit the program...");
                Console.ReadLine();
                System.Environment.Exit(1);
            }
            
        }
    }
}
