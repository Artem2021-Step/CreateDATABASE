using EFCreatingDatabase.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCreatingDatabase.DAL
{
    public class EFContext : DbContext
    {
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUserRoles> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=allah;Username=gomonmax;Password=578947001");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AspNetUserRoles>(userRoles => 
            {
                ////////////////////////////////////////////
                userRoles.HasKey(userRolesPrimaryKey => new { userRolesPrimaryKey.RoleId, userRolesPrimaryKey.UserId });
                ////////////////////////////////////////////
                userRoles.HasOne(userRolesVirtualElementFromClassRoles => userRolesVirtualElementFromClassRoles.Role)
                .WithMany(userRolesVirtualCollectionFromClassUserRoles => userRolesVirtualCollectionFromClassUserRoles.UserRoles)
                .HasForeignKey(userRolesColumnWithForeignKeyConstraint => userRolesColumnWithForeignKeyConstraint.RoleId)
                .IsRequired();
                ////////////////////////////////////////////
                userRoles.HasOne(userRolesVirtualElementFromClassUser => userRolesVirtualElementFromClassUser.User)
                .WithMany(userRolesVirtualCollectionFromClassUserRoles => userRolesVirtualCollectionFromClassUserRoles.UserRoles)
                .HasForeignKey(userRolesIntColumnWithForeignKeyConstraint => userRolesIntColumnWithForeignKeyConstraint.UserId)
                .IsRequired();
                ////////////////////////////////////////////
            });
        }
    }
}
