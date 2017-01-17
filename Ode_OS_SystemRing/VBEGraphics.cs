using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_OS.SystemRing
{
    public class VBE
    {
        public static VBEScreen vbs = new VBEScreen();

        public static int width = 1024;
        public static int height = 768;

        public static byte[] vA = new byte[width * height];
        public static byte[] vR = new byte[width * height];
        public static byte[] vG = new byte[width * height];
        public static byte[] vB = new byte[width * height];

        public static void Init()
        {
            vbs.SetMode(VBEScreen.ScreenSize.Size1024x768, VBEScreen.Bpp.Bpp32);

            vbs.Clear(0xFF9FFCA0);
            for (int i = 0; i < (1024 * 768); i++)
            {
                vA[i] = 0xff;
                vR[i] = 0x9f;
                vG[i] = 0xfc;
                vB[i] = 0xa0;
            }

        }


        public static void SetPixel(uint x, uint y, int a, int r, int g, int b)
        {
            uint RGB = (uint)MakeArgb((byte)a, (byte)r, (byte)g, (byte)b);

            //int offset = x * (depthVESA / 8) + y * (widthVESA * (depthVESA / 8));

            byte Alpha = (byte)((RGB >> 24) & 0xff);

            byte R = (byte)((RGB >> 16) & 0xff);
            byte G = (byte)((RGB >> 8) & 0xff);
            byte B = (byte)(RGB & 0xff);

            byte RR = (byte)(((R * Alpha + (byte)((vR[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);
            byte GR = (byte)(((G * Alpha + (byte)((vG[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);
            byte BR = (byte)(((B * Alpha + (byte)((vB[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);

            if (a != 0)
            {
                vPixel(x, y, 0xff, RR, GR, BR);
            }
        }

        public static void SetPixelNoBuffer(uint x, uint y, int a, int r, int g, int b)
        {
            uint RGB = (uint)MakeArgb((byte)a, (byte)r, (byte)g, (byte)b);

            //int offset = x * (depthVESA / 8) + y * (widthVESA * (depthVESA / 8));

            byte Alpha = (byte)((RGB >> 24) & 0xff);

            byte R = (byte)((RGB >> 16) & 0xff);
            byte G = (byte)((RGB >> 8) & 0xff);
            byte B = (byte)(RGB & 0xff);

            byte RR = (byte)(((R * Alpha + (byte)((vR[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);
            byte GR = (byte)(((G * Alpha + (byte)((vG[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);
            byte BR = (byte)(((B * Alpha + (byte)((vB[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);

            if (a != 0)
            {
                vbs.SetPixel(x, y, (uint)MakeArgb((byte)0xff, RR, GR, BR));
            }
        }

        public static void SetPixelNoBuffer(uint x, uint y, uint argb)
        {
            uint RGB = (uint)argb;

            //int offset = x * (depthVESA / 8) + y * (widthVESA * (depthVESA / 8));

            byte Alpha = (byte)((RGB >> 24) & 0xff);

            byte R = (byte)((RGB >> 16) & 0xff);
            byte G = (byte)((RGB >> 8) & 0xff);
            byte B = (byte)(RGB & 0xff);

            byte RR = (byte)(((R * Alpha + (byte)((vR[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);
            byte GR = (byte)(((G * Alpha + (byte)((vG[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);
            byte BR = (byte)(((B * Alpha + (byte)((vB[y * 1024 + x]) & 0xff) * (255 - Alpha))) >> 8);

            if (Alpha != 0)
            {
                vbs.SetPixel(x, y, (uint)MakeArgb((byte)0xff, RR, GR, BR));
            }
        }


        private static long MakeArgb(byte alpha, byte red, byte green, byte blue)
        {
            return ((alpha * 0x1000000) + (red * 0x10000) + (green * 0x100) + blue);
        }
        private static long MakeArgb(int alpha, int red, int green, int blue)
        {
            return ((alpha * 0x1000000) + (red * 0x10000) + (green * 0x100) + blue);
        }

        public static void vPixel(uint x, uint y, int a, int r, int g, int b, bool yes = true)
        {
            vbs.SetPixel(x, y, (uint)(MakeArgb(a, r, g, b)));
            vA[y * vbs.ScreenWidth + x] = (byte)a;
            vR[y * vbs.ScreenWidth + x] = (byte)r;
            vG[y * vbs.ScreenWidth + x] = (byte)g;
            vB[y * vbs.ScreenWidth + x] = (byte)b;
        }




        public static void ClearStripes(int a, int r, int g, int b)
        {
            for (int y = 0; y < height; y += 2)
            {
                for (int x = 0; x < width; x++)
                {
                    SetPixel((uint)x, (uint)y, a, r, g, b);
                }
            }
        }
    }

    public class Utils
    {
        public static void DrawFilledRect(int x, int y, int w, int h, int a, int r, int g, int b)
        {
            for (int yy = y; yy < (y + h); yy += 2)
            {
                for (int xx = x; xx < (x + w); xx++)
                {
                    VBE.SetPixel((uint)xx, (uint)yy, a, r, g, b);
                }
            }
            for (int yy = y + 1; yy < (y + h); yy += 2)
            {
                for (int xx = x; xx < (x + w); xx++)
                {
                    VBE.SetPixel((uint)xx, (uint)yy, a, r, g, b);
                }
            }
        }

        public static void DrawFilledRect_Progressive(int x, int y, int w, int h, int a, int r, int g, int b)
        {
            for (int yy = y; yy < (y + h); yy++)
            {
                for (int xx = x; xx < (x + w); xx++)
                {
                    VBE.SetPixel((uint)xx, (uint)yy, a, r, g, b);
                }
            }
        }

        public static void DrawArray(int _x, int _y, int w, int h, long[] array)
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int alpha = (int)((array[(y * w) + x] >> 24) & 0xff);
                    int red = (int)((array[(y * w) + x] >> 16) & 0xff);
                    int green = (int)((array[(y * w) + x] >> 8) & 0xff);
                    int blue = (int)(array[(y * w) + x] & 0xff);

                    if (alpha != 0)
                    {
                        VBE.SetPixel((uint)(_x + x), (uint)(_y + y), alpha, red, green, blue);
                    }

                }
            }
        }

    }
}
