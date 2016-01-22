﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicArt.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PublicArtEntities : DbContext
    {
        public PublicArtEntities()
            : base("name=PublicArtEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemArtist> ItemArtists { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemImage> ItemImages { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImageThumbnail> ImageThumbnails { get; set; }
    
        public virtual ObjectResult<uspImage_Add_Result> uspImage_Add(string filename, byte[] filedata)
        {
            var filenameParameter = filename != null ?
                new ObjectParameter("filename", filename) :
                new ObjectParameter("filename", typeof(string));
    
            var filedataParameter = filedata != null ?
                new ObjectParameter("filedata", filedata) :
                new ObjectParameter("filedata", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspImage_Add_Result>("uspImage_Add", filenameParameter, filedataParameter);
        }
    
        public virtual int uspImage_Delete(Nullable<System.Guid> docId)
        {
            var docIdParameter = docId.HasValue ?
                new ObjectParameter("docId", docId) :
                new ObjectParameter("docId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspImage_Delete", docIdParameter);
        }
    }
}
