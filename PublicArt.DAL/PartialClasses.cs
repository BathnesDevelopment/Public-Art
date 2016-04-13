using System.ComponentModel.DataAnnotations;

namespace PublicArt.DAL
{
    [MetadataType(typeof (ArtistMetadata))]
    public partial class Artist
    {
    }

    [MetadataType(typeof (CategoryMetadata))]
    public partial class Category
    {
    }

    [MetadataType(typeof (ImageMetadata))]
    public partial class Image
    {
    }

    [MetadataType(typeof(ItemMetadata))]
    public partial class Item
    {
        public bool HasImages => ItemImages.Count > 0;
    }

    [MetadataType(typeof (ItemArtistMetadata))]
    public partial class ItemArtist
    {
    }

    [MetadataType(typeof (ItemCategoryMetadata))]
    public partial class ItemCategory
    {
    }

    [MetadataType(typeof (ItemImageMetadata))]
    public partial class ItemImage
    {
    }
}