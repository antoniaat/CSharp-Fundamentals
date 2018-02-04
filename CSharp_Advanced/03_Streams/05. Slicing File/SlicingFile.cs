namespace _05.Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SlicingFile
    {
        public static List<string> fileParts = new List<string>();

        public static void Main()
        {
            var partsCount = int.Parse(Console.ReadLine());

            SliceFileIntoParts(partsCount);

            AssembleFileFromParts();
        }

        private static void AssembleFileFromParts()
        {
            var buffer = new byte[4096];

            using (var assembledImage = new FileStream("assembledImage.jpg", FileMode.Create))
            {
                foreach (var item in fileParts)
                {
                    using (var reader = new FileStream(item, FileMode.Open))
                    {
                        while (true)
                        {
                            var readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;
                            assembledImage.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void SliceFileIntoParts(int partsCount)
        {
            Console.WriteLine($"Slicing file 'image.jpg' into {partsCount} parts");

            var buffer = new byte[4096];

            using (var sourceFile = new FileStream("image.jpg", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);

                for (var index = 0; index < partsCount; index++)
                {
                    var filePartName = $"Part-{index}.jpg";

                    fileParts.Add(filePartName);

                    using (var destinationFile = new FileStream(filePartName, FileMode.Create))
                    {
                        var totalBytes = 0;

                        while (totalBytes < partSize)
                        {
                            var readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) break;

                            destinationFile.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }
    }
}