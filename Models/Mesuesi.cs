using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ligjerata_7___xhelali2.Models
{
    public class Mesuesi
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[]? Image { get; set; }

    }
}
