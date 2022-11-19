using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using labWork22_WPF_.Models;

namespace labWork22_WPF_.Data;

public partial class Ispp0104Context : DbContext
{
    public Ispp0104Context()
    {
    }

    public Ispp0104Context(DbContextOptions<Ispp0104Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<DeleteBuyer> DeleteBuyers { get; set; }

    public virtual DbSet<GeneralOrderProductView> GeneralOrderProductViews { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Lw131Order> Lw131Orders { get; set; }

    public virtual DbSet<Lw131OrderList> Lw131OrderLists { get; set; }

    public virtual DbSet<Lw131Pizza> Lw131Pizzas { get; set; }

    public virtual DbSet<Lw131Promocode> Lw131Promocodes { get; set; }

    public virtual DbSet<Lw132User> Lw132Users { get; set; }

    public virtual DbSet<Lw133Ingredient> Lw133Ingredients { get; set; }

    public virtual DbSet<Lw133Pizza> Lw133Pizzas { get; set; }

    public virtual DbSet<Lw22Game> Lw22Games { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderInfo> OrderInfos { get; set; }

    public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }

    public virtual DbSet<ProdictInformation> ProdictInformations { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SmartPhoneUpdateView> SmartPhoneUpdateViews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=prserver\\SQLEXPRESS;Initial Catalog=ispp0104;User ID=ispp0104;Password=0104;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.IdBuyer);

            entity.ToTable("Buyer", tb => tb.HasTrigger("Buyer_DELETE"));

            entity.HasIndex(e => e.Email, "UQ_Email").IsUnique();

            entity.HasIndex(e => e.Login, "UQ_Login").IsUnique();

            entity.Property(e => e.IdBuyer).HasColumnName("idBuyer");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.Telephone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DeleteBuyer>(entity =>
        {
            entity.HasKey(e => e.IdDeleteBuyer);

            entity.ToTable("DeleteBuyer");

            entity.Property(e => e.IdDeleteBuyer).HasColumnName("idDeleteBuyer");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DateDeleteBuyer)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdBuyer).HasColumnName("idBuyer");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Telephone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<GeneralOrderProductView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GeneralOrderProductView");

            entity.Property(e => e.ВремяЗаказа)
                .HasColumnType("smalldatetime")
                .HasColumnName("Время заказа");
            entity.Property(e => e.Логин)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.НомерЗаказа).HasColumnName("Номер заказа");
            entity.Property(e => e.ПолноеИмя)
                .HasMaxLength(101)
                .HasColumnName("Полное Имя");
            entity.Property(e => e.Продукт).HasMaxLength(154);
            entity.Property(e => e.Стоимость).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Цена).HasColumnType("decimal(7, 2)");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.IdLog).HasName("PK_Logs_1");

            entity.Property(e => e.IdLog).HasColumnName("idLog");
            entity.Property(e => e.CurrentUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Operation)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lw131Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("LW13_1_Orders");

            entity.Property(e => e.IdOrder).ValueGeneratedNever();
            entity.Property(e => e.DateOfOrder).HasColumnType("datetime");

            entity.HasOne(d => d.IdPromocodeNavigation).WithMany(p => p.Lw131Orders)
                .HasForeignKey(d => d.IdPromocode)
                .HasConstraintName("FK_LW13_1_Orders_LW13_1_Promocodes");
        });

        modelBuilder.Entity<Lw131OrderList>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdPizza });

            entity.ToTable("LW13_1_OrderList");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Lw131OrderLists)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LW13_1_OrderList_LW13_1_Orders");

            entity.HasOne(d => d.IdPizzaNavigation).WithMany(p => p.Lw131OrderLists)
                .HasForeignKey(d => d.IdPizza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LW13_1_OrderList_LW13_1_Pizza");
        });

        modelBuilder.Entity<Lw131Pizza>(entity =>
        {
            entity.HasKey(e => e.IdPizza);

            entity.ToTable("LW13_1_Pizza");

            entity.Property(e => e.IdPizza).ValueGeneratedNever();
            entity.Property(e => e.Ingredients).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Lw131Promocode>(entity =>
        {
            entity.HasKey(e => e.IdPromocode);

            entity.ToTable("LW13_1_Promocodes");

            entity.Property(e => e.IdPromocode).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Lw132User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LW13_2_Users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ip");
            entity.Property(e => e.Lastenter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastenter");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Lw133Ingredient>(entity =>
        {
            entity.HasKey(e => e.IdIngredient);

            entity.ToTable("LW13_3_Ingredient");

            entity.HasIndex(e => e.Name, "UQ_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Lw133Pizza>(entity =>
        {
            entity.HasKey(e => e.IdPizza).HasName("PK_LW13_3_PizzaIngredients");

            entity.ToTable("LW13_3_Pizza");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.IdIndgredients).WithMany(p => p.IdPizzas)
                .UsingEntity<Dictionary<string, object>>(
                    "Lw133Compound",
                    r => r.HasOne<Lw133Ingredient>().WithMany()
                        .HasForeignKey("IdIndgredient")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LW13_3_Compound_LW13_3_Ingredient"),
                    l => l.HasOne<Lw133Pizza>().WithMany()
                        .HasForeignKey("IdPizza")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LW13_3_Compound_LW13_3_Pizza"),
                    j =>
                    {
                        j.HasKey("IdPizza", "IdIndgredient");
                        j.ToTable("LW13_3_Compound");
                    });
        });

        modelBuilder.Entity<Lw22Game>(entity =>
        {
            entity.HasKey(e => e.IdGame).HasName("PK__LW22_Gam__A304AD9B51FF37A1");

            entity.ToTable("LW22_Games");

            entity.Property(e => e.IdGame).HasColumnName("idGame");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.LogoFile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("logoFile");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.IdManufacturer);

            entity.ToTable("Manufacturer");

            entity.HasIndex(e => e.Name, "UQ_Name").IsUnique();

            entity.Property(e => e.IdManufacturer).HasColumnName("idManufacturer");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .HasDefaultValueSql("('Россия')");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("Order", tb =>
                {
                    tb.HasTrigger("DeleteEmptyOrders");
                    tb.HasTrigger("Order_DateUpdate");
                });

            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.DataTimeOrder).HasColumnType("smalldatetime");
            entity.Property(e => e.IdBuyer).HasColumnName("idBuyer");

            entity.HasOne(d => d.IdBuyerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdBuyer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Buyer_Order");
        });

        modelBuilder.Entity<OrderInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("OrderInfo");

            entity.Property(e => e.ВремяЗаказа)
                .HasColumnType("smalldatetime")
                .HasColumnName("Время заказа");
            entity.Property(e => e.Логин)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.НомерЗаказа).HasColumnName("Номер заказа");
            entity.Property(e => e.ПолноеИмя)
                .HasMaxLength(101)
                .HasColumnName("Полное Имя");
        });

        modelBuilder.Entity<OrderedProduct>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct });

            entity.ToTable("OrderedProduct");

            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Count).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderedProducts)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderedProduct_Order");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderedProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderedProduct_Product");
        });

        modelBuilder.Entity<ProdictInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProdictInformation");

            entity.Property(e => e.IdПродукта).HasColumnName("id Продукта");
            entity.Property(e => e.Продукт).HasMaxLength(154);
            entity.Property(e => e.Цена).HasColumnType("decimal(7, 2)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("Product", tb =>
                {
                    tb.HasTrigger("InsertLogTrigger");
                    tb.HasTrigger("MarkingDeletedProduct");
                });

            entity.HasIndex(e => new { e.IdManufacturer, e.Model }, "UQ_Model_idManufacturer").IsUnique();

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.IdManufacturer).HasColumnName("idManufacturer");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.Mass).HasColumnType("decimal(4, 3)");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.RealeseYear).HasDefaultValueSql("(datepart(year,getdate()))");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'смартфон')");

            entity.HasOne(d => d.IdManufacturerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdManufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Manufacturer_Product");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SmartPhoneUpdateView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SmartPhoneUpdateView");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.IdManufacturer).HasColumnName("idManufacturer");
            entity.Property(e => e.IdProduct)
                .ValueGeneratedOnAdd()
                .HasColumnName("idProduct");
            entity.Property(e => e.Mass).HasColumnType("decimal(4, 3)");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
