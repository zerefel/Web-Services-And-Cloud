using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _01.DistanceCalculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculator" in both code and config file together.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double CalcDistance(Point point1, Point point2);
    }

    [DataContract]
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        [DataMember]
        public double X { get; set; }
        [DataMember]
        public double Y { get; set; }
    }
}
