using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class Customer
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsSubscribed  { get; set; }
            public MemberShipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yy}")]
        public DateTime? BirthDate { get; set; }
    }
}