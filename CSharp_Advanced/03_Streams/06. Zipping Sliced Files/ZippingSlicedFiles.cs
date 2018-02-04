namespace _06.Zipping_Sliced_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class ZippingSlicedFiles
    {
        public static List<string> listFileParts = new List<string>();

        public static void Main()
        {
            Console.Write("Enter number of parts [int]: ");
            var partsCount = int.Parse(Console.ReadLine());

            SlicingFilesIntoZippedParts(partsCount);
            AssemblingFileFromZippedParts();
        }

        private static void AssemblingFileFromZippedParts()
        {
            Console.WriteLine("Assembling zipped file parts into 'assembledImage.jpg'");
            var buffer = new byte[4096];

            using (var assembledImage = new FileStream("assembledImage.jpg", FileMode.Create))
            {
                foreach (var part in listFileParts)
                {
                    using (var partsReader = new FileStream(part, FileMode.Open))
                    {
                        using (var compressedFile = new GZipStream(partsReader, CompressionMode.Decompress, false))
                        {
                            while (true)
                            {
                                var readBytes = compressedFile.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0) break;
                                assembledImage.Write(buffer, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }

        private static void SlicingFilesIntoZippedParts(int partsCount)
        {
            Console.WriteLine($"Slicing file 'image.jpg' into {partsCount} zipped parts:");
            var buffer = new byte[4096];

            using (var sourceFile = new FileStream($"image.jpg", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);

                for (var indexOfParts = 0; indexOfParts < partsCount; indexOfParts++)
                {
                    var filePartName = $"Part-{indexOfParts}.gz";
                    listFileParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        using (var compressedFile = new GZipStream(destinationFile, CompressionMode.Compress, false))
                        {
                            var totalBytes = 0;
                            while (totalBytes < partSize)
                            {
                                var readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0) break;
                                compressedFile.Write(buffer, 0, readBytes);
                                totalBytes += readBytes;
                            }
                        }
                    }
                    Console.WriteLine($"Part-{indexOfParts}.gz");
                }
            }
        }
    }
}