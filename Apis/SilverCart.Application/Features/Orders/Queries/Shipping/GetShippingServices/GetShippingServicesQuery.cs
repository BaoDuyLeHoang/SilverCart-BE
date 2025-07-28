using MediatR;
using Newtonsoft.Json.Linq;

namespace SilverCart.Application.Features.Orders.Queries.Shipping.GetShippingServices;

public class GetShippingServicesQuery : IRequest<JObject>
{
    public int FromDistrictId { get; set; }
    public int ToDistrictId { get; set; }
}