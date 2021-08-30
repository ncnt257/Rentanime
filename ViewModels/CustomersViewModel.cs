using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rentanime.Models;

namespace Rentanime.ViewModels
{
    public class CustomersViewModel
    {
        public CustomersViewModel()
        {
            Customers = new List<Customer>();
            var Customer1 = new Customer()
            {
                Id = 1,
                Name = "Shin Michima"
            };
            var Customer2 = new Customer()
            {
                Id = 2,
                Name = "Midori Suzumura"
            };
            Customers.Add(Customer1);
            Customers.Add(Customer2);

        }
        public List<Customer> Customers { get; set; }

    }
}