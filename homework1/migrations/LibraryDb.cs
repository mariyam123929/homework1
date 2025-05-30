﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiHomeTask1.Data.Contexts;

#nullable disable

namespace WebApiHomeTask1.Migrations
{
    [DbContext(typeof(LibraryDb))]
    partial class LibraryDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.Author", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("AuthorName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Authors");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.AuthorBook", b =>
            {
                b.Property<Guid>("AuthorId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("BookId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("AuthorId", "BookId");

                b.HasIndex("BookId");

                b.ToTable("AuthorBooks");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.Book", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("BookName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Books");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.BookGenre", b =>
            {
                b.Property<Guid>("BookId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("GenreId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("BookId", "GenreId");

                b.HasIndex("GenreId");

                b.ToTable("BookGenres");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.Genre", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("GenreName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Genres");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.AuthorBook", b =>
            {
                b.HasOne("WebApiHomeTask1.Data.Models.Author", "Author")
                    .WithMany("AuthorBooks")
                    .HasForeignKey("AuthorId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("WebApiHomeTask1.Data.Models.Book", "Book")
                    .WithMany("AuthorBooks")
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Author");

                b.Navigation("Book");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.BookGenre", b =>
            {
                b.HasOne("WebApiHomeTask1.Data.Models.Book", "Book")
                    .WithMany("BookGenres")
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("WebApiHomeTask1.Data.Models.Genre", "Genre")
                    .WithMany("BookGenres")
                    .HasForeignKey("GenreId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Book");

                b.Navigation("Genre");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.Author", b =>
            {
                b.Navigation("AuthorBooks");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.Book", b =>
            {
                b.Navigation("AuthorBooks");

                b.Navigation("BookGenres");
            });

            modelBuilder.Entity("WebApiHomeTask1.Data.Models.Genre", b =>
            {
                b.Navigation("BookGenres");
            });
#pragma warning restore 612, 618
        }
    }
}
