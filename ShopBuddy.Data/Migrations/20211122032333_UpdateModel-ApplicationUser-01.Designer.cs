﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopBuddy.Data;

#nullable disable

namespace ShopBuddy.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211122032333_UpdateModel-ApplicationUser-01")]
    partial class UpdateModelApplicationUser01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopBuddy.Data.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .HasColumnType("text");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}