using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.Business.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El codigo es obligatorio")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,8}(\.\d{1,2})?$", ErrorMessage = "El precio debe tener como máximo 8 dígitos enteros y hasta 2 decimales.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "El numero del stock es obligatorio")]
        public int Stock { get; set; }
    }

    public class CreateArticleDto
    {
        [Required(ErrorMessage = "El codigo es obligatorio")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MaxLength(255, ErrorMessage = "El número máximo de caracteres es de 255!")]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,8}(\.\d{1,2})?$", ErrorMessage = "El precio debe tener como máximo 8 dígitos enteros y hasta 2 decimales.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [Required]
        public string Image { get; set; }

        [Required(ErrorMessage = "El numero del stock es obligatorio")]
        public int Stock { get; set; }
    }
}
