using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_FNAF.DBOjects;

public partial class Animatronic
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("type")]
    [StringLength(50)]
    [Unicode(false)]
    public string Type { get; set; } = null!;

    [Column("id_type")]
    public int? IdType { get; set; }

    [Column("id_games")]
    public int? IdGames { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [ForeignKey("IdGames")]
    [InverseProperty("Animatronics")]
    public virtual Game? IdGamesNavigation { get; set; }

    [ForeignKey("IdType")]
    [InverseProperty("Animatronics")]
    public virtual TypeAnimatronic? IdTypeNavigation { get; set; }
}
