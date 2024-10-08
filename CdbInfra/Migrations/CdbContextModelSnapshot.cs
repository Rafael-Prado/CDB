﻿// <auto-generated />
using CdbInfra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CdbInfra.Migrations
{
    [DbContext(typeof(CdbContext))]
    partial class CdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CdbDomain.Domain.TaxaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cdb")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tb")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TaxaBancarias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cdb = 0.009m,
                            Tb = 1.08m
                        });
                });

            modelBuilder.Entity("CdbDomain.Domain.TaxaMensal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Meses")
                        .HasColumnType("int");

                    b.Property<decimal>("Taxa")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TaxaMensal");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Meses = 6,
                            Taxa = 0.225m
                        },
                        new
                        {
                            Id = 2,
                            Meses = 12,
                            Taxa = 0.20m
                        },
                        new
                        {
                            Id = 3,
                            Meses = 24,
                            Taxa = 0.175m
                        },
                        new
                        {
                            Id = 4,
                            Meses = 0,
                            Taxa = 0.15m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
