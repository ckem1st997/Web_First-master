using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_First.Models
{
    public class cart_clone
    {
        [Key]
        public int stt { get; set; }

        public string Id_SP { get; set; }

        public string Name_SP { get; set; }

        public int Price_SP { get; set; }

        public int sl { get; set; }

        public string image_sp { get; set; }
        public string Size { get; set; }
        public string Loai_SP { get; set; }
    }
}
