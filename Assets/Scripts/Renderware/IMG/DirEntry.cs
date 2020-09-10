using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    struct DirEntry
    {
        public uint Offset;
        public uint Size;
        public string Name;

        public DirEntry(uint offset, uint size, string name)
        {
            this.Offset = offset;
            this.Size = size;
            this.Name = name;
        }
    }
}
