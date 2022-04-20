using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class MyFirstValAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "Değer boş olamaz";
                return false;
            }
            if (value.ToString().ToUpperInvariant() == "şahane".ToUpperInvariant())
            {
                ErrorMessage = "şahane yazamazsınız.";
                return false;
            }
            return true;
        }
    }
}