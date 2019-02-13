using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IllyaVirych.Web.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string NameTask { get; set; }
        public string DescriptionTask { get; set; }
        public bool StatusTask { get; set; }
        public string UserId { get; set; }
        public double LalitudeMarker { get; set; }
        public double LongitudeMarker { get; set; }
    }
}