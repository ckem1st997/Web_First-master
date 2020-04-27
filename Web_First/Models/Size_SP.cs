using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_First.Models
{
    public class Size_SP
    {
        [Key]
        [Required]
        public int stt { get; set; }
        [Required]
        public string Id_SP { get; set; }
        [Required]
        public string Id_SP_Option { get; set; }
        [Required]
        [StringLength(5)]
        public string Size { get; set; }
        [Required]
        [Range(0, 9999999.99)]
        public int sl { get; set; }
    }
}
