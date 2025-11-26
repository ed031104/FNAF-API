using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_FNAF.DBOjects;

[Table("typeAnimatronics")]
[Index("TypeName", Name = "UQ__typeAnim__543C4FD97D6E4C8C", IsUnique = true)]
public partial class TypeAnimatronic
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string TypeName { get; set; } = null!;

    [InverseProperty("IdTypeNavigation")]
    public virtual ICollection<Animatronic> Animatronics { get; set; } = new List<Animatronic>();
}
