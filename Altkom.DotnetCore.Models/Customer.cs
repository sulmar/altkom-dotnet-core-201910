using System;

namespace Altkom.DotnetCore.Models
{

    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public decimal Salary { get; set; }
        public Address HomeAddress { get; set; }
        public Address InvoiceAddress { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool IsRemoved { get; set; }
    }

    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }

    public class Woman : Person
    {
        public int EyeColor { get; set; }
    }

    public class Man : Person
    {

    }

    // <xml>
    // <Woman><Id>1</Id><FirstName>Paula</FirstName></Woman>
    // </xml>

    // {"Id": 1, "FirstName":"Paula", "Type": "Woman" }

}
