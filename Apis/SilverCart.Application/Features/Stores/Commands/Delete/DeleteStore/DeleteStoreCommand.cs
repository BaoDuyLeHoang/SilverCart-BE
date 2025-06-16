using MediatR;
using System;

namespace Infrastructures.Features.Stores.Commands.Delete.DeleteStore
{
    public sealed record DeleteStoreCommand(Guid Id) : IRequest<Guid>;
}