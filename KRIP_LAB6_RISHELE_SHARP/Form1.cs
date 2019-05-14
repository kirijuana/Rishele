using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRIP_LAB6_RISHELE_SHARP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button_Shifr_Click(object sender, EventArgs e)
        {
            char[] text = Text.Text.ToCharArray();
            char[] shifr = Text.Text.ToCharArray();
            char[] key_text = keyBox.Text.ToCharArray();

            int length_key = 0;
            for (int i = 0; i < key_text.Length; i++)
            {
                if (key_text[i] != '(' && key_text[i] != ')' && key_text[i] !=  ' ')
                {
                    length_key++;
                }
            }

            string key_temp = "\0\0"; //если число двузначное
            int c = 0; char temp_key = ' ';

            int z = 0, plus = 0;
            for (int i = 0; i < key_text.Length;)
            {
                if (z < text.Length) // пока текст короче ключа
                {
                    if (key_text[i] == '(' || key_text[i] == ')' || key_text[i] == ' ')
                    {                        
                        if (key_text[i] == ')' || key_text[i] == '(')
                        {
                            plus = z;
                        }
                        i++;
                    }
                    else
                    {
                        c = 0;
                        while (key_text[i] != ' ' && key_text[i] != '(' && key_text[i] != ')')
                        {
                            
                            temp_key = key_text[i];
                            key_temp = key_temp.Remove(c, 1).Insert(c, temp_key.ToString());                      
                            c++;
                            i++;
                            if (key_text[i - 1] == '0' && key_text[i] == '1')
                                break;
                            
                            if (z + 1 >= length_key)
                            {
                                break;
                            }
                        }

                        shifr[z] = text[Convert.ToInt32(key_temp) + plus];
                        z++;
                        key_temp = key_temp.Remove(1, 1).Insert(1, "\0");
                    }
                }
                else
                {
                    break;
                }
            }
            

            string text1 = new string(shifr);
            ShifrText.Text = text1;
        }

        private void button_unShifr_Click(object sender, EventArgs e)
        {
            char[] text = Text.Text.ToCharArray();
            char[] shifr = Text.Text.ToCharArray();
            char[] key_text = keyBox.Text.ToCharArray();
            int mas_size = key_text.Length;

            int length_key = 0;
            for (int i = 0; i < key_text.Length; i++)
            {
                if (key_text[i] != '(' && key_text[i] != ')' && key_text[i] != ' ')
                {
                    length_key++;
                }
            }

            int z = 0, plus = 0;
            string key_temp = "\0\0"; int c = 0; char temp_key = ' ';
            for (int i = 0; i < key_text.Length && z < text.Length;)
            {
                if (z < text.Length) // если текст короче ключа
                {
                    if (key_text[i] == '(' || key_text[i] == ')' || key_text[i] == ' ')
                    {

                        if (key_text[i] == ')' || key_text[i] == '(')
                        {
                            plus = z;
                        }
                        i++;
                    }
                    else
                    {
                        c = 0;
                        while (key_text[i] != ' ' && key_text[i] != '(' && key_text[i] != ')')
                        {
                            temp_key = key_text[i];
                            key_temp = key_temp.Remove(c, 1).Insert(c, temp_key.ToString());
                            c++;
                            i++;
                            if (key_text[i - 1] == '0' && key_text[i] == '1')
                                break;                                                        
                            if (z + 1 >= length_key)
                            {
                                break;
                            }
                        }
                        text[Convert.ToInt32(key_temp) + plus] = shifr[z];
                        key_temp = key_temp.Remove(1, 1).Insert(1, "\0");
                        z++;
                    }
                }
                else
                {
                    break;
                }
            }
            string text1 = new string(text);
            ShifrText.Text = text1;
        }
    }
    }
