/*
using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("Identity Number is required.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Valid email is required.");
            RuleFor(x => x.CustomerNumber).GreaterThan(0).WithMessage("Customer Number must be greater than 0.");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of Birth is required.");
            
            RuleForEach(x => x.CustomerAddresses).SetValidator(new CustomerAddressValidator());
            RuleForEach(x => x.CustomerPhones).SetValidator(new CustomerPhoneValidator());
            RuleFor(x => x.CustomerDetail).SetValidator(new CustomerDetailValidator());
        }
    }

    public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
    {
        public CustomerAddressValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.AddressLine).NotEmpty().WithMessage("Address Line is required.");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip Code is required.");
        }
    }

    public class CustomerPhoneValidator : AbstractValidator<CustomerPhone>
    {
        public CustomerPhoneValidator()
        {
            RuleFor(x => x.CountryCode).NotEmpty().WithMessage("Country Code is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required.");
        }
    }

    public class CustomerDetailValidator : AbstractValidator<CustomerDetail>
    {
        public CustomerDetailValidator()
        {
            RuleFor(x => x.FatherName).NotEmpty().WithMessage("Father Name is required.");
            RuleFor(x => x.MotherName).NotEmpty().WithMessage("Mother Name is required.");
            RuleFor(x => x.EducationStatus).NotEmpty().WithMessage("Education Status is required.");
            RuleFor(x => x.MonthlyIncome).NotEmpty().WithMessage("Monthly Income is required.");
            RuleFor(x => x.Occupation).NotEmpty().WithMessage("Occupation is required.");
        }
    }
}
*/
