using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room_Reservation_System.Core.Validator.DataAnnotations
{
    public class DateTimeRange : ValidationAttribute
    {
        TimeOnly _StartTime;
        TimeOnly _EndTime;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="startTime">time format "h:mm tt"</param>
        /// <param name="endTime">time format "h:mm tt"</param>
        public DateTimeRange(string errorMessage,string startTime ,string endTime) : base(errorMessage)
        {
            _StartTime= TimeOnly.ParseExact(startTime, "h:mm tt");
            _EndTime= TimeOnly.ParseExact(endTime, "h:mm tt");
        }
        public override bool IsValid(object? value)
        {
            DateTime time = (DateTime)value;
            return time.TimeOfDay.CompareTo(_StartTime)>1  && time.TimeOfDay.CompareTo(_EndTime)<-1;
        }
    }
}
