using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Pinging
{

    public static class Pinging
    {
        public static async Task<string> Pinger(string url, int seconds)
        {
            try
            {
                using (var pinger = new Ping())
                {
                    var reply = await pinger.SendPingAsync(url, seconds * 1000);
                    if(reply.Status == IPStatus.Success)
                    {
                        return "Success";
                    }
                    else
                    {
                        return "Failed";
                    }
                }
            }
            catch(Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }
        public static void Main(string[] args)
        {
            new Thread(async (x) =>
            {
                string url = "www.google.com";
                int time_out_in_seconds = 3;
                var str = await Pinger(url, time_out_in_seconds);

                Console.WriteLine($"Hello World! : {str}");
            }).Start();

            Console.ReadLine();
        }
    }
}
