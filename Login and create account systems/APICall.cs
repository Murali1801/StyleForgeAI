/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Login_and_create_account_systems
{
    class APICall
    {
        static async Task Main(string[] args)
        {
            string apiUrl = "https://styleforge-ai-api-168486608630.asia-south1.run.app/process-image";

            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Set up the request
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrl);

                // If needed, add headers to the request
                // request.Headers.Add("Authorization", "Bearer your-token");

                try
                {
                    // Send the request and get the response
                    HttpResponseMessage response = await client.SendAsync(request);

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Output the response data
                    Console.WriteLine(responseData);
                }
                catch (HttpRequestException e)
                {
                    // Handle any errors that occurred during the request
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }
    }
}*/