﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WystawkaDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WystawkaDBEntities : DbContext
    {
        public WystawkaDBEntities()
            : base("name=WystawkaDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Coord> Coords { get; set; }
        public virtual DbSet<Foto> Fotoes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Localization> Localizations { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}