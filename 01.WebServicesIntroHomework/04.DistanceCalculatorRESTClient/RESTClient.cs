using System;
using RestSharp;

namespace _04.DistanceCalculatorRESTClient
{
    class RESTClient
    {
        static void Main()
        {
            var client = new RestClient("http://localhost:2741/api/calculator");
            var request = new RestRequest("distance", Method.POST);

            request.AddQueryParameter("startX", "5");
            request.AddQueryParameter("startY", "5");
            request.AddQueryParameter("endX", "10");
            request.AddQueryParameter("endY", "10");

            RestResponse response = (RestResponse)client.Execute(request);
            var content = response.Content;

            Console.WriteLine(content);
        }
    }
}