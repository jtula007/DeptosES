using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptosES.EntidadesDeNegocio
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(30, ErrorMessage = "El largo máximo es de 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La zona es requerida")]
        public byte Zona { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Municipio> Municipio { get; set; }
    }

    public enum Zona_Depto
    {
        OCCIDENTAL = 1,
        CENTRAL = 2,
        ORIENTAL = 3
    }
}
