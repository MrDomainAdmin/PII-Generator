using CreditCardValidator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace PII_Generator
{
    class PII
    {
        public static void GeneratePII(string filename, string type)
        {
            //Number of PII to generate
            int gensize = 10000;
            List<string> piidata = new List<string>();
            switch (type)
            {
                case "creditcard":
                    
                    if (File.Exists(filename))
                    {
                        for (int i = 0; i < gensize; i++)
                        {
                            piidata.Add((string)CreditCardFactory.RandomCardNumber(CardIssuer.Visa));
                        }
                        using (StreamWriter sw = File.AppendText(filename))
                        {
                            foreach (var card in piidata)
                            {
                                sw.WriteLine(card);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                    break;
                case "ssn":
                    if (File.Exists(filename))
                    {
                        Random generator = new Random();
                        
                        for (int i = 0; i < gensize; i++)
                        {
                            piidata.Add(Regex.Replace(String.Format("{0:###-##-####}", generator.Next(0, 999999999).ToString("D9")), @"^(.{3})(.{2})(.{4})$", "$1-$2-$3"));
                        }
                        using (StreamWriter sw = File.AppendText(filename))
                        {
                            foreach (var card in piidata)
                            {
                                sw.WriteLine(card);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                    break;
                default:
                        Console.WriteLine("Please specify type of PII to generate. Current supported types are creditcard and ssn");
                    break;
            }
        }
    }
}
