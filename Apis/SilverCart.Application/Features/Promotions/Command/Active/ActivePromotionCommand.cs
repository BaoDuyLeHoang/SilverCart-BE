using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Deactive
{
    public sealed record ActivePromotionCommand(Guid Id) : IRequest<bool>;
}
