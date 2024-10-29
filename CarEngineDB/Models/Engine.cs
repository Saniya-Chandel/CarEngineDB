using System;
using System.Collections.Generic;

namespace CarEngineDB.Models;

public partial class Engine
{
    public int EngineId { get; set; }

    public string? EngineType { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
