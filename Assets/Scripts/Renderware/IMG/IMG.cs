using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GTAImgEditor
{
    class IMG
    {
        private string FilePath;

        public int EntriesCount;
        public List<DirEntry> EntriesList;

        public IMG()
        {
            BufferReader reader = null;
            EntriesList = new List<DirEntry>();

            this.FilePath = Path.Combine(GTASettings.gta_path, GTASettings.GTA3IMG);

            switch (GTASettings.version)
            {
                case GTA_VERSION.GTA3_1:
                case GTA_VERSION.GTA3_2:
                case GTA_VERSION.GTA3_3:
                case GTA_VERSION.GTA3_4:
                case GTA_VERSION.VCPC:

                    string dirPath = Path.ChangeExtension(FilePath, ".dir");
                    reader = new BufferReader(dirPath);
                    EntriesCount = (int)reader.FileSize / 32;

                    break;
                case GTA_VERSION.SA:

                    reader = new BufferReader(FilePath);
                    if (reader.ReadString(4) == "VER2")
                        EntriesCount = reader.ReadInt32();

                    break;
                default:
                    throw new Exception("Invalid GTA version");
            }

            for (int i = 0; i < EntriesCount; i++)
            {
                uint offset = reader.ReadUInt32() * 2048;
                uint size = reader.ReadUInt32() * 2048;
                string name = reader.ReadNullTerminatedString(24);

                EntriesList.Add(new DirEntry(offset, size, name));
            }

            reader.Dispose();
        }

        public ArchiveFile GetFileByName(string name)
        {
            for (int i = 0; i < EntriesCount; i++)
            {
                if (EntriesList[i].Name == name)
                {
                    return CreateArchiveFile(i);
                }
            }

            return new ArchiveFile();
        }

        public ArchiveFile GetFileByID(int id)
        {
            if (id < 0 || id > EntriesCount)
                throw new Exception("Invalid file ID");

            return CreateArchiveFile(id);
        }

        private ArchiveFile CreateArchiveFile(int id)
        {
            ArchiveFile archiveFile = new ArchiveFile();

            archiveFile._DirEntry = EntriesList[id];
            archiveFile.Offset = EntriesList[id].Offset;
            archiveFile.Size = EntriesList[id].Size;
            archiveFile.ByteBuffer = new byte[EntriesList[id].Size];

            BufferReader reader = new BufferReader(FilePath);
            reader.Seek(archiveFile.Offset);
            archiveFile.ByteBuffer = reader.ReadBytes((int)archiveFile.Size);

            return archiveFile;
        }
    }
}
