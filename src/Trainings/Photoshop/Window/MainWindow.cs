using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace MyPhotoshop
{
    public class MainWindow : Form
    {
        private Bitmap _originalBmp;
        private Photo _originalPhoto;
        private readonly PictureBox _original;
        private readonly PictureBox _processed;
        private readonly ComboBox _filtersSelect;
        private Panel _parametersPanel;
        private List<NumericUpDown> _parametersControls;
        private readonly Button _apply;

        public MainWindow()
        {
            _original = new PictureBox();
            Controls.Add(_original);

            _processed = new PictureBox();
            Controls.Add(_processed);

            _filtersSelect = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _filtersSelect.SelectedIndexChanged += FilterChanged;
            Controls.Add(_filtersSelect);

            _apply = new Button
            {
                Text = "Применить",
                Enabled = false
            };
            _apply.Click += Process;
            Controls.Add(_apply);

            Text = "Photoshop pre-alpha release";
            FormBorderStyle = FormBorderStyle.FixedDialog;

            LoadBitmap((Bitmap) Image.FromFile("cat.jpg"));
        }

        public void LoadBitmap(Bitmap bmp)
        {
            _originalBmp = bmp;
            _originalPhoto = Convertors.Bitmap2Photo(bmp);

            _original.Image = _originalBmp;
            _original.Left = 0;
            _original.Top = 0;
            _original.ClientSize = _originalBmp.Size;

            _processed.Left = 0;
            _processed.Top = _original.Bottom;
            _processed.Size = _original.Size;

            _filtersSelect.Left = _original.Right + 10;
            _filtersSelect.Top = 20;
            _filtersSelect.Width = 200;
            _filtersSelect.Height = 20;


            ClientSize = new Size(_filtersSelect.Right + 20, _processed.Bottom);

            _apply.Left = ClientSize.Width - 120;
            _apply.Top = ClientSize.Height - 50;
            _apply.Width = 100;
            _apply.Height = 40;

            FilterChanged(null, EventArgs.Empty);
        }


        public void AddFilter(IFilter filter)
        {
            _filtersSelect.Items.Add(filter);
            if (_filtersSelect.SelectedIndex == -1)
            {
                _filtersSelect.SelectedIndex = 0;
                _apply.Enabled = true;
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            var filter = (IFilter) _filtersSelect.SelectedItem;
            if (filter == null) return;
            if (_parametersPanel != null) Controls.Remove(_parametersPanel);
            _parametersControls = new List<NumericUpDown>();
            _parametersPanel = new Panel
            {
                Left = _filtersSelect.Left,
                Top = _filtersSelect.Bottom + 10,
                Width = _filtersSelect.Width
            };
            _parametersPanel.Height = ClientSize.Height - _parametersPanel.Top;

            int y = 0;

            foreach (var param in filter.GetParameters())
            {
                var label = new Label
                {
                    Left = 0,
                    Top = y,
                    Width = _parametersPanel.Width - 50,
                    Height = 20,
                    Text = param.Name
                };
                _parametersPanel.Controls.Add(label);

                var box = new NumericUpDown
                {
                    Left = label.Right,
                    Top = y,
                    Width = 50,
                    Height = 20,
                    Value = (decimal) param.DefaultValue,
                    Increment = (decimal) param.Increment/3,
                    Maximum = (decimal) param.MaxValue,
                    Minimum = (decimal) param.MinValue,
                    DecimalPlaces = 2
                };
                _parametersPanel.Controls.Add(box);
                y += label.Height + 5;
                _parametersControls.Add(box);
            }
            Controls.Add(_parametersPanel);
        }


        private void Process(object sender, EventArgs empty)
        {
            var data = _parametersControls.Select(z => (double) z.Value).ToArray();
            var filter = (IFilter) _filtersSelect.SelectedItem;
            Photo result = null;
            result = filter.Process(_originalPhoto, data);
            var resultBmp = Convertors.Photo2Bitmap(result);
            if (resultBmp.Width > _originalBmp.Width || resultBmp.Height > _originalBmp.Height)
            {
                float k = Math.Min((float) _originalBmp.Width/resultBmp.Width,
                                   (float) _originalBmp.Height/resultBmp.Height);

                var newBmp = new Bitmap((int) (resultBmp.Width*k), (int) (resultBmp.Height*k));

                using (var g = Graphics.FromImage(newBmp))
                {
                    g.DrawImage(resultBmp, new Rectangle(0, 0, newBmp.Width, newBmp.Height),
                        new Rectangle(0, 0, resultBmp.Width, resultBmp.Height), GraphicsUnit.Pixel);
                }
                resultBmp = newBmp;
            }

            _processed.Image = resultBmp;
        }
    }
}