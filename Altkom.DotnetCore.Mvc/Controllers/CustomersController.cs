using Altkom.DotnetCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.DotnetCore.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var customers = customerRepository.Get();

            return View(customers);
        }

        public IActionResult Details(int? id)
        {
            var customer = customerRepository.Get(id.Value);

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            customerRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
