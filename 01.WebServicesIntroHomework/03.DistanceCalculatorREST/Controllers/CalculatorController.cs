using System;
using System.Web.Http;

namespace _03.DistanceCalculatorREST.Controllers
{
    [RoutePrefix("api/calculator")]
    public class CalculatorController : ApiController
    {
        // http://localhost:<port>/api/calculator/distance?startX=5&startY=5&endX=10&endY=10
        [HttpPost]
        [Route("distance")]
        public double CalculateDistance(double startX, double startY, double endX, double endY)
        {
            double distance = Math.Sqrt(Math.Pow((endX - startX), 2) + Math.Pow((endY - startY), 2));

            return distance;
        }
    }
}