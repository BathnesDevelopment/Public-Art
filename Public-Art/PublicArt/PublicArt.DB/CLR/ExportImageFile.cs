using System;
using System.Data.SqlTypes;
using System.IO;
using System.Security;
using Microsoft.SqlServer.Server;

namespace PublicArt.DB.CLR
{
    public class UserDefinedFunctions
    {
        [SqlFunction]
        public static SqlString ExportImageFile(SqlString path, SqlString fileName, SqlBytes bytes)
        {
            try
            {
                if (path == null) throw new ArgumentNullException("path");
                if (fileName == null) throw new ArgumentNullException("fileName");
                if (bytes == null) throw new ArgumentNullException("bytes");

                var fullPath = Directory.CreateDirectory(path.Value).FullName.TrimEnd(Path.DirectorySeparatorChar) +
                               Path.DirectorySeparatorChar + fileName.Value;

                File.WriteAllBytes(fullPath, bytes.Value);

                return new SqlString(fullPath);
            }
            catch (Exception e)
            {
                if (e is IOException || e is UnauthorizedAccessException || e is SecurityException)
                {
                    return new SqlString("ERROR: " + e.Message);
                }

                throw;
            }
        }
    }
}