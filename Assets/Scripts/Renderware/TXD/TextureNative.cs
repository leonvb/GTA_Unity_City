using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
	class TextureNative
	{
		//*******************************
		//          PROPERTIES
		//*******************************
		public TXD_PLATFORM platformId;
		public ushort filterFlags;
		public int V;
		public int U;
		public string diffuseName;
		public string alphaName;
		public uint rasterFormat;

        public string d3dFormat;

		public bool hasAlpha;
		public int compression;
		public ushort width;
		public ushort height;
		public byte depth;
		public byte mipMapCount;
		public byte rasterType;
		public uint imageDataSize;

		public byte[] imageData;
		public byte[] imageLevelData;

		//*******************************
		//          CONSTRUCTOR
		//*******************************
		public TextureNative(ref BufferReader reader)
		{
			//*******************************
			//         INITIALIZE
			//*******************************
			Header header = new Header();
			header.Read(ref reader); // TEXTURE NATIVE HEADER
			header.Read(ref reader); // STRUCT HEADER

			//*******************************
			//       TEXTURE NATIVE
			//*******************************
            platformId = (TXD_PLATFORM)reader.ReadUInt32();
			filterFlags = reader.ReadUInt16();
			V = reader.ReadByte();
			U = reader.ReadByte();
			diffuseName = reader.ReadNullTerminatedString(32);
			alphaName = reader.ReadNullTerminatedString(32);

			rasterFormat = reader.ReadUInt32();

			hasAlpha = false;

			if (platformId == TXD_PLATFORM.SA) // If PLATFORM_D3D9
			{
				d3dFormat = reader.ReadString(4); // Recheck this part
			}
			else
			{
				hasAlpha = reader.ReadUInt32() == 1;
			}

			width = reader.ReadUInt16();
			height = reader.ReadUInt16();
			depth = reader.ReadByte();
			mipMapCount = reader.ReadByte();
			rasterType = reader.ReadByte(); // Always 4

            if (platformId == TXD_PLATFORM.SA) // If is San Andreas
            {
                hasAlpha = (reader.ReadByte() & 0x1) == 0x1;
            }
            else
            {
                compression = reader.ReadByte();
            }

            // Create palette
            //if ((rasterFormat & (int)RASTER.RASTER_PAL8) == 0 || (rasterFormat & (int)RASTER.RASTER_PAL4) == 0)
            //{
            //    Console.WriteLine("Creating palettes");

            //    var paletteSize = (rasterFormat & (int)RASTER.RASTER_PAL8) == 0 ? 0x001 : 0x10;
            //    byte[] palette = new byte[paletteSize * 4 * sizeof(byte)];

            //    for (int i = 0; i < palette.Count(); i++)
            //    {
            //        palette[i] = reader.ReadByte();
            //    }
            //}

            // Read a single raster(image) NOT for all mipmaps

			imageDataSize = reader.ReadUInt32();

			if (imageDataSize == 0)
				width = height = 0;

			imageData = reader.ReadBytes((int)imageDataSize);
		}
	}
}
