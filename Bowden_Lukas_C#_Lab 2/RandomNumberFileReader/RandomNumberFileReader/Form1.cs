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

namespace RandomNumberFileReader
{
    public partial class RandomNumberFileReader : Form
    {
        public RandomNumberFileReader()
        {
            InitializeComponent();
        }

        //On button press it loads and process a file
        private void loadFile_btn_Click(object sender, EventArgs e)
        {
            //Opens the file dialogue to load an input file and creates a Stream Reader object
            openFileDialog1.ShowDialog();
            StreamReader inputFile;
            //Variables to store, convert, and add whats stored inside the input file
            string tempWord;
            int tempNum;
            int sum = 0;

            //Clears all current fields so you don't load more then one file at a time
            clearNums();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFileDialog1.FileName);
                //While loop that scans through the entire file and stores each line in a temp variable
                while ((tempWord = inputFile.ReadLine()) != null) 
                {
                    //Converts whats currently stored in the tempWord variable into an int.
                    if (int.TryParse(tempWord, out tempNum))
                    {
                        //Adds the newly converted int thats been stored in tempNum to the list.
                        listBox1.Items.Add(tempNum);
                        //Adds to the variable that holds the total sum of the whole list.
                        sum += tempNum;
                    }

                    //If somewhere in the file there is something that isn't a proper int. It will generate an error, close the file, and clear all fields.
                    else
                    {
                        MessageBox.Show("This file contains an invalid number.");
                        inputFile.Close();
                        clearNums();
                    }
                }

                //Displays all results to proper fields then closes the input file.
                count_lb.Text = listBox1.Items.Count.ToString();
                sum_lb.Text = sum.ToString();
                inputFile.Close();
            }
        }

        //Clears whats stored in the current fields on button press.
        private void clear_btn_Click(object sender, EventArgs e)
        {
            clearNums();
        }

        //Closes the application on button press.
        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Function that resets the Count and Sum labels to 0 then clears everything thats stored in the List Box.
        public void clearNums()
        {
            count_lb.Text = "0";
            sum_lb.Text = "0";
            listBox1.Items.Clear();
        }
    }
}
