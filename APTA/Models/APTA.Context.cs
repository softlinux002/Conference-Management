﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APTA.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class APTAEntities : DbContext
    {
        public APTAEntities()
            : base("name=APTAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CENTER> CENTERs { get; set; }
        public virtual DbSet<ORGANISER> ORGANISERs { get; set; }
        public virtual DbSet<EVENT> EVENTS { get; set; }
        public virtual DbSet<STUDENT> STUDENTS { get; set; }
    }
}
