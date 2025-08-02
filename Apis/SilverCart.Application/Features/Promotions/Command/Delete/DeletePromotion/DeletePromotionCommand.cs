using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Delete.DeletePromotion
{
    public sealed record DeletePromotionCommand(Guid Id) : IRequest<bool>;

}
