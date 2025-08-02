using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Reports.Command.Add
{
    public sealed record AddReportCommand(string Title, string Content, IFormFile File) : IRequest<Guid>;
}
