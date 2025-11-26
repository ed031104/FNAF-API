using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_FNAF.DBOjects;

[Table("games")]
public partial class Game
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(100)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("release_year")]
    public int? ReleaseYear { get; set; }

    [InverseProperty("IdGamesNavigation")]
    public virtual ICollection<Animatronic> Animatronics { get; set; } = new List<Animatronic>();
}
