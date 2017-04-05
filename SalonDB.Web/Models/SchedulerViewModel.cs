using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonDB.Web.Models
{
    public class SchedulerEntity
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Categorize { get; set; }
        public string RoomId { get; set; }
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Priority { get; set; }
        public bool AllDay { get; set; }
        public bool Recurrence { get; set; }
        public string RecurrenceRule { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
    }

    public class ResourceFields
    {
        public string Text { set; get; }
        public string Id { set; get; }
        public string GroupId { set; get; }
        public string Color { set; get; }
        public int WorkHourStart { set; get; }
        public int WorkHourEnd { set; get; }
        public List<string> CustomDays { set; get; }
    }

    // Define the below class, whenever the category related data is to be used in Scheduler.
    public class CategorizeSettings
    {
        public string Text { set; get; }
        public string Id { set; get; }
        public string FontColor { set; get; }
        public string Color { set; get; }
    }

    // Define the below class, whenever the priorities are to be used for Scheduler appointments.
    public class PrioritySettings
    {
        public string Text { set; get; }
        public string Value { set; get; }
    }

    // Define the below two classes (Appointment and Cells), if context menu items are to be used in the Scheduler.
    public class Appointment
    {
        public string Text { set; get; }
        public string Id { set; get; }
    }
    public class Cells
    {
        public string Text { set; get; }
        public string Id { set; get; }
        public string ParentId { set; get; }
    }

    // Define the below class, if timezone collection to be specified for Scheduler.
    public class TimezoneCollection
    {
        public string Text { set; get; }
        public string Id { set; get; }
        public string Value { set; get; }
    }

    public class SchedulerViewModel
    {
        public DateTime CurrentDate { get; set; }
        public List<SchedulerEntity> SchedulerCol { get; set; }
        public List<string> GroupCol { get; set; }
        public List<Syncfusion.JavaScript.Models.Appointment> AppContextMenu { get; set; }
        public List<ResourceFields> ResourceCol { get; set; }
    }
           
}