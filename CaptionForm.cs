using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace PhotoCaptionApp
{
    public partial class CaptionForm : Form
    {
        public string CaptionText { get; private set; }
        public Font SelectedFont { get; private set; }
        public Color SelectedColor { get; private set; }
        public Point CaptionLocation { get; private set; }

        public CaptionForm(Font initialFont, Color initialColor)
        {
            InitializeComponent();

            SelectedFont = initialFont;
            SelectedColor = initialColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CaptionText = txtCaption.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = SelectedFont;

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFont = fontDialog.Font;
                }
            }
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = SelectedColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedColor = colorDialog.Color;
                }
            }
        }

        private void CaptionForm_MouseClick(object sender, MouseEventArgs e)
        {
            CaptionLocation = e.Location;
        }
    }
}
