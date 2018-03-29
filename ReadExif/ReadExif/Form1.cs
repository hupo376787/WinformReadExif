using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExifLib;

namespace ReadExif
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if(opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = opf.FileName;
                using (ExifReader reader = new ExifReader(opf.FileName))
                {
                    string result;
                    reader.GetTagValue(ExifTags.Make, out result);
                    textBox1.Text += "Make:" + result + "\r\n";

                    reader.GetTagValue(ExifTags.Model, out result);
                    textBox1.Text += "Model:" + result + "\r\n";

                    reader.GetTagValue(ExifTags.LensMake, out result);
                    textBox1.Text += "LensMake:" + result + "\r\n";

                    reader.GetTagValue(ExifTags.LensModel, out result);
                    textBox1.Text += "LensModel:" + result + "\r\n";
                }
            }
        }

        //private static string RenderTag(object tagValue)
        //{
        //    // Arrays don't render well without assistance.
        //    var array = tagValue as Array;
        //    if (array != null)
        //    {
        //        // Hex rendering for really big byte arrays (ugly otherwise)
        //        if (array.Length > 20 && array.GetType().GetElementType() == typeof(byte))
        //            return "0x" + string.Join("", array.Cast<byte>().Select(x => x.ToString("X2")).ToArray());

        //        return string.Join(", ", array.Cast<object>().Select(x => x.ToString()).ToArray());
        //    }

        //    return tagValue.ToString();
        //}
    }
}
