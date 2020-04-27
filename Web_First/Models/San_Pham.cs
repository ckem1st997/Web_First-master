using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_First.Models
{
    public class San_Pham
    {
        [Required]
        [Key]
        [StringLength(20)]
        [Display(Name = "Mã Sản Phẩm")]
        public string Id_SP { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Danh mục")]
        public string Loai_SP_1 { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Loại sản phẩm")]
        public string Loai_SP_2 { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]
        public string Name_SP { get; set; }
        [Required]

        [Range(0, 9999999.99)]
        [Display(Name = "Giá sản phẩm")]
        public int Price_SP { get; set; }
        [Required]
        [Display(Name = "Mô tả")]
        public string Mo_Ta { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [Display(Name = "Ngày Thêm")]
        public DateTime ngay_add { get; set; }
        [Required]

        [Display(Name = "Sale theo %")]
        public int Sale { get; set; }
    }
}
