using System;
using System.IO;

namespace SpaceInvaders.Parsing
{
    /// <summary>
    /// Helper able to read the input ROM into RAM
    /// </summary>
    static public class RomReader
    {
        /// <summary>
        /// Reads into memory the ROM found at the given file path
        /// </summary>
        static public Stream Read(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                throw new FileNotFoundException("The ROM path is invalid.");

            // things are simple if we have only one input file, containing the whole rom
            if (!string.Equals(fileInfo.Extension, ".h", StringComparison.OrdinalIgnoreCase))
                return fileInfo.OpenRead();

            // on the other hand, if we have the four ROM files at disposition, the easiest thing to do is combining them into a new in-memory stream
            string baseFileName = Path.Combine(fileInfo.DirectoryName, Path.GetFileNameWithoutExtension(fileInfo.Name));
            var eFileInfo = new FileInfo(baseFileName + ".e");
            var fFileInfo = new FileInfo(baseFileName + ".f");
            var gFileInfo = new FileInfo(baseFileName + ".g");

            if (!eFileInfo.Exists || !fFileInfo.Exists || !gFileInfo.Exists)
                throw new FileNotFoundException("Unable to find all four parts of the ROM file");

            using (Stream hFile = fileInfo.OpenRead())
            using (Stream gFile = gFileInfo.OpenRead())
            using (Stream fFile = fFileInfo.OpenRead())
            using (Stream eFile = eFileInfo.OpenRead())
            {
                long totalLength = hFile.Length + gFile.Length + fFile.Length + eFile.Length;
                var result = new MemoryStream((int)(totalLength % int.MaxValue));

                hFile.CopyTo(result);
                gFile.CopyTo(result);
                fFile.CopyTo(result);
                eFile.CopyTo(result);

                result.Position = 0;
                return result;
            }
        }
    }
}
