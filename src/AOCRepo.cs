using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

namespace AOC
{
    internal class AOCRepo
    {
        private const string YEAR = "2022";
        private const string SESSION_FILE_PATH = "Secrets/Session.txt";
        private const string INPUT_BASE_PATH = @$"https://adventofcode.com/{YEAR}/day/";

        public static string GetSessionToken()
        {
            try
            {
                using (StreamReader sessionFile = new StreamReader(SESSION_FILE_PATH))
                {
                    return sessionFile.ReadToEnd();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Could not find session token file.\n" + ex.Message);
            }

            return string.Empty;
        }

        public static async Task<string> GetInput(short day, string sessionID)
        {
            string inputText = string.Empty;
            using (HttpClientHandler handler = GetClientHandler())
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(new Uri($"{INPUT_BASE_PATH}{day}/input"));

                        response.EnsureSuccessStatusCode();
                        inputText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"Failed to request input text for day {day}.\n" + ex.Message);
                    }
                }
            }

            return inputText;
        }

        private static CookieContainer GetSessionCookies(string sessionID)
        {
            CookieContainer cookieContainer = new CookieContainer(1);
            cookieContainer.Add(new Cookie
            {
                Name = "session",
                Value = sessionID,
            });

            return cookieContainer;
        }

        private static HttpClientHandler GetClientHandler()
        {
            return new HttpClientHandler
            {
                CookieContainer = GetSessionCookies(GetSessionToken())
            };
        }
    }
}
