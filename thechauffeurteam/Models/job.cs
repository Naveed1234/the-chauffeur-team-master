using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace thechauffeurteam.Models
{
    public class job
    {

        public int id { get; set; }

        public int? PassengerId { get; set; }

        public Passenger passenger { get; set; }

        public string PassengerName { get; set; }
        public string PassengerPhone { get; set; }

        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public string dateAndTime { get; set; }
        public string pickUp { get; set; }
        public int? PdoorNumber { get; set; }//new attribute
        public string DropUP { get; set; }
        public int? DdoorNumber { get; set; }//new attribute
        public string CarType { get; set; }

        public string JobType { get; set; }

        public string Price { get; set; }

        public string DriverMessage { get; set; }

        public int? status { get; set; }

        public int? Hours { get; set; }

        public int? Mile { get; set; }

        public string Attribute { get; set; }//new attribute

        public string Message { get; set; }




    }
}