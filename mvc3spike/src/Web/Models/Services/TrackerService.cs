using System;

namespace mvc3spike.Models.Services
{
    public class TrackerService : ITrackerService 
    {
        public void Track(TrackerInfo trackerInfo)
        {
            Console.WriteLine(trackerInfo.ToString());
        }
    }

    public interface ITrackerService
    {
        void Track(TrackerInfo trackerInfo);
    }

    public class TrackerInfo
    {
    }
}