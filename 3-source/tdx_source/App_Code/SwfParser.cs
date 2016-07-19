using System;
using System.Text;
using System.IO;
using System.Drawing;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

public class SwfParser
{
    public Rectangle GetDimensions(String filePath)
    {
        using (FileStream stream = File.OpenRead(filePath))
        {
            return GetDimensions(stream);
        }
    }

    public Rectangle GetDimensions(Stream stream)
    {
        Stream inputStream = null;
        byte[] signature = new byte[8];
        byte[] rect = new byte[8];
        stream.Read(signature, 0, 8);
        if ("CWS" == System.Text.Encoding.ASCII.GetString(signature, 0, 3))
        {
            inputStream = new InflaterInputStream(stream);
        }
        else
        {
            inputStream = stream;
        }

        inputStream.Read(rect, 0, 8);
        int nbits = rect[0] >> 3;
        rect[0] = (byte)(rect[0] & 0x07);
        String bits = ByteArrayToBitString(rect);
        bits = bits.Remove(0, 5);
        int[] dims = new int[4];
        for (int i = 0; i < 4; i++)
        {
            char[] dest = new char[nbits];
            bits.CopyTo(0, dest, 0, bits.Length > nbits ? nbits : bits.Length);
            bits = bits.Remove(0, bits.Length > nbits ? nbits : bits.Length);
            dims[i] = BitStringToInteger(new String(dest)) / 20;
        }

        return new Rectangle(0, 0, dims[1] - dims[0], dims[3] - dims[2]);
    }

    private int BitStringToInteger(String bits)
    {
        int converted = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            converted = (converted << 1) + (bits[i] == '1' ? 1 : 0);
        }
        return converted;
    }

    private String ByteArrayToBitString(byte[] byteArray)
    {
        byte[] newByteArray = new byte[byteArray.Length];
        Array.Copy(byteArray, newByteArray, byteArray.Length);
        String converted = "";
        for (int i = 0; i < newByteArray.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                converted += (newByteArray[i] & 0x80) > 0 ? "1" : "0";
                newByteArray[i] <<= 1;
            }
        }
        return converted;
    }
}