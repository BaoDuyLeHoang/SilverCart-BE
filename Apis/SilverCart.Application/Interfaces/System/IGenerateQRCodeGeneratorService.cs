using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.System;

public interface IGenerateQRCodeGeneratorService
{
    public byte[] GenerateQRCode(string url, int size = 256);
    public string GenerateQRCodeBase64(string url, int size = 256);
}
