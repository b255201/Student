﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudentEntities : DbContext
    {
        public StudentEntities()
            : base("name=StudentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FreeTrail> FreeTrails { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<employeeCategory> employeeCategories { get; set; }
        public virtual DbSet<employeeCategoryDetail> employeeCategoryDetails { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<JuniorHigh_School> JuniorHigh_School { get; set; }
        public virtual DbSet<elementary_Book> elementary_Book { get; set; }
        public virtual DbSet<High_Book> High_Book { get; set; }
        public virtual DbSet<junior_Book> junior_Book { get; set; }
        public virtual DbSet<Activity_Message> Activity_Message { get; set; }
        public virtual DbSet<LastNew> LastNews { get; set; }
        public virtual DbSet<JuniorClass> JuniorClasses { get; set; }
        public virtual DbSet<AdultClass> AdultClasses { get; set; }
        public virtual DbSet<ChildClass> ChildClasses { get; set; }
        public virtual DbSet<HighClass> HighClasses { get; set; }
    }
}
