// <auto-generated />
using System;
using Hospital_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital_.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220926142342_CreateInicial")]
    partial class CreateInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hospital_.Models.Consulta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("medicamentoid")
                        .HasColumnType("int");

                    b.Property<int>("medicoid")
                        .HasColumnType("int");

                    b.Property<int>("pacienteid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("medicamentoid");

                    b.HasIndex("medicoid");

                    b.HasIndex("pacienteid");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Hospital_.Models.Medicamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descricao")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("Hospital_.Models.Medico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("especialidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Hospital_.Models.Paciente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("idade")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("sintomas")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Hospital_.Models.Consulta", b =>
                {
                    b.HasOne("Hospital_.Models.Medicamento", "medicamento")
                        .WithMany("consultas")
                        .HasForeignKey("medicamentoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital_.Models.Medico", "medico")
                        .WithMany("consultas")
                        .HasForeignKey("medicoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital_.Models.Paciente", "paciente")
                        .WithMany("consultas")
                        .HasForeignKey("pacienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medicamento");

                    b.Navigation("medico");

                    b.Navigation("paciente");
                });

            modelBuilder.Entity("Hospital_.Models.Medicamento", b =>
                {
                    b.Navigation("consultas");
                });

            modelBuilder.Entity("Hospital_.Models.Medico", b =>
                {
                    b.Navigation("consultas");
                });

            modelBuilder.Entity("Hospital_.Models.Paciente", b =>
                {
                    b.Navigation("consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
