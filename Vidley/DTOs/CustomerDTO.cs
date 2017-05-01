using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }
        public byte MembershipTypeId { get; set; }
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}