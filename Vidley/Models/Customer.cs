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
        [Required(ErrorMessage ="Please Enter Customer's Name")]
        public string Name { get; set; }
        public bool IsSubscribed  { get; set; }
        public MemberShipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yy}")]
        [Display(Name="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}