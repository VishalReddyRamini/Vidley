using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Models;
namespace Vidley.ViewModels
{
    public class NewViewModel
    {
        public IEnumerable<MemberShipType> membershipTypes { get; set; }
        public Customer customer { get; set; }
    }
}