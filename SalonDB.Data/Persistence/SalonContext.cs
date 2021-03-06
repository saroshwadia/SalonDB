using System.Data.Entity;
using SalonDB.Data.Core.Domain;
using System.Data.Entity.Core.Objects;
using SalonDB.Data.Core;
using System;
using System.Data.Entity.Infrastructure;

namespace SalonDB.Data.Persistence
{

    [DbConfigurationType(typeof(SalonDBConfiguration))]
    public partial class SalonContext : DbContext
    {
        public SalonContext()
            : base("name=SalonContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffHour> StaffHours { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionDetailProduct> TransactionDetailProducts { get; set; }
        public virtual DbSet<TransactionDetailService> TransactionDetailServices { get; set; }
        public virtual DbSet<ProductTransactionsView> ProductTransactionsViews { get; set; }
        public virtual DbSet<SalesComparisonView> SalesComparisonViews { get; set; }
        public virtual DbSet<SalesOvertimePerServiceView> SalesOvertimePerServiceViews { get; set; }
        public virtual DbSet<SalesView> SalesViews { get; set; }
        public virtual DbSet<ServiceSalesMonthly> ServiceSalesMonthlies { get; set; }
        public virtual DbSet<ServiceTransactionsView> ServiceTransactionsViews { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }
        public virtual DbSet<View_2> View_2 { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.StaffHours)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Stores)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Discount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.Menu1)
                .WithOptional(e => e.Menu2)
                .HasForeignKey(e => e.ParentMenuID);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.WholesalePrice)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Commission)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Service>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Commission)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Rate)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.StaffHours)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StaffHour>()
                .HasOptional(e => e.StaffHour1)
                .WithRequired(e => e.StaffHour2);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.StaffHours)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.TransactionDetailProducts)
                .WithRequired(e => e.Transaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.TransactionDetailServices)
                .WithRequired(e => e.Transaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductTransactionsView>()
                .Property(e => e.Amount)
                .HasPrecision(29, 2);

            modelBuilder.Entity<ProductTransactionsView>()
                .Property(e => e.TType)
                .IsUnicode(false);

            modelBuilder.Entity<SalesComparisonView>()
                .Property(e => e.Revenue)
                .HasPrecision(38, 2);

            modelBuilder.Entity<SalesComparisonView>()
                .Property(e => e.CurrentYear)
                .HasPrecision(38, 2);

            modelBuilder.Entity<SalesComparisonView>()
                .Property(e => e.PreviousYear)
                .HasPrecision(38, 2);

            modelBuilder.Entity<SalesOvertimePerServiceView>()
                .Property(e => e.Amount)
                .HasPrecision(29, 2);

            modelBuilder.Entity<SalesOvertimePerServiceView>()
                .Property(e => e.TType)
                .IsUnicode(false);

            modelBuilder.Entity<SalesView>()
                .Property(e => e.Amount)
                .HasPrecision(29, 2);

            modelBuilder.Entity<SalesView>()
                .Property(e => e.TType)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceSalesMonthly>()
                .Property(e => e.Amount)
                .HasPrecision(29, 2);

            modelBuilder.Entity<ServiceTransactionsView>()
                .Property(e => e.Amount)
                .HasPrecision(29, 2);

            modelBuilder.Entity<ServiceTransactionsView>()
                .Property(e => e.TType)
                .IsUnicode(false);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();  
        }
    }
}
