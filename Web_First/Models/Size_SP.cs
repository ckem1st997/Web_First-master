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
        public int stt { get; set; }
        public string Id_SP { get; set; }

        public string Id_SP_Option { get; set; }

        public string Size { get; set; }
        public int sl { get; set; }
    }
}
