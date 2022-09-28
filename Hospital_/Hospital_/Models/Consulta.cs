using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hospital_.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id:")]
        public int id { get; set; }

        [Display(Name = "Data: ")]
        public DateTime data { get; set; }

        [Display(Name = "Paciente: ")]
        public Paciente paciente { get; set; }
        [Display(Name = "Paciente: ")]
        public int pacienteid { get; set; }

        [Display(Name = "Medico: ")]
        public Medico medico { get; set; }
        [Display(Name = "Medico: ")]
        public int medicoid { get; set; }

        [Display(Name = "Medicamento: ")]
        public Medicamento medicamento { get; set; }
        [Display(Name = "Medicamento: ")]
        public int medicamentoid { get; set; }
    }
}
