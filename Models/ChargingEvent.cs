using System.ComponentModel.DataAnnotations.Schema;

namespace EVAPI.Models
{
    public class ChargingEvent
    {
        public int MachineId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }

}
