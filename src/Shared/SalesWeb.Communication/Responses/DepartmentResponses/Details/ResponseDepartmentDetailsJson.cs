using SalesWeb.Communication.Responses.SellerResponses;

namespace SalesWeb.Communication.Responses.DepartmentResponses.Details;

public class ResponseDepartmentDetailsJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ResponseSellerJson> Sellers { get; set; } = [];
}
