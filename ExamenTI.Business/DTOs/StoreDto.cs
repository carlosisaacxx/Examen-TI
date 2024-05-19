using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.Business.DTOs
{
    public class StoreDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La sucursal es obligatoria")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Address { get; set; }
    }

    public class CreateStoreDto
    {
        [Required(ErrorMessage = "La sucursal es obligatoria")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Address { get; set; }
    }
}
