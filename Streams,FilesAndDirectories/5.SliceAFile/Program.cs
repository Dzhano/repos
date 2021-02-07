using System;
using System.IO;

namespace _5.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream streamReader = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                int sizeStreamReader = (int) streamReader.Length / 4;
                for (int i = 1; i <= 4; i++)
                {
                    byte[] buffer = new byte[1];
                    int count = 0;
                    using (FileStream streamWriter = new FileStream($"../../../Part-{i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (count < sizeStreamReader)
                        {
                            streamReader.Read(buffer, 0, buffer.Length);
                            streamWriter.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;
                        }

                        if (streamReader.Position != streamReader.Length && i == 4)
                        {
                            int remainingBytes = (int)streamReader.Length - (int)streamReader.Position;
                            byte[] lastBuffer = new byte[remainingBytes];
                            streamReader.Read(lastBuffer, 0, remainingBytes);
                            streamWriter.Write(lastBuffer, 0, lastBuffer.Length);
                        }
                    }
                }
            }
        }
    }
}
