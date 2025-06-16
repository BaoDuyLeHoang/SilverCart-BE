using Infrastructures.Interfaces.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Services.System
{
    public class CalculateService : ICalculateService
    {
        public double CalculateDistanceInMeter(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadius = 6371; //Km
                                             // Note lại sau này xài lại
                                             // Haversine formula để tính khoảng cách giữa 2 điểm trên trái đất
                                             // a = sin²(Δφ/2) + cos φ1 ⋅ cos φ2 ⋅ sin²(Δλ/2) (a là diện tích giữa 2 điểm)
                                             // c = 2 ⋅ atan2( √a, √(1−a) ) (c là góc giữa 2 điểm)
                                             // d = R ⋅ c (distance)
                                             // Δφ là lat2 - lat1 (sự khác biệt giữa vĩ độ 2 điểm)
                                             // Δλ là lon2 - lon1 (sự khác biệt giữa kinh độ 2 điểm)
            var deltaLat = (lat2 - lat1) * (Math.PI / 180);
            var deltaLon = (lon2 - lon1) * (Math.PI / 180);

            var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) + //sin²(Δφ/2)
                    Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) *//cos φ1 ⋅ cos φ2
                    Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2); //sin²(Δλ/2)

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)); //2 ⋅ atan2( √a, √(1−a) )
            return EarthRadius * c * 1000; // m
        }
    }
}
