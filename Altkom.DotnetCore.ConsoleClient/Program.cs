using Altkom.DotnetCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.ConsoleClient
{
    class Program
    {
        // <= C# 7.0
        // static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();
        // static async Task MainAsync(string[] args)

        // >= C# 7.1
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello .NET Core!");

            await Task.Delay(TimeSpan.FromSeconds(3));

            // SyncTest();

            // ContinueWithTest();

            // AsyncAwaitTest();

            Customer newCustomer = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                CompanyName = "Altkom"
            };

            await AddCustomer(newCustomer);


            var customers = await GetCustomersAsync();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // GET /api/customers
        private static async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            string baseUrl = "http://localhost:5000";
            string request = "api/customers";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await client.GetAsync(request);

                string json = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(json);

                return customers;
            }
        }


        // GET /api/customers/10

        private static async Task<Customer> GetCustomerAsync(int id)
        {
            string request = $"api/customers/{id}";

            var customer = await GetAsync<Customer>(request);

            return customer;
        }

        private static async Task<IEnumerable<Customer>> GetCustomers2Async()
        {
            string request = $"api/customers";

            var customers = await GetAsync<IEnumerable<Customer>>(request);

            return customers;
        }

         private static async Task<T> GetAsync<T>(string request)
        {
            string baseUrl = "http://localhost:5000";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await client.GetAsync(request);

                string json = await response.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<T>(json);

                return results;
            }
        }


        private static async Task AddCustomer(Customer customer)
        {
            string baseUrl = "http://localhost:5000";
            string request = "api/customers";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                string json = JsonConvert.SerializeObject(customer);

                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(request, content);


            }
        }


        private static void ContinueWithTest()
        {
            CalculateAsync(100)
                .ContinueWith(t => Console.WriteLine(t.Result));
        }

        private static async Task AsyncAwaitTest()
        {
            decimal result = await CalculateAsync(100);

            Console.WriteLine(result);
        }

        private static void SyncTest()
        {
            var result = Calculate(100);

            Console.WriteLine(result);
        }

        static Task<decimal> CalculateAsync(decimal amount)
        {
            return Task.Run(() => Calculate(amount));
        }

        static decimal Calculate(decimal amount)
        {
            Console.WriteLine("calculating...");
            Thread.Sleep(TimeSpan.FromSeconds(5));

            var result = amount * 1.23m;
            Console.WriteLine("calculating...");

            return result;
        }
    }
}
