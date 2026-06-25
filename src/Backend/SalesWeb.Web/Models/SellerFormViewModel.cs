using SalesWeb.Communication.Requests;
using SalesWeb.Communication.Responses;

namespace SalesWeb.Web.Models;

public class SellerFormViewModel
{
    public RequestRegisterSellerJson Seller { get; set; } = new();

    public List<ResponseDepartmentJson> Departments { get; set; } = [];

}
