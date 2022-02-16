using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convert_img_jpg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Изображение|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap pic = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                pictureBox1.Image = pic;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap pic = new Bitmap(pictureBox1.Image);
                for (int y = 0; (y <= (pic.Height - 1)); y++)
                {
                    for (int x = 0; (x <= (pic.Width - 1)); x++)
                    {
                        Color inv = pic.GetPixel(x, y);
                        inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                        pic.SetPixel(x, y, inv);
                    }
                }
                pictureBox1.Image = pic;
            }
            else
                MessageBox.Show("Изображение не загружено","Warning",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null) 
            {
                saveFileDialog1.Title = "Сохранить картинку как...";
                saveFileDialog1.Filter = "Изображение|*.jpg";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
