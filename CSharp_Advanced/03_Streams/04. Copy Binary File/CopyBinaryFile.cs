namespace _04.Copy_Binary_File
{
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            var sourceFilePath = "image.png";
            var copyFilePath = "imageCopy.png";

            using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var copyFile = new FileStream(copyFilePath, FileMode.Create))
                {
                    var buffer = new byte[4096];

                    while (true)
                    {
                        var readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) break;
                        copyFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}