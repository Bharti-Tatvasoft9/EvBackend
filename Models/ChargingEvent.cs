using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVAPI.Models
{
    public class ChargingEvent
    {
        public int? Machineid { get; set; }

        public string? Status { get; set; }

        public DateTime? Timestamp { get; set; }
    }

}
