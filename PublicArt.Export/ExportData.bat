REM Set up the database connection, locations, and password.
SET SERVER=
SET DBNAME=
SET DBUSER=
SET DBPASS=
SET EXPORTFOLDER=
SET COPYDATALOCATION=
SET COPYIMAGELOCATION=

REM BCP out using the uspExportData stored procedure on the database.  This is pushed to the 
bcp "EXEC %DBNAME%.dbo.uspExportData @columnHeaders = 1" queryout "%EXPORTFOLDER%PublicArtCatalogueData.csv" -w -t, -S"%SERVER%" -U"%DBUSER%" -P"%DBPASS%"
SLEEP 10
REM BCP and SQL Server seems a bit limited in terms of the encoding - it can't do UTF-8 (until v2016) and the Socrata DataSync program doesn't like the file.  Convert it using Powershell.
Powershell -executionpolicy remotesigned -File %EXPORTFOLDER%ConvertUTF8.ps1
SLEEP 10
REM This step copies the data file to the server where we do open data publishing (could skip)
COPY "%EXPORTFOLDER%PublicArtCatalogueData.csv" "%COPYDATALOCATION%PublicArtCatalogueData.csv"

REM Now export the images - firstly generate a batch file to output each image.
bcp "SELECT 'bcp \"select file_stream from %DBNAME%.dbo.[ItemImage] where stream_id=''' + cast(im.stream_id as varchar(50)) + '''\" queryout \"%EXPORTFOLDER%Images\fullsize\' + it.Reference + '-' + SUBSTRING('abcdefghijklmnopqrstuvwxyz',ROW_NUMBER() OVER (Partition By it.ItemId Order By im.[Primary] DESC, im.stream_id),1) + '.jpg\" -S\"%SERVER%\" -f \"%EXPORTFOLDER%ItemImage.fmt\" -U\"%DBUSER%\" -P\"%DBPASS%\"' from %DBNAME%.dbo.[ItemImage] im JOIN %DBNAME%.dbo.[Item] it ON it.ItemId = im.ItemId ORDER BY im.ItemId, im.[Primary] DESC, im.stream_id" queryout "%EXPORTFOLDER%ExportImageFiles.bat" -c -S"%SERVER%" -U"%DBUSER%" -P"%DBPASS%"
SLEEP 10
REM And do the same for the thumbnails
bcp "SELECT 'bcp \"select file_stream from %DBNAME%.dbo.[ImageThumbnail] where stream_id=''' + cast(im.stream_id as varchar(50)) + '''\" queryout \"%EXPORTFOLDER%Images\thumbnails\' + it.Reference + '-' + SUBSTRING('abcdefghijklmnopqrstuvwxyz',ROW_NUMBER() OVER (Partition By it.ItemId Order By im.[Primary] DESC, im.stream_id),1) + '.jpg\" -S\"%SERVER%\" -f \"%EXPORTFOLDER%ItemImage.fmt\" -U\"%DBUSER%\" -P\"%DBPASS%\"' from %DBNAME%.dbo.[ItemImage] im JOIN %DBNAME%.dbo.[Item] it ON it.ItemId = im.ItemId ORDER BY im.ItemId, im.[Primary] DESC, im.stream_id" queryout "%EXPORTFOLDER%ExportImageFileThumbnails.bat" -c -S"%SERVER%" -U"%DBUSER%" -P"%DBPASS%"
SLEEP 10

REM Run the generated batch files to export all the images (using bcp)
REM %EXPORTFOLDER%ExportImageFiles.bat
REM %EXPORTFOLDER%ExportImageFileThumbnails.bat