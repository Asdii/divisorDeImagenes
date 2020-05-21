using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DivisorDeImagenes
{
    class Program
    {
        static void Main(string[] args)
        {
            String nombreArchivo = args[0];
            string[] coleccion = nombreArchivo.Split('.');
            string[] coleccionAbsoluta = coleccion[0].Split('\\');
            Image img = Image.FromFile(nombreArchivo);
            int widthThird = (int)((double)img.Width / Convert.ToInt32(coleccionAbsoluta[coleccionAbsoluta.Length - 1]));
            int heightThird = (int)((double)img.Height);
            Bitmap[] bmps = new Bitmap[Convert.ToInt32(coleccionAbsoluta[coleccionAbsoluta.Length - 1])];

            for (int i = 0; i < Convert.ToInt32(coleccionAbsoluta[coleccionAbsoluta.Length - 1]); i++) {
                    bmps[i] = new Bitmap(widthThird, heightThird);
                    Graphics g = Graphics.FromImage(bmps[i]);
                    g.DrawImage(img, new Rectangle(0, 0, widthThird, heightThird), new Rectangle( i * widthThird, 0, widthThird, heightThird), GraphicsUnit.Pixel);
                    g.Dispose();

                    bmps[i].Save("Frame " + Convert.ToString(i + 1) + ".png");
            }
        }
    }
}