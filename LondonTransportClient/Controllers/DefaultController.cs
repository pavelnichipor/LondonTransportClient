using System.Web.Mvc;

namespace LondonTransportClient.Controllers
{
    public class DefaultController : Controller
    {
        private readonly LondonTransportApi _londonTransportApi = new LondonTransportApi();

        public ActionResult StationSearch(string term)
        {
            var response = _londonTransportApi.StationSearch(term);
            return View(response);
        }

        public ActionResult RoadState()
        {
            var response = _londonTransportApi.RoadState();
            return View(response);
        }

        public ActionResult AirQuality()
        {
            var response = _londonTransportApi.AirQuality();
            return View(response);
        }
    }
}