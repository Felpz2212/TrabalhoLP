using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hospital_.Models
{
        [Table("Medicos")]
        public class Medico
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "Id:")]
            public int id { get; set; }

            [Required(ErrorMessage = "Campo nome é obrigatório")]
            [Display(Name = "Nome: ")]
            [StringLength(35)]
            public string nome { get; set; }

            [Required(ErrorMessage = "Campo email é obrigatório")]
            [Display(Name = "Email: ")]
            [StringLength(35)]
            public string email { get; set; }

            [Display(Name = "Especialidade: ")]
            public string especialidade { get; set; }

            public ICollection<Consulta> consultas { get; set; }
      }
}
