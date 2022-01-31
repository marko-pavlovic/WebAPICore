using System.ComponentModel.DataAnnotations;
using Utilities.SimpleObjects;

namespace WebAPICore.ValidationAttributes
{
    public class PeriodValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var valuePeriod = (Period)value;

            if ((valuePeriod == null) ||
                ((valuePeriod.FromTime == null) && (valuePeriod.ToTime != null)) ||
                ((valuePeriod.FromTime != null) && (valuePeriod.ToTime == null)) ||
                ((valuePeriod.FromTime != null) && (valuePeriod.ToTime != null) && (valuePeriod.FromTime > valuePeriod.ToTime)))
                return true;

            return false;
        }
    }
}
