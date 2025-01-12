using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace VisualImageRename
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<int, ImageMetadata> _images = new Dictionary<int, ImageMetadata>();
        private readonly ResourceManager _resourceManager = new ResourceManager("VisualImageRename.Form1", Assembly.GetExecutingAssembly());
        
        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
        }

        private Image LoadImage(string filename)
        {
            Image img;
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                img = Image.FromStream(fs);
            }

            return img;
        }

        private void loadFromDirectoryB_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog fbd = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
            };

            if (fbd.ShowDialog() != CommonFileDialogResult.Ok) return;
            
            _images.Clear();
            imageSelectFLP.Controls.Clear();
            fileNameTB.Text = "";
            
            Directory.SetCurrentDirectory(fbd.FileName);
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            DirectoryInfo imageDir = new DirectoryInfo(fbd.FileName);
            
            DialogResult result = MessageBox.Show(_resourceManager.GetString("SortMethodText"), 
                _resourceManager.GetString("SortMethodTitle"), MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            
            List<FileInfo> imageFiles = imageDir
                .GetFiles("*")
                .Where(f => allowedExtensions.Contains(Path.GetExtension(f.Name)))
                .OrderBy(file =>
                    Regex.Replace(file.Name, @"\d+", match => match.Value.PadLeft(4, '0')))
                .ToList();
            
            if (result == DialogResult.Yes) imageFiles = imageFiles.OrderBy(f => f.LastWriteTime).ToList();
            
            if (imageFiles.Count <= 0)
            {
                MessageBox.Show(_resourceManager.GetString("NoImagesFound"));
                return;
            }
            int index = 0;
            foreach (FileInfo file in imageFiles)
            {
                // Load image into dictionary
                ImageMetadata imageData = new ImageMetadata();
                imageData.ImageName = Path.GetFileNameWithoutExtension(file.Name);
                imageData.ImagePath = file.FullName;
                imageData.ImageData = LoadImage(file.FullName);
                _images.Add(index, imageData);
                index++;
                
                // Load image into select control
                RadioButton imageRb = new RadioButton();
                imageRb.Appearance = Appearance.Button;
                imageRb.Size = new Size(128, 128);
                imageRb.BackgroundImageLayout = ImageLayout.Zoom;
                imageRb.BackgroundImage = imageData.ImageData;
                imageRb.TabIndex = index;
                
                // Append mouse clicks to radio buttons
                imageRb.MouseClick += imageButton_Click;
                imageRb.Click += imageButton_Click;
                MethodInfo m = typeof(RadioButton).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
                if (m != null)
                {
                    m.Invoke(imageRb, new object[] { ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true });
                }
                imageRb.MouseDoubleClick += imageButton_DoubleClick;
                
                imageSelectFLP.Controls.Add(imageRb);
                
            }
            
            // Change colors to normal
            mainPreviewPB.BackColor = Color.Gainsboro;
            imageSelectFLP.BackColor = SystemColors.Control;
            
            // Enable controls
            fileNameTB.Enabled = true;
            applyToAllB.Enabled = true;
            renameStartB.Enabled = true;

        }

        private void imageButton_DoubleClick(object sender, MouseEventArgs e)
        {
            if(!(sender is RadioButton)) return;
            int index = imageSelectFLP.Controls.IndexOf((RadioButton)sender);
            ImageMetadata imageData = _images[index];
            Process.Start(imageData.ImagePath);
        }

        private void ShiftButtonBoundsCheck(int index)
        {
            if (index == 0)
            {
                shiftLeftB.Enabled = false;
                shiftRightB.Enabled = true;
            }
            else if (index + 1 == _images.Count)
            {
                shiftLeftB.Enabled = true;
                shiftRightB.Enabled = false;
            }
            else
            {
                shiftLeftB.Enabled = true;
                shiftRightB.Enabled = true;
            }
        }
        
        private void imageButton_Click(object sender, EventArgs e)
        {
            if(!(sender is RadioButton)) return;
            int index = imageSelectFLP.Controls.IndexOf(sender as RadioButton);
            ImageMetadata imageData = _images[index];
            mainPreviewPB.Image = imageData.ImageData;
            fileNameTB.Text = imageData.ImageName;
            ShiftButtonBoundsCheck(index);
        }

        private RadioButton GetCurrentSelectedRadioButton()
        {
            return imageSelectFLP.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked);
        }
        
        private void fileNameTB_TextChanged(object sender, EventArgs e)
        {
            int imageIndex = imageSelectFLP.Controls.IndexOf(GetCurrentSelectedRadioButton());
            ImageMetadata imageData = _images[imageIndex];
            imageData.ImageName = fileNameTB.Text;
            if(!imageData.ImageName.Contains("#")) imageData.ImageName += "#";
        }

        private void applyToAllB_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, ImageMetadata> image in _images)
            {
                image.Value.ImageName = fileNameTB.Text;
            }
        }

        private void shiftLeftB_Click(object sender, EventArgs e)
        {
            RadioButton selected = GetCurrentSelectedRadioButton();
            int imageIndex = imageSelectFLP.Controls.IndexOf(selected);
            if (imageIndex <= 0) return;
            
            // In-memory image shift
            (_images[imageIndex - 1], _images[imageIndex]) = (_images[imageIndex], _images[imageIndex - 1]);
            
            // Visual image shift
            imageSelectFLP.Controls.SetChildIndex(selected, imageIndex-1);
            imageSelectFLP.ScrollControlIntoView(selected);
            
            // Change tab order
            selected.TabIndex = imageIndex-1;
            imageSelectFLP.Controls[imageIndex].TabIndex = imageIndex;
            
            ShiftButtonBoundsCheck(imageIndex-1);
        }

        private void shiftRightB_Click(object sender, EventArgs e)
        {
            RadioButton selected = GetCurrentSelectedRadioButton();
            int imageIndex = imageSelectFLP.Controls.IndexOf(selected);
            if(imageIndex+1 == _images.Count) return;
            
            // In-memory image shift
            (_images[imageIndex + 1], _images[imageIndex]) = (_images[imageIndex], _images[imageIndex + 1]);
            
            // Visual image shift
            imageSelectFLP.Controls.SetChildIndex(selected, imageIndex+1);
            imageSelectFLP.ScrollControlIntoView(selected);
            
            // Change tab order
            selected.TabIndex = imageIndex+1;
            imageSelectFLP.Controls[imageIndex].TabIndex = imageIndex;
            
            ShiftButtonBoundsCheck(imageIndex+1);
        }

        private void renameStartB_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(_resourceManager.GetString("StartRenameText"),
                _resourceManager.GetString("StartRenameTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            
            foreach (KeyValuePair<int, ImageMetadata> image in _images)
            {
                if(String.IsNullOrEmpty(image.Value.ImagePath)) continue;
                if(!File.Exists(image.Value.ImagePath)) continue;
                    
                string fileName = image.Value.ImageName.Replace("#",(image.Key + 1).ToString());
                string extension = Path.GetExtension(image.Value.ImagePath);
                extension = extension.Replace("_temp", "");
                string newFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"{fileName}{extension}");
                    
                // If file already exists set temporary name
                if (File.Exists(newFilePath))
                {
                    string tempName = newFilePath + "_temp";
                    File.Move(newFilePath, tempName);
                    ImageMetadata tempImage = _images.FirstOrDefault(n => n.Value.ImagePath == newFilePath).Value;
                    tempImage.ImagePath = tempName;
                }
                    
                // Rename
                File.Move(image.Value.ImagePath, newFilePath);
                image.Value.ImageName = fileName;
                image.Value.ImagePath = newFilePath;
            }
            MessageBox.Show(_resourceManager.GetString("RenameSuccessful"));
        }

        private void mainPreviewPB_DoubleClick(object sender, EventArgs e)
        {
            RadioButton selected = GetCurrentSelectedRadioButton();
            int imageIndex = imageSelectFLP.Controls.IndexOf(selected);
            ImageMetadata imageData = _images[imageIndex];
            Process.Start(imageData.ImagePath);
        }
    }
}