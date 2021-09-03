using System.Collections.Generic;
using Rentanime.Models;

namespace Rentanime.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}