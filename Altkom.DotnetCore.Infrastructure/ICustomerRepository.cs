using Altkom.DotnetCore.Models;
using Altkom.DotnetCore.Models.SearchCriterias;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.DotnetCore.Infrastructure
{
    public interface ICustomerRepository : IEntityRepository<Customer, int>
    {
        IEnumerable<Customer> Get(string city, string street);
        IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria);
        Customer Get(string lastname);
    }


}
