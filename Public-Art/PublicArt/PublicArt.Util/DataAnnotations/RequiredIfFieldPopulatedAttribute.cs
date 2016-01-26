using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicArt.Util.DataAnnotations
{
    /// <summary>
    /// Specifies that a data field value is required when the designated data field is populated
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class RequiredIfPropertyPopulatedAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets or sets the other property name that will be used during validation.
        /// </summary>
        /// <value>
        /// The other property name.
        /// </value>
        public string Property { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether other property should be empty to trigger validation (default is <c>false</c>).
        /// </summary>
        /// <value>
        ///   <c>true</c> if other property's population validation should be inverted; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// How this works
        /// - true: validated property is required when other property is not populated
        /// - false: validated property is required when other property is populated
        /// </remarks>
        public bool IsInverted { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredIfPropertyPopulatedAttribute"/> class.
        /// </summary>
        /// <param name="property">The property to check.</param>
        public RequiredIfPropertyPopulatedAttribute(string property) : base("'{0}' is required because '{1}' {2}.")
        {
            this.Property = property;
            this.IsInverted = false;
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>
        /// An instance of the formatted error message.
        /// </returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                base.ErrorMessageString,
                name,
                this.Property,
                this.IsInverted ? "is not populated" : "is populated");
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
                throw new ArgumentNullException(nameof(validationContext));

            var prop = validationContext.ObjectType.GetProperty(this.Property);

            if (prop == null)
                return new ValidationResult($"Couldn't find a property named '{this.Property}'");


            var propValue = prop.GetValue(validationContext.ObjectInstance);

            if (value == null && ((!IsInverted && propValue != null) || (IsInverted && propValue == null)))
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

            return ValidationResult.Success;
        }
    }
}
