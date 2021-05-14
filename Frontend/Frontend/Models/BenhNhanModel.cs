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
		public virtual DbSet<Root> Roots { get; set; }
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
	}

	public class Root
	{
		public string Key { get; set; }
		public Benhnhan Record { get; set; }
		public List<Benhnhan> benhnhan { get; set; }
	}
}