namespace Demo.Models.MasterModels;

public class ProductModel
{
    [Required(ErrorMessage = "Product Name is required."), StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")] public string ProductName { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")] public string Description { get; set; }

    [Required(ErrorMessage = "Price is required."), Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")] public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock Quantity is required."), Range(0, int.MaxValue, ErrorMessage = "Stock Quantity cannot be negative.")] public int StockQuantity { get; set; }

    [Required(ErrorMessage = "Category is required."), StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")] public string Category { get; set; }

    [Required(ErrorMessage = "Manufacturer is required."), StringLength(100, ErrorMessage = "Manufacturer cannot exceed 100 characters.")] public string Manufacturer { get; set; }

    [Required(ErrorMessage = "Manufacture Date is required."), CustomValidation(typeof(ProductModelValidators), nameof(ProductModelValidators.ValidateManufactureDate))] public DateTime ManufactureDate { get; set; }

    [Required(ErrorMessage = "Expiry Date is required."), CustomValidation(typeof(ProductModelValidators), nameof(ProductModelValidators.ValidateExpiryDate))] public DateTime ExpiryDate { get; set; }

    [Required(ErrorMessage = "Barcode is required."), StringLength(13, MinimumLength = 8, ErrorMessage = "Barcode must be between 8 and 13 characters.")] public string Barcode { get; set; }

    [Required(ErrorMessage = "Active status must be specified.")] public bool IsActive { get; set; }

    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters.")] public string Notes { get; set; }
}

public static class ProductModelValidators
{
    public static ValidationResult ValidateManufactureDate(DateTime manufactureDate, ValidationContext context)
    {
        if (manufactureDate > DateTime.Today)
        {
            return new("Manufacture Date cannot be in the future.");
        }

        return ValidationResult.Success;
    }

    public static ValidationResult ValidateExpiryDate(DateTime expiryDate, ValidationContext context)
    {
        if (context.ObjectInstance is ProductModel instance && expiryDate <= instance.ManufactureDate)
        {
            return new("Expiry Date must be after Manufacture Date.");
        }

        return ValidationResult.Success;
    }
}