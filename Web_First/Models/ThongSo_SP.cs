using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_First.Models
{
    public class ThongSo_SP
    {

        public string Id_SP { get; set; }

        public string Id_SP_Option { get; set; }

        public string Loai_SP { get; set; }
        public string Size { get; set; }
        public int SL_co { get; set; }
        public DateTime Ngay_ADD { get; set; }
        [Key]
        public string Image_SP_Option { get; set; }

    }
}
