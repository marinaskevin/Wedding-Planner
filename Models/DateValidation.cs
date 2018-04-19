using System;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner.Models
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return false;
            }
            var dt = (DateTime)value;
            if(dt >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}