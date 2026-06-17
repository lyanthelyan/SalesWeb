namespace SalesWeb.Domain.Entities.Seller;

public static class SellerValidate
{
    public static void ValidateSeller(
        string name,
        string email,
        DateTime birthDate,
        decimal baseSalary,
        Guid departmentId)
    {
        if (departmentId == Guid.Empty)
            throw new ArgumentException("Department ID cannot be empty.");

        if (birthDate > DateTime.UtcNow)
            throw new ArgumentException("Invalid birth date.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Seller name cannot be empty.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Seller email cannot be empty.");

        if (baseSalary <= 0)
            throw new ArgumentException("Base salary must be greater than zero.");
    }
}