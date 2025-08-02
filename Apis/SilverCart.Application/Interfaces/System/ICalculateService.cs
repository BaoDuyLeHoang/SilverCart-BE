using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.System
{
    public interface ICalculateService
    {
        double CalculateDistanceInMeter(double lat1, double lon1, double lat2, double lon2);
    }
}
