﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MSON
{
    using System;
    using System.Collections.Generic;

    public partial class loaihang
    {
        public loaihang()
        {
            this.sanphams = new HashSet<sanpham>();
        }
        [DisplayName("Mã loại hàng")]
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public int ID { get; set; }
        [DisplayName("Tên loại hàng")]
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string TENLOAI { get; set; }
        [DisplayName("Mô tả")]
        public string MOTA { get; set; }

        [DisplayName("Ngày nhập")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Không được bỏ trống !")]

        public Nullable<System.DateTime> NGAYNHAP { get; set; }

        public virtual ICollection<sanpham> sanphams { get; set; }
    }
}
