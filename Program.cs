using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Convert2Mp3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            StringBuilder builder = new StringBuilder();
         
            DirectoryInfo d = new DirectoryInfo(Environment.CurrentDirectory);//Assuming Test is your Folder
          //  FileInfo[] Files = d.GetFiles("*.mp4"); //Getting Text files
            string str = "";

            FileInfo[] Files = d.GetFiles("*.mp4").Union(d.GetFiles("*.m4a")).ToArray();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "ffmpeg.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "Dump";
            startInfo.RedirectStandardOutput = !string.IsNullOrEmpty("test");
          //ffmpeg -i input.m4a -acodec libmp3lame -ab 128k output.mp3
          //for f in *.m4a; do ffmpeg -i "$f" -acodec libmp3lame -ab 256k "${f%.m4a}.mp3"; done



            foreach (FileInfo file in Files)
            {
               // str = str + ", " + file.Name;
                  builder.Append(Path.GetFileNameWithoutExtension(file.Name));
               //   Console.WriteLine("File names  = " + builder.ToString());
               //   startInfo.Arguments = "-i " + builder + ".mp4 -q:a 0 -map a " + builder + ".mp3";
                if(file.Name.Contains("mp4"))
                {
                  startInfo.Arguments = "-i \"" + builder + ".mp4\" -q:a 0 -map a \"" +  builder + ".mp3\"";
                }
                else if (file.Name.Contains("m4a"))
                {
                    startInfo.Arguments = "-i \"" + builder + ".m4a\" -acodec libmp3lame -ab 256k \"" + builder + ".mp3\"";
                }
                else
                {
                    Console.WriteLine("Format Not supported.Only m4a and mp4 formats are supported");

                }
                  try
                  {
                      // Start the process with the info we specified.
                      // Call WaitForExit and then the using statement will close.
                      using (Process exeProcess = Process.Start(startInfo))
                      {
                          exeProcess.WaitForExit();
                      }
                  }
                  catch
                  {
                      // Log error.
                  }

                  builder = new StringBuilder();
               
            }

            Console.WriteLine("**************************************************************************** ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("Please donate if you think your work is done ...................Saurabh RAWAT :) :) !! ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("                                                                             ");
            Console.WriteLine("********************************************************** ");
            while (true) ;
            Console.WriteLine("Hit CTRL+C or Close this Black Shit to come out of it");
           


          //  while (true) ;


          

        }

        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");
            IEnumerable<FileInfo> files = dir.EnumerateFiles();
            return files.Where(f => extensions.Contains(f.Extension));
        }
    }
}
