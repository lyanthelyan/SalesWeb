namespace SalesWeb.Communication.Requests.SellerRequests.Register;

public class RequestRegisterSellerJson
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime? BirthDate { get; set; }

    public decimal? BaseSalary { get; set; }

    public Guid? DepartmentId { get; set; }

}
