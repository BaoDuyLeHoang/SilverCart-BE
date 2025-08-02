using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Delete
{
    using global::Infrastructures.Features.Promotions.Command.Delete.DeleteProductPromotions;
    using Infrastructures.Features.Promotions.Command.Delete.DeleteProductPromotions;
    using MediatR;
    using System;
    using System.Collections.Generic;

    namespace Infrastructures.Features.Promotions.Command.Delete.DeleteProductPromotions
    {
        public record DeleteProductPromotionsCommand(Guid PromotionId, List<Guid> ProductIds) : IRequest<DeleteProductPromotionResponse>;
    }

}
