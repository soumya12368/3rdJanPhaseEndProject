using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string PlayerName { get; set; } = null!;

    public string PlayerType { get; set; } = null!;

    public int? PlayerTeam { get; set; }

    public virtual Team1? PlayerTeamNavigation { get; set; }
}
