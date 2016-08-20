using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using IndoorWeatherStation_WPF.DomainModel;
using IndoorWeatherStation_WPF.Ports;

namespace IndoorWeatherStation_WPF.Adapters
{
    internal class NdfdWeatherAdapter : IWeather
    {
        public async Task<WeatherData> GetWeatherAsync()
        {
            DateTime now = DateTime.Now;
            DateTime start = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);

            var request = HttpWebRequest.Create(string.Format(
                @"http://graphical.weather.gov/xml/sample_products/browser_interface/ndfdXMLclient.php?whichClient=NDFDgenMultiZipCode&lat=&lon=&listLatLon=&lat1=&lon1=&lat2=&lon2=&resolutionSub=&listLat1=&listLon1=&listLat2=&listLon2=&resolutionList=&endPoint1Lat=&endPoint1Lon=&endPoint2Lat=&endPoint2Lon=&listEndPoint1Lat=&listEndPoint1Lon=&listEndPoint2Lat=&listEndPoint2Lon=&zipCodeList=98008&listZipCodeList=&centerPointLat=&centerPointLon=&distanceLat=&distanceLon=&resolutionSquare=&listCenterPointLat=&listCenterPointLon=&listDistanceLat=&listDistanceLon=&listResolutionSquare=&citiesLevel=&listCitiesLevel=&sector=&gmlListLatLon=&featureType=&requestedTime=&startTime=&endTime=&compType=&propertyName=&product=time-series&begin={0}&end={1}&Unit=e&temp=temp&wx=wx&icons=icons&rh=rh&appt=appt&wwa=wwa&Submit=Submit",
                start.ToString("s"),
                start.AddHours(1).ToString("s")));

            // Wait for weather data.
            using (WebResponse response = await request.GetResponseAsync())
            // Get the stream containing content returned by the server.
            using (Stream dataStream = response.GetResponseStream())
            // Read data from stream.
            using (StreamReader reader = new StreamReader(dataStream))
            {
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                XDocument weatherDataDocument = XDocument.Parse(responseFromServer);

                var temp = weatherDataDocument
                    .Root
                    .Descendants("temperature")
                    .FirstOrDefault(element => element.Attribute("type").Value == "hourly")
                    .Descendants("value")
                    .FirstOrDefault()
                    .Value;

                var humidity = weatherDataDocument
                    .Root
                    .Descendants("humidity")
                    .FirstOrDefault(element => element.Attribute("type").Value == "relative")
                    .Descendants("value")
                    .FirstOrDefault()
                    .Value;

                if (temp != null && humidity != null)
                {
                    return await Task.FromResult(new WeatherData(
                        new Temperature(int.Parse(temp)), 
                        new Humidity(int.Parse(humidity))));
                }
            }

            return await Task.FromResult(WeatherData.Empty);
        }

        public void Dispose()
        {
            // Nothing to do.
        }
    }
}