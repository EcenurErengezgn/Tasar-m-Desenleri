﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TasarimDesenleri_odev1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DosyalamaArsivleme> DosyalamaArsivlemes { get; set; }
        public virtual DbSet<KagitUrunleri> KagitUrunleris { get; set; }
        public virtual DbSet<Mikroskop> Mikroskops { get; set; }
        public virtual DbSet<HesapMakinesi> HesapMakinesis { get; set; }
        public virtual DbSet<OkulCantalari> OkulCantalaris { get; set; }
        public virtual DbSet<OkulDefterleri> OkulDefterleris { get; set; }
        public virtual DbSet<ResimYolu> ResimYolus { get; set; }
    }
}
