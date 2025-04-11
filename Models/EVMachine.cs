using static System.Collections.Specialized.BitVector32;

namespace EVAPI.Models
{
    public class EVMachine
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public int StationId { get; set; }
    }

}
