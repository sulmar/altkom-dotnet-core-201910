using Altkom.DotnetCore.Models;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.DotnetCore.Infrastructure
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
        IEnumerable<Customer> Get(string city, string street);
        Customer Get(string lastname);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(int id);
    }
}
