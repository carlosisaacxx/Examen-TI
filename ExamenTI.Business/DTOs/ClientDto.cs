using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.Business.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "El número máximo de caracteres es de 60!")]
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }

    public class CreateClientDto {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "El número máximo de caracteres es de 60!")]
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
