using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.System;
public interface IGhnService
{
    Task<int> RegisterStoreAsync(CreateStoreGhnRequest command);
}
