using System;
using System.Text;
using System.IO;

namespace GTAImgEditor
{
    class BufferReader
    {
        StreamReader stream;
        BinaryReader reader;

        public long FileSize { get { return stream.BaseStream.Length; } }
        public long Position { get { return stream.BaseStream.Position; } set { stream.BaseStream.Position = value; } }
        public bool EOF { get { return reader.BaseStream.Position >= stream.BaseStream.Length; } }

        public BufferReader(string path)
        {
            stream = new StreamReader(path);
            
            reader = new BinaryReader(stream.BaseStream);
        }

        public BufferReader(byte[] file)
        {
            MemoryStream mStream = new MemoryStream(file);
            stream = new StreamReader(mStream);
            reader = new BinaryReader(mStream);
        }

        public void Dispose()
        {
            reader.Close();
            stream.Close();
        }

        public void Seek(long offset)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
        }

        public void Skip(int count)
        {
            reader.BaseStream.Seek(3, SeekOrigin.Current);
        }

        public byte ReadByte()
        {
            return reader.ReadByte();
        }

        public byte[] ReadBytes(int count)
        {
            return reader.ReadBytes(count);
        }

        public short ReadInt16()
        {
            return reader.ReadInt16();
        }

        public ushort ReadUInt16()
        {
            return reader.ReadUInt16();
        }

        public int ReadInt32()
        {
            return reader.ReadInt32();
        }

        public uint ReadUInt32()
        {
            return reader.ReadUInt32();
        }

        public float ReadSingle()
        {
            return reader.ReadSingle();
        }

        public string ReadString(int count)
        {
            return Encoding.ASCII.GetString(ReadBytes(count));
        }

        public string ReadNullTerminatedString(int count)
        {
            byte[] bytes = ReadBytes(count);

            int inx = Array.FindIndex(bytes, 0, (x) => x == 0);

            if(inx > 0)
                return Encoding.ASCII.GetString(bytes, 0, inx);

            return string.Empty;
        }
    }
}
