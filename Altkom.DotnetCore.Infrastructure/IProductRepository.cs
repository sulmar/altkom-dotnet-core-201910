using Altkom.DotnetCore.Models;
using System.Collections.Generic;

namespace Altkom.DotnetCore.Infrastructure
{
    public interface IProductRepository : IEntityRepository<Product, int>
    {
        IEnumerable<Product> Get(string color);
    }


}
