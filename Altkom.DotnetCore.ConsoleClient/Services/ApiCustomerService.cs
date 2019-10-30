using Altkom.DotnetCore.Infrastructure;
using Altkom.DotnetCore.Models;
using Altkom.DotnetCore.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Altkom.DotnetCore.ConsoleClient.Services
{
    public class ApiCustomerService : ICustomerRepository
    {
        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            client.GetAsync("api/customers");

            throw new Exception();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get(string city, string street)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string lastname)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
