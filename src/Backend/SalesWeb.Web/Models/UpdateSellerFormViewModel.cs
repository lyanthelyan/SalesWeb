using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses.DepartmentResponses;
namespace SalesWeb.Web.Models;

public class UpdateSellerFormViewModel
{
    public RequestUpdateSellerJson Seller { get; set; } = new();
    public List<ResponseDepartmentJson> Departments { get; set; } = [];
}