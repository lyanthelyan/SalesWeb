using SalesWeb.Communication.Requests.SellerRequests.Register;
using SalesWeb.Communication.Responses.DepartmentResponses;

namespace SalesWeb.Web.Models;

public class SellerFormViewModel
{
    public RequestRegisterSellerJson Seller { get; set; } = new();

    public List<ResponseDepartmentJson> Departments { get; set; } = [];

}
