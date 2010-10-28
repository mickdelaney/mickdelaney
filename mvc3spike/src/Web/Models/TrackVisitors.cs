using System.Web.Mvc;
using mvc3spike.Models.Services;

namespace mvc3spike.Models
{
    public class TrackVisitors : ActionFilterAttribute
    {
        private readonly ITrackerService _trackerService;
        
        public TrackVisitors(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //one way non blocking push of message. 
            _trackerService.Track(new TrackerInfo());
        }
    }
}