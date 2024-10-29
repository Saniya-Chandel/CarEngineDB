using System;
using System.Collections.Generic;

namespace CarEngineDB.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string? Model { get; set; }

    public int? EngineId { get; set; }

    public virtual Engine? Engine { get; set; }
}
