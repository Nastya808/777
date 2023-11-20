using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PhotoCaptionApp
{
    public partial class MainForm : Form
    {
        private Font selectedFont;
        private Color selectedColor;

        public MainForm()
        {
            InitializeComponent();

            selectedFont = new Font("Arial", 12);
            selectedColor = Color.Black;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Файлы изображений (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnAddCaption_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Пожалуйста, загрузите изображение.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (CaptionForm captionForm = new CaptionForm(selectedFont, selectedColor))
            {
                if (captionForm.ShowDialog() == DialogResult.OK)
                {
                    using (Graphics graphics = Graphics.FromImage(pictureBox.Image))
                    {
                        graphics.DrawString(captionForm.CaptionText, captionForm.SelectedFont, new SolidBrush(captionForm.SelectedColor), captionForm.CaptionLocation);
                    }

                    pictureBox.Invalidate(); 
                }
            }
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = selectedFont;

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFont = fontDialog.Font;
                }
            }
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = selectedColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = colorDialog.Color;
                }
            }
        }
    }
}
