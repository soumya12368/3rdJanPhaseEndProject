using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class Team1
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
