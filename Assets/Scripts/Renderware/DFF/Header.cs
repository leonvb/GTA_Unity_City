using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct Header
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        public uint type;
        public uint size; // Including child chunks/or data
        public int build;
        public int version; // Library ID Stamp, Version and build number of RW library

        //*******************************
        //            METHODS
        //*******************************
        public Header Read(ref BufferReader reader)
        {
            type = reader.ReadUInt32();
            size = reader.ReadUInt32();
            build = reader.ReadInt32();

            if ((build & 0xFFFF0000) != 0)
            {
                version = (build >> 14 & 0x3FF00) + 0x30000 |
                    (build >> 16 & 0x3F);
            }
            else
            {
                version = build << 8;
            }

            Console.WriteLine(String.Format("{0} Size: {1} Offset: {2} Hex-Type: {3}",(CHUNK_TYPE)type, size, reader.Position, type));

            return this;

        } // Read() end
    }
}
