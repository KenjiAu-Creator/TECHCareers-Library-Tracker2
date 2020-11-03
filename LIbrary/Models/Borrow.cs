using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LIbrary.Models
{
  [Table("borrow")]
  public class Borrow
  {
    [Key]
    [Column(TypeName = "int(10)")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; private set; }

    [Column(TypeName = "date")]
    public string CheckedOutDate { get; private set; }

    [Column(TypeName = "date")]
    public DateTime DueDate { get; private set; }

    [Column(TypeName = "date")]
    public int ReturnedDate { get; private set; }

    [Column(TypeName ="int(10)")]
    public int BookID { get; set; }

    [ForeignKey(nameof(BookID))]
    [InverseProperty(nameof(Models.Book.Borrow))]
    public virtual Book Book { get; set; }
  }
}
