using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void genBtn_Click(object sender, EventArgs e)
        {
            StreamWriter outputFile;
            saveFile.ShowDialog();
            int input;

            if (int.TryParse(userInput.Text, out input))
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    outputFile = File.CreateText(saveFile.FileName);
                    int index = 0;
                    Random rand = new Random();

                    while (index != input)
                    {
                        outputFile.WriteLine(rand.Next(1, 100));
                        index++;
                    }

                    outputFile.Close();
                }
            }  

        }
    }
}
