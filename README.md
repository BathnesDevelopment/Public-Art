# Public Art Catalogue Admin
Cataloguing the public artworks around the Bath & North East Somerset region.

The Public-Art admin interface solution is a Visual Studio solution comprised of the following projects:
- [PublicArt.DAL](PublicArt.DAL) - Entity Framework 6 Data Access Layer. Contains domain models imported from the database.
- [PublicArt.DB](PublicArt.DB) - SQL Server Data Tools (SSDT) project.
- [PublicArt.Util](PublicArt.Util) - Various helper classes and extension methods.
- [PublicArt.Web.Admin](PublicArt.Web.Admin) - ASP.NET MVC 5 project used to manage the public art data within the database.
