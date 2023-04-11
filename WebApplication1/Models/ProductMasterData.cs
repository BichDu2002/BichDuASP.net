using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace WebApplication1.Models
{
    public partial class ProductMasterData
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Tên danh mục")]
        public Nullable<int> Categoryld { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> Typeld { get; set; }
        [Display(Name = "Tên thương hiệu")]
        public Nullable<int> Brandld { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDes { get; set; }
        [Display(Name = "Mô tả đầy đủ")]
        public string FullDescriotion { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        [Display(Name = "Giá")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        public string Slug { get; set; }
        public Nullable<bool> Deleted { get; set; }
        [Display(Name = "Hiện thị trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUct { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedOnUct { get; set; }
    }
}







    
    
