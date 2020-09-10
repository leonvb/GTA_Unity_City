using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct ArchiveFile
    {
        public DirEntry _DirEntry;
        public uint Offset;
        public uint Size;
        public byte[] ByteBuffer;

        public ArchiveFile(DirEntry entry, uint offset, uint size, byte[] buffer)
        {
            this._DirEntry = entry;
            this.Offset = offset;
            this.Size = size;
            this.ByteBuffer = buffer;
        }
    }
}
