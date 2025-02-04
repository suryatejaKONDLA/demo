namespace Demo.Models.MasterModels;

public class SupplierModel
{
    [Required(ErrorMessage = "Company Name is required."), StringLength(100, ErrorMessage = "Company Name cannot exceed 100 characters.")] public string CompanyName { get; set; }

    [Required(ErrorMessage = "Contact Name is required."), StringLength(50, ErrorMessage = "Contact Name cannot exceed 50 characters.")] public string ContactName { get; set; }

    [StringLength(50, ErrorMessage = "Contact Title cannot exceed 50 characters.")] public string ContactTitle { get; set; }

    [Required(ErrorMessage = "Email is required."), EmailAddress(ErrorMessage = "Invalid email format.")] public string Email { get; set; }

    [Required(ErrorMessage = "Phone Number is required."), RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits.")] public string PhoneNumber { get; set; }

    [RegularExpression(@"^\d{10}$", ErrorMessage = "Alternate Phone Number must be 10 digits.")] public string AlternatePhoneNumber { get; set; }

    [Required(ErrorMessage = "Address Line 1 is required.")] public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    [Required(ErrorMessage = "City is required.")] public string City { get; set; }

    public string State { get; set; }

    [Required(ErrorMessage = "Postal Code is required."), RegularExpression(@"^\d{5}$", ErrorMessage = "Postal Code must be 5 digits.")] public string PostalCode { get; set; }

    [Required(ErrorMessage = "Country is required.")] public string Country { get; set; }

    [Url(ErrorMessage = "Invalid website URL."), StringLength(100, ErrorMessage = "Website cannot exceed 100 characters.")] public string Website { get; set; }

    [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")] public string Notes { get; set; }
}