//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhGiaSach
    {
        public int MaSach { get; set; }
        public int MaKH { get; set; }
        public string NoiDungDanhGia { get; set; }
        public Nullable<System.DateTime> ThoiGianDang { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
