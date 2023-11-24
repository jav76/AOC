using System.Net;

namespace AOC
{
    internal class AOCRepo
    {
        private const string SESSION_FILE_PATH = "Secrets/Session.txt";
        private const string BASE_ADDRESS = @"https://adventofcode.com";
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

        public static async Task<string> GetInput(short day, short year, string sessionID)
        {
            string inputText = string.Empty;
            using (HttpClientHandler handler = GetClientHandler())
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(BASE_ADDRESS);
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(new Uri($"{BASE_ADDRESS}/{year}/day/{day}/input"));

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
            cookieContainer.SetCookies
            (
                new Uri(BASE_ADDRESS),
                $"session={sessionID}"
            );

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
