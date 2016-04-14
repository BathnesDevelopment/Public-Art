$MyFile = Get-Content "C:\PublicArtExport\PublicArtCatalogueData.csv"
$Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding($False)
[System.IO.File]::WriteAllLines("C:\PublicArtExport\PublicArtCatalogueData.csv", $MyFile, $Utf8NoBomEncoding)