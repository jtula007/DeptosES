using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptosES.EntidadesDeNegocio
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Departamento")]
        [Required(ErrorMessage = "El departamento es requerido")]
        [Display(Name = "Departamento")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo es 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La imagen es requerida")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 200 caracteres")]
        public string Imagen { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public Departamento Departamento { get; set; }
    }
}
