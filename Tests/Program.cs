using Pinging;
using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace Tests
{
    public class Program
    {
        public static string getUrl(string url)
        {
            var spliter = url.Split('/');
            if(spliter.Length > 3)
            {
                var url_with_port = spliter[2];

                return url_with_port.Contains(':') ? url_with_port.Split(':')[0] : url_with_port;
            }
            return "";
        }

        static void Main(string[] args)
        {
            //getUrl("http://192.168.191.17:754/api/AutorizacionesConvenio");
            new Thread(async () =>
            {

                string[] arr = { "https://superuser.com/questions/1686312/how-can-i-do-a-ping-test-on-the-terminal", 
                                 "https://www.daniweb.com/programming/software-development/threads/523647/how-to-check-internet-connection-using-c-language", 
                                 "https://www.google.com/search?q=asd&o" };

                foreach (var url in arr)
                {
                    var url_complete = getUrl(url);
                    var str = await Pinging.Pinging.Pinger(url_complete, 3);

                    Console.WriteLine("La url es: {0}, El ping dio: {1}", url_complete, str);
                }

            }).Start();

            Console.ReadLine();
        }
    }
}
