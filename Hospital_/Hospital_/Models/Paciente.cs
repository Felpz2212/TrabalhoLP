using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hospital_.Models
{
        [Table("Pacientes")]
        public class Paciente
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "Id:")]
            public int id { get; set; }

            [StringLength(40)]
            [Required(ErrorMessage = "Campo Nome é obrigatório!")]
            [Display(Name = "Nome:")]
            public string nome { get; set; }

            [Range(18, 70, ErrorMessage = "Idade mínima de 18 e máxima de 70")]
            [Display(Name = "Idade:")]
            public int idade { get; set; }

            [Required(ErrorMessage = "Campo sintomas é obrigatório")]
            [Display(Name = "Sintomas: ")]
            [StringLength(35)]
            public string sintomas { get; set; }

            public ICollection<Consulta> consultas { get; set; }
        }
}
