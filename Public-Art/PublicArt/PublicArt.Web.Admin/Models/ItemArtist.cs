//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicArt.Web.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemArtist
    {
        public int ItemId { get; set; }
        public int ArtistId { get; set; }
        public string Notes { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public System.Guid rowguid { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual Item Item { get; set; }
    }
}
