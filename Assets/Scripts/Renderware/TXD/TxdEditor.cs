using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class TxdEditor
    {
        public TextureDictionary txd;

        private string filePath;

        private BufferReader reader;

        public TxdEditor(string filePath)
        {
            this.filePath = filePath;

            reader = new BufferReader(filePath);
            reader.Position = 0;

            txd = new TextureDictionary(ref reader);
        }
    }
}
