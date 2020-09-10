using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class DFF
    {
        public Clump Clump;

        private BufferReader reader;

        public DFF(string filePath)
        {
            reader = new BufferReader(filePath);
            reader.Position = 0;

            Clump = new Clump(ref reader);
        }

        public DFF(byte[] file)
        {
            reader = new BufferReader(file);
            reader.Position = 0;

            Clump = new Clump(ref reader);
        }
    }
}
