using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Domain.Models
{
    public class Empregado
    {
        [Table("Empregado")]
        public class Promocoes : BaseEntity
        {
            [Key]
            [Column("Matricula")]
            public int Matricula { get; set; }

            [Column("Nome")]
            public string Nome { get; set; }

            [Column("Idade")]
            public int Idade { get; set; }

            [Column("EstadoCivil")]
            public string EstadoCivil { get; set; }

            [Column("Email")]
            public string Email { get; set; }

            [Column("STATUS")]
            public int Status { get; set; }


        }
    }
}
