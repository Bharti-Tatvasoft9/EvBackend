using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace EVAPI.Models
{
    public class Evmachine : saveMachine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Machineid { get; set; }

        

    }

    public class saveMachine {
        public int? Stationid { get; set; }

        public string? Machinename { get; set; }
    }


}
