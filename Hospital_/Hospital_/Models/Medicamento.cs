using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hospital_.Models
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id:")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome: ")]
        [StringLength(35)]
        public string nome { get; set; }

        [Display(Name = "Descrição: ")]
        [StringLength(40)]
        public string descricao { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float quantidade { get; set; }

        public ICollection<Consulta> consultas { get; set; }

        [Display(Name = "Total: ")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public virtual float total
        {
            get { return quantidade * valor; }
        }
    }
}
