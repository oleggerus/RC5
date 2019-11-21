using lab3_rc5.Algorythms.RC5;
using System;
using System.Windows.Forms;

namespace lab3_rc5
{
    public partial class MainForm : Form
    {

        private byte roundsNumber = 12;

        public MainForm()
        {
            InitializeComponent();
        }



        //encrypting file
        private void button1_Click(object sender, EventArgs e)
        {
            string plainFilePath = textBox1.Text;
            string cryptedFilePath = textBox2.Text;

            string password = textBox3.Text;

            try
            {
                if (plainFilePath.Equals(""))
                {
                    ErrorMessage("Choose source file.");
                }

                else if (cryptedFilePath.Equals(""))
                {
                    ErrorMessage("Choose destination file.");
                }

                else if (password.Equals(""))
                {
                    ErrorMessage("Enter phrase");
                }

                else
                {
                    try
                    {
                        var encryptor = new RC5Algorithm(password, 16, 12);
                        encryptor.Encrypt(plainFilePath, cryptedFilePath);
                        InfoMessage("Success.");
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }

        //decrypting file
        private void button2_Click(object sender, EventArgs e)
        {
            string cryptedFilePath = textBox1.Text;
            string plainFilePath = textBox2.Text;

            string password = textBox3.Text;

            try
            {
                if (plainFilePath.Equals(""))
                {
                    ErrorMessage("Choose source file.");
                }

                if (cryptedFilePath.Equals(""))
                {
                    ErrorMessage("Choose destination file.");
                }

                if (password.Equals(""))
                {
                    ErrorMessage("Enter phrase");
                }


                try
                {
                    var encryptor = new RC5Algorithm(password, 16, 12);
                    encryptor.Decrypt(cryptedFilePath, plainFilePath);
                    InfoMessage("Success");
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }


            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }



        //uploading source file
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowHelp = true;

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                textBox1.Text = filename;
            }
        }

        //uploading destination file
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            openFileDialog1.ShowHelp = true;

            openFileDialog1.Filter = "crypt files (*.crypt)|*.crypt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                textBox2.Text = filename;
            }
        }

        private void ErrorMessage(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InfoMessage(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}