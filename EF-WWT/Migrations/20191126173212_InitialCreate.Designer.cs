﻿// <auto-generated />
using System;
using EF_WWT.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_WWT.Migrations
{
    [DbContext(typeof(EFWWTContext))]
    [Migration("20191126173212_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF_WWT.Data.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(60);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("StateProvinceId")
                        .HasColumnName("StateProvinceID");

                    b.HasKey("AddressId");

                    b.ToTable("Address","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.AddressType", b =>
                {
                    b.Property<int>("AddressTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AddressTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("AddressTypeId");

                    b.ToTable("AddressType","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.BusinessEntity", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BusinessEntityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("BusinessEntityId");

                    b.ToTable("BusinessEntity","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.BusinessEntityAddress", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnName("BusinessEntityID");

                    b.Property<int>("AddressId")
                        .HasColumnName("AddressID");

                    b.Property<int>("AddressTypeId")
                        .HasColumnName("AddressTypeID");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("BusinessEntityId", "AddressId", "AddressTypeId")
                        .HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

                    b.ToTable("BusinessEntityAddress","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.BusinessEntityContact", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnName("BusinessEntityID");

                    b.Property<int>("PersonId")
                        .HasColumnName("PersonID");

                    b.Property<int>("ContactTypeId")
                        .HasColumnName("ContactTypeID");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("BusinessEntityId", "PersonId", "ContactTypeId")
                        .HasName("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID");

                    b.ToTable("BusinessEntityContact","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.ContactType", b =>
                {
                    b.Property<int>("ContactTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContactTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ContactTypeId");

                    b.ToTable("ContactType","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.CountryRegion", b =>
                {
                    b.Property<string>("CountryRegionCode")
                        .HasMaxLength(3);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CountryRegionCode")
                        .HasName("PK_CountryRegion_CountryRegionCode");

                    b.ToTable("CountryRegion","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.EmailAddress", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnName("BusinessEntityID");

                    b.Property<int>("EmailAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmailAddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress1")
                        .HasColumnName("EmailAddress")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("BusinessEntityId", "EmailAddressId")
                        .HasName("PK_EmailAddress_BusinessEntityID_EmailAddressID");

                    b.ToTable("EmailAddress","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.Password", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnName("BusinessEntityID");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.HasKey("BusinessEntityId")
                        .HasName("PK_Password_BusinessEntityID");

                    b.ToTable("Password","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.Person", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnName("BusinessEntityID");

                    b.Property<string>("AdditionalContactInfo")
                        .HasColumnType("xml");

                    b.Property<string>("Demographics")
                        .HasColumnType("xml");

                    b.Property<int>("EmailPromotion");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("NameStyle");

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Suffix")
                        .HasMaxLength(10);

                    b.Property<string>("Title")
                        .HasMaxLength(8);

                    b.HasKey("BusinessEntityId")
                        .HasName("PK_Person_BusinessEntityID");

                    b.ToTable("Person","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.PersonPhone", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnName("BusinessEntityID");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(25);

                    b.Property<int>("PhoneNumberTypeId")
                        .HasColumnName("PhoneNumberTypeID");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("BusinessEntityId", "PhoneNumber", "PhoneNumberTypeId")
                        .HasName("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID");

                    b.ToTable("PersonPhone","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.PhoneNumberType", b =>
                {
                    b.Property<int>("PhoneNumberTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PhoneNumberTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PhoneNumberTypeId");

                    b.ToTable("PhoneNumberType","Person");
                });

            modelBuilder.Entity("EF_WWT.Data.StateProvince", b =>
                {
                    b.Property<int>("StateProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StateProvinceID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryRegionCode")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<bool?>("IsOnlyStateProvinceFlag")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("StateProvinceCode")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<int>("TerritoryId")
                        .HasColumnName("TerritoryID");

                    b.HasKey("StateProvinceId");

                    b.ToTable("StateProvince","Person");
                });
#pragma warning restore 612, 618
        }
    }
}
