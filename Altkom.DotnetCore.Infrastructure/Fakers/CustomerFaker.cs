using Altkom.DotnetCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotnetCore.Infrastructure.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker(AddressFaker addressFaker)
        {
            UseSeed(1);

            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.BirthDay, f => f.Person.DateOfBirth);
            RuleFor(p => p.CompanyName, f => f.Company.CompanyName());
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(2.0f));
            RuleFor(p => p.HomeAddress, f => addressFaker.Generate());
            RuleFor(p => p.InvoiceAddress, f => addressFaker.Generate());
        }
    }
}
