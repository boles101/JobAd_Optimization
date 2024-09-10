using System.ComponentModel.DataAnnotations;

namespace NET_Developer_Intern_API_Coding_Assessment.Helper
{
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public ValidEnumValueAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValid = Enum.IsDefined(_enumType, value);
            if (!isValid)
            {
                return new ValidationResult($"The value '{value}' is not valid for {validationContext.DisplayName}. Valid values are: {string.Join(", ", Enum.GetNames(_enumType))}");
            }
            return ValidationResult.Success;
        }
    }
}
