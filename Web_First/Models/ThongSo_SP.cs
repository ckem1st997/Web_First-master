using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_First.Models
{
    public class ThongSo_SP
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        [Display(Name = "Mã Sản Phẩm")]
        public string Id_SP { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Mã Loại Sản Phẩm")]
        public string Id_SP_Option { get; set; }
        [Required]

        [StringLength(20)]
        [Display(Name = "Màu sắc")]
        public string Loai_SP { get; set; }
        [Required]

        [Display(Name = "Size")]
        public string Size { get; set; }
        [Required]

        [Display(Name = "Số lượng")]

        public int SL_co { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày Thêm")]
        public DateTime Ngay_ADD { get; set; }
        [Required]
        [Key]
        [Display(Name = "Hình ảnh ( Nhập link của sản phẩm)")]
        [Url]
        public string Image_SP_Option { get; set; }

    }
}
