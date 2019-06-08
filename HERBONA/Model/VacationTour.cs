using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTrucking.Model
{
    public class VacationTourlistModel
    {
        public string ID { get; set; }
        public string TOUR_NAME { get; set; }
        public string LEFT_POINT { get; set; }
        public string LEFT_POINT_DETAIL { get; set; }
        public string RIGHT_POINT { get; set; }
        public string RIGHT_POINT_DETAIL { get; set; }
        public string IsActive { get; set; }
    }
    public class VacationTourModel
    {
        public string ID { get; set; }
        public string TOUR_NAME { get; set; }
        public string LEFT_POINT { get; set; }
        public string LEFT_POINT_DETAIL { get; set; }
        public string RIGHT_POINT { get; set; }
        public string RIGHT_POINT_DETAIL { get; set; }
        public string IsActive { get; set; }
    }
}