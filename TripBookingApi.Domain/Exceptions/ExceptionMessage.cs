using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripBookingApi.Domain.Exceptions
{
    public class ExceptionMessage
    {
        public int StatusCode { get; set; }
        public string Content { get; set; } = "";
    }
}
