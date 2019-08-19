using System;
using System.Net;
using System.IO;

namespace PasswordSafe
{
    class Program
    {
        public static string CallRestMethod(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            //wr.Headers.Add("Username", "xyz");
            //wr.Headers.Add("Password", "abc");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var enc = System.Text.Encoding.GetEncoding("utf-8");
            var responseStream = new StreamReader(response.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            response.Close();
            return result;
        }

        static void Main(string[] args)
        {
            var rotateBy = 10;
            var input = "Password";
            char c = 'y';

            while (c == 'y')
            {
                Console.WriteLine("Enter a password: ");
                input = Console.ReadLine();

                Console.WriteLine("Enter a rotate number [1-9]: ");
                rotateBy = int.Parse(Console.ReadLine());

                //var encrypted = Encryption.Encryption.Encrypt(input, rotateBy);
                var encrypted = Program.CallRestMethod($"https://localhost:44306/Encrypt?input={input}&rotateBy={rotateBy}");
                Console.WriteLine($"Encrypting: {input} to {encrypted}");

                //var decrypted = Encryption.Encryption.Decrypt(encrypted);
                var decrypted = Program.CallRestMethod($"https://localhost:44306/Decrypt?input={encrypted}");
                Console.WriteLine($"Decrypting: {encrypted} to {decrypted}");

                Console.WriteLine("Again? y/n: ");
                c = (char)Console.ReadLine()[0];
            }
        }
    }
}
