namespace Frontend.Models
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
	using System.Linq;

	public class BenhNhanModel : DbContext
	{
		// Your context has been configured to use a 'BenhNhanModel' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'Frontend.Models.BenhNhanModel' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'BenhNhanModel' 
		// connection string in the application configuration file.
		public BenhNhanModel()
			: base("name=BenhNhanModel")
		{
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Benhnhan> BenhNhans { get; set; }
	}

	public class Benhnhan
	{
		[Key]
		[Display(Name= "Mã bệnh nhân")]
		public string mabn { get; set; }
		[Display(Name = "Họ tên")]
		public string hoten { get; set; }
		[Display(Name = "Ngày sinh")]
		public string ngaysinh { get; set; }
		[Display(Name = "Giới tính")]
		public string gioitinh { get; set; }
		[Display(Name = "CMND/CCCD")]
		public string cmnd { get; set; }
		[Display(Name = "Địa chỉ")]
		public string diachi { get; set; }
		[Display(Name = "Mã xã")]
		public string maxa { get; set; }
		[Display(Name = "Bệnh án")]
		public string ba { get; set; }
		public string key { get; set; }
    }

    public class Quatrinhdt
    {
        public string iddienbien { get; set; }
        public int mach { get; set; }
        public double nhietdo { get; set; }
        public string huyetap { get; set; }
        public double cannang { get; set; }
        public int nhiptho { get; set; }
        public string ngaykcb { get; set; }
        public string manv { get; set; }
        public string bacsi { get; set; }
        public string maicd { get; set; }
        public string kqcdoan { get; set; }
        public string maicdp { get; set; }
        public string kqcdoanp { get; set; }
        public string lydo { get; set; }
        public string dienbien { get; set; }
        public string chamsoc { get; set; }
    }

    public class Thuoc
    {
        public string mahh { get; set; }
        public string tenthuoc { get; set; }
        public string dvt { get; set; }
        public double soluong { get; set; }
        public string cachuong { get; set; }
        public string ngaykcb { get; set; }
        public string manv { get; set; }
        public string bacsi { get; set; }
        public string maicd { get; set; }
        public string kqcdoan { get; set; }
        public string maicdp { get; set; }
        public string kqcdoanp { get; set; }
        public string iddienbien { get; set; }
    }

    public class Cl
    {
        public string macls { get; set; }
        public string tencls { get; set; }
        public string dvt { get; set; }
        public double soluong { get; set; }
        public string ngaykcb { get; set; }
        public string manv { get; set; }
        public string bacsi { get; set; }
        public string maicd { get; set; }
        public string kqcdoan { get; set; }
        public string maicdp { get; set; }
        public string kqcdoanp { get; set; }
        public string ketqua { get; set; }
        public string trisobt { get; set; }
    }

    public class Benhan
    {
        public string mabn { get; set; }
        public string maba { get; set; }
        public string makb { get; set; }
        public string hoten { get; set; }
        public string ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public string cmnd { get; set; }
        public string diachi { get; set; }
        public string maxa { get; set; }
        public string ngayvv { get; set; }
        public string ngayrv { get; set; }
        public string maicd { get; set; }
        public string kqcdoan { get; set; }
        public string maicdp { get; set; }
        public string kqcdoanp { get; set; }
        public string lydovv { get; set; }
        public List<Quatrinhdt> quatrinhdt { get; set; }
        public List<Thuoc> thuoc { get; set; }
        public List<Cl> cls { get; set; }
    }

    public class ChiTietBenhAn
    {
        public List<Benhan> benhan { get; set; }
    }
}