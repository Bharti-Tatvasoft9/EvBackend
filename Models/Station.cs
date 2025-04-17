using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVAPI.Models;

public partial class Station
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Stationid { get; set; }

    public string? Stationname { get; set; }

    public string? Address { get; set; }

    public string? Contactnumber { get; set; }

    public string? Email { get; set; }

}
