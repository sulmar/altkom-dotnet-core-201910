using Altkom.DotnetCore.Models;
using Altkom.DotnetCore.Models.SearchCriterias;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.DotnetCore.Infrastructure
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
        IEnumerable<Customer> Get(string city, string street);
        IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria);
        Customer Get(string lastname);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(int id);
    }
}
