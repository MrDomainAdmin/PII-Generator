using System;
using System.Diagnostics;
using CommandLine;


namespace PII_Generator
{
    class Program
    {
        public class Options
        {
            [Option("filename", Required = true, HelpText = "Input filename.")]
            public string filename { get; set; }
            [Option("filesize", Required = true, HelpText = "Input size of file in bytes.")]
            public long filesize { get; set; }
            [Option("type", Required = true, HelpText = "Input PII type.")]
            public string type { get; set; }


        }
        static void Main(string[] args)
        {

            CommandLine.Parser.Default.ParseArguments<Options>(args)
            .WithParsed(GenerateFile);

           
        }

        static void GenerateFile(Options o)
        {
            //To prevent typos from generating files that are too big - Capped at 5gb
            if (o.filesize >= 5368709121)
            {
                Console.WriteLine("Filesize is more than 5GB, please pick a lower value.");
                return;
            }
            string filebuild = $"file createnew {o.filename} {o.filesize}";
            
            ProcessStartInfo startInfo = new ProcessStartInfo("fsutil.exe");
            startInfo.Arguments = filebuild;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process p = Process.Start(startInfo);
            p.WaitForExit();
            PII.GeneratePII(o.filename, o.type);

        }
    }
}
