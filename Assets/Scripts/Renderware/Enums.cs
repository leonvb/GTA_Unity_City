﻿public enum PLATFORM_ID
{
	PLATFORM_OGL = 2,
	PLATFORM_PS2 = 4,
	PLATFORM_XBOX = 5,
	PLATFORM_D3D8 = 8,
	PLATFORM_D3D9 = 9,
	PLATFORM_PS2FOURCC = 0x00325350 // "PS2\0"
}

public enum CHUNK_TYPE
{
	CHUNK_NAOBJECT = 0x0,
	CHUNK_STRUCT = 0x1,
	CHUNK_STRING = 0x2,
	CHUNK_EXTENSION = 0x3,
	CHUNK_CAMERA = 0x5,
	CHUNK_TEXTURE = 0x6,
	CHUNK_MATERIAL = 0x7,
	CHUNK_MATLIST = 0x8,
	CHUNK_ATOMICSECT = 0x9,
	CHUNK_PLANESECT = 0xA,
	CHUNK_WORLD = 0xB,
	CHUNK_SPLINE = 0xC,
	CHUNK_MATRIX = 0xD,
	CHUNK_FRAMELIST = 0xE,
	CHUNK_GEOMETRY = 0xF,
	CHUNK_CLUMP = 0x10,
	CHUNK_LIGHT = 0x12,
	CHUNK_UNICODESTRING = 0x13,
	CHUNK_ATOMIC = 0x14,
	CHUNK_TEXTURENATIVE = 0x15,
	CHUNK_TEXDICTIONARY = 0x16,
	CHUNK_ANIMDATABASE = 0x17,
	CHUNK_IMAGE = 0x18,
	CHUNK_SKINANIMATION = 0x19,
	CHUNK_GEOMETRYLIST = 0x1A,
	CHUNK_ANIMANIMATION = 0x1B,
	CHUNK_HANIMANIMATION = 0x1B,
	CHUNK_TEAM = 0x1C,
	CHUNK_CROWD = 0x1D,
	CHUNK_RIGHTTORENDER = 0x1F,
	CHUNK_MTEFFECTNATIVE = 0x20,
	CHUNK_MTEFFECTDICT = 0x21,
	CHUNK_TEAMDICTIONARY = 0x22,
	CHUNK_PITEXDICTIONARY = 0x23,
	CHUNK_TOC = 0x24,
	CHUNK_PRTSTDGLOBALDATA = 0x25,
	CHUNK_ALTPIPE = 0x26,
	CHUNK_PIPEDS = 0x27,
	CHUNK_PATCHMESH = 0x28,
	CHUNK_CHUNKGROUPSTART = 0x29,
	CHUNK_CHUNKGROUPEND = 0x2A,
	CHUNK_UVANIMDICT = 0x2B,
	CHUNK_COLLTREE = 0x2C,
	CHUNK_ENVIRONMENT = 0x2D,
	CHUNK_COREPLUGINIDMAX = 0x2E,

	CHUNK_MORPH = 0x105,
	CHUNK_SKYMIPMAP = 0x110,
	CHUNK_SKIN = 0x116,
	CHUNK_PARTICLES = 0x118,
	CHUNK_HANIM = 0x11E,
	CHUNK_MATERIALEFFECTS = 0x120,
	CHUNK_PDSPLG = 0x131,
	CHUNK_ADCPLG = 0x134,
	CHUNK_UVANIMPLG = 0x135,
	CHUNK_BINMESH = 0x50E,
	CHUNK_NATIVEDATA = 0x510,
	CHUNK_VERTEXFORMAT = 0x510,

	CHUNK_PIPELINESET = 0x253F2F3,
	CHUNK_SPECULARMAT = 0x253F2F6,
	CHUNK_2DFX = 0x253F2F8,
	CHUNK_NIGHTVERTEXCOLOR = 0x253F2F9,
	CHUNK_COLLISIONMODEL = 0x253F2FA,
	CHUNK_REFLECTIONMAT = 0x253F2FC,
	CHUNK_BREAKABLE = 0x253F2FD,
	CHUNK_FRAME = 0x253F2FE
}

public enum RASTER
{
	RASTER_DEFAULT = 0x0000,
	RASTER_1555 = 0x0100,
	RASTER_565 = 0x0200,
	RASTER_4444 = 0x0300,
	RASTER_LUM8 = 0x0400,
	RASTER_8888 = 0x0500,
	RASTER_888 = 0x0600,
	RASTER_16 = 0x0700,
	RASTER_24 = 0x0800,
	RASTER_32 = 0x0900,
	RASTER_555 = 0x0a00,

	RASTER_AUTOMIPMAP = 0x1000,
	RASTER_PAL8 = 0x2000,
	RASTER_PAL4 = 0x4000,
	RASTER_MIPMAP = 0x8000,

	RASTER_MASK = 0x0F00
}

// GEOMETRY_FLAGS ENUM
public enum GEOMETRY_FLAGS : int
{
	FLAGS_TRISTRIP              = 0x01,
	FLAGS_POSITIONS             = 0x02,
	FLAGS_TEXTURED              = 0x04,
	FLAGS_PRELIT                = 0x08,
	FLAGS_NORMALS               = 0x10,
	FLAGS_LIGHT                 = 0x20,
	FLAGS_MODULATEMATERIALCOLOR = 0x40,
	FLAGS_TEXTURED2             = 0x80
}


enum MATFX_TYPE {
	MATFX_BUMPMAP = 0x1,
	MATFX_ENVMAP = 0x2,
	MATFX_BUMPENVMAP = 0x3,
	MATFX_DUAL = 0x4,
	MATFX_UVTRANSFORM = 0x5,
	MATFX_DUALUVTRANSFORM = 0x6,
};

public enum FACETYPE{
	FACETYPE_STRIP = 0x1,
	FACETYPE_LIST = 0x0
};

/* gta3 ps2: 302, 304, 310 
 * gta3 pc: 304, 310, 401ffff, 800ffff, c02ffff
 * gtavc ps2: c02ffff
 * gtavc pc: c02ffff, 800ffff, 1003ffff
 * gtasa: 1803ffff */

public enum GTA_VERSION
{
    GTA3_1  = 0x00000302,
    GTA3_2  = 0x00000304,
    GTA3_3  = 0x00000310,
    GTA3_4  = 0x0800FFFF,
    VCPS2   = 0x0C02FFFF,
    VCPC    = 0x1003FFFF,
    SA      = 0x1803FFFF
}

public enum Filter : ushort
{
    None = 0x0,
    Nearest = 0x1,
    Linear = 0x2,
    MipNearest = 0x3,
    MipLinear = 0x4,
    LinearMipNearest = 0x5,
    LinearMipLinear = 0x6,
    Unknown = 0x1101
}

public enum WrapMode : byte
{
    None = 0,
    Wrap = 1,
    Mirror = 2,
    Clamp = 3
}

public enum CompressionMode : byte
{
    None = 0,
    DXT1 = 1,
    DXT3 = 3
}

public enum RasterFormat : uint
{
    Default = 0x0000,
    A1R5G5B5 = 0x0100,
    R5G6B5 = 0x0200,
    R4G4B4A4 = 0x0300,
    LUM8 = 0x0400,
    BGRA8 = 0x0500,
    BGR8 = 0x0600,
    R5G5B5 = 0x0a00,

    NoExt = 0x0fff,

    ExtAutoMipMap = 0x1000,
    ExtPal8 = 0x2000,
    ExtPal4 = 0x4000,
    ExtMipMap = 0x8000
}

enum TXD_PLATFORM
{
    III_VC = 8,
    SA = 9,
    XBOX = 5,
}