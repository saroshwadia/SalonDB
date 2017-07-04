using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data
{
    // Define the below class, whenever the category related data is to be used in Scheduler.
    public class CategorizeSettings
    {
        public string Text { set; get; }
        public string ID { set; get; }
        public string FontColor { set; get; }
        public string Color { set; get; }
        
        public static List<CategorizeSettings> GetData()
        {
            var ReturnValue = new List<CategorizeSettings>();

            ReturnValue.Add(new SalonDB.Data.CategorizeSettings { ID = GetScheduledID(), Text = "Scheduled", Color = "#38b44a", FontColor = "#ffffff" });
            ReturnValue.Add(new SalonDB.Data.CategorizeSettings { ID = GetConfirmedID(), Text = "Confirmed", Color = "#efb73e", FontColor = "#ffffff" });
            ReturnValue.Add(new SalonDB.Data.CategorizeSettings { ID = GetCheckedInID(), Text = "Checked In", Color = "#e95420", FontColor = "#ffffff" });
            ReturnValue.Add(new SalonDB.Data.CategorizeSettings { ID = GetCheckedOutID(), Text = "Checked Out", Color = "#aea79f", FontColor = "#ffffff" });

            return ReturnValue;
        }

        public static string GetScheduledID()
        {
            return "1";
        }

        public static string GetConfirmedID()
        {
            return "2";
        }

        public static string GetCheckedInID()
        {
            return "3";
        }
        public static string GetCheckedOutID()
        {
            return "4";
        }

        public static string GetStatus(string ID)
        {
            var ReturnValue = "Unknown";
            var Data = GetData();
            var Found = Data.Where(c => c.ID == ID).SingleOrDefault();

            if (Found != null)
            {
                ReturnValue = Found.Text;
            }

            return ReturnValue;
        }

    }

}
