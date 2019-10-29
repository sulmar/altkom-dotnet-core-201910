using Altkom.DotnetCore.Models;
using Bogus;

namespace Altkom.DotnetCore.Infrastructure.Fakers
{
    public class AddressFaker : Faker<Address>
    {
        public AddressFaker()
        {
            UseSeed(1);

            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.Street, f => f.Address.StreetName());
            RuleFor(p => p.Country, f => f.Address.Country());
        }
    }
}
