﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MemberShipType.PayAsYouGo||customer.MembershipTypeId==MemberShipType.Unknown)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date is Required");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years old to go on a membership.");
        }
    }
}