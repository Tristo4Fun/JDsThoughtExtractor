using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrubs_Subtitles
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

            int episodemax = 0;
            string season = textBox4.Text;

            string exePath = Application.StartupPath;
            
                if (textBox4.Text.Length == 0 || int.Parse(textBox4.Text) < 0 || int.Parse(textBox4.Text) > 8)
                richTextBox1.Text = "False input: Season";
            else
            {
                if (int.Parse(season) == 1) episodemax = 24;
                if (int.Parse(season) == 2) episodemax = 22;
                if (int.Parse(season) == 3) episodemax = 22;
                if (int.Parse(season) == 4) episodemax = 25;
                if (int.Parse(season) == 5) episodemax = 24;
                if (int.Parse(season) == 6) episodemax = 21;
                if (int.Parse(season) == 7) episodemax = 11;
                if (int.Parse(season) == 8) episodemax = 18;
                   
                if (textBox5.Text.Length == 0 || int.Parse(textBox5.Text) > episodemax || int.Parse(textBox5.Text)<0)
                      richTextBox1.Text = "False input: Episode";
                else
                {
                    string episode = exePath + "\\Resources\\Season" + season + "\\" + textBox5.Text + ".txt";

                    StreamReader objstream = new StreamReader(episode); //Treba mi je using System.IO;

                    textBox1.Text = objstream.ReadToEnd();

                      richTextBox1.Clear();  /* Znaci,prvo sam uzea subtitle format i pretvoria ga u obicna slova ali
                                           sam misli stavia u " ".Onda sam procistia taj drugi format tako sta sam
                                          prizna samo ono u " " kao prolazno i usput zaminia " sa ' 'i trim() */
                    string lol = "";
                    string scrub = "";
                    string scrub2 = "";
                    int br = 0;
                    bool zad = false, isitnumber = false;
                    char[] numbandsign = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', ':', ';', '-' };
                    lol = textBox1.Text.Trim();

                    foreach (char b in lol)
                    {
                        if (b == '>' || zad == true)
                        {

                            if (numbandsign.Contains<char>(b) == true)
                                isitnumber = false;
                            if (b != '>' && b != '<' && numbandsign.Contains<char>(b) == false)
                             scrub += b;
                            zad = true;
                        
                        }
                        if (b == '<')
                        {

                            scrub += '"';
                            zad = false;
                        }
                    }

                    zad = true;
                    foreach (char b in scrub)
                    {
                        if (b == '"' || zad == true)
                        {

                            if (br == 1 && b == '"')
                            {
                                br = 0;
                                zad = false;
                            }
                            if (b == '"' && zad == true) br = 1;

                            if (br == 1)                   //Ako petlja prolazi recenicama kojima zelimo da prolazi
                                scrub2 += b;
                            zad = true;
                        }

                    }


                    string scrub3 = scrub2.Replace('"', ' ');
                    scrub3 = scrub3.Trim(' ');
                    if (scrub3.Length > 32)
                        scrub3 = scrub3.Remove(scrub3.Length - 32);
                    else
                          richTextBox1.Text = "False input lenght";  
                      richTextBox1.Text = " " + scrub3;

                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.twitter.com/TristanVujovic");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (  richTextBox1.Text == "")
            {
                textBox3.Font = new Font(textBox3.Font, FontStyle.Italic);
                textBox3.Text = "Nothing to quote";
            }
            else
            {
                textBox3.Font = new Font(textBox3.Font, FontStyle.Regular);
                Random p = new Random();

                int rec = p.Next(0,   richTextBox1.Text.Length);
                int br = -1, lol = 0;
                string quote = "";
                foreach (char b in   richTextBox1.Text)
                {
                    br++;
                    if (br >= rec)
                    {
                        if (char.IsUpper(b))                       //Od Random tocke u   richTextBox1.Textu,kad detektira veliko slovo pocni recenicu i spremaj je u quote
                            lol = 1;
                        if (lol == 1)
                            quote += b;
                    }
                    if (b == '.' && lol == 1)  //Ako je petlja iznad zeljene recenice i naide na tocku,izadi
                        break;
                }
                textBox3.Text = quote;

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int index = 0;
            string felop = richTextBox1.Text;
            richTextBox1.Text = "";
            richTextBox1.Text = felop;

            while(index < richTextBox1.Text.LastIndexOf(textBox3.Text))
            {
                richTextBox1.Find(textBox3.Text.LastIndexOf(textBox3.Text))

            }



            /*
            string[] felop = new string[400];
            string box2 = "";
            if (  richTextBox1.Text == "")
            {
                textBox6.Font = new Font(textBox6.Font, FontStyle.Italic);
                textBox6.Text = "Nothing to search for";
            }
            else
            {

                felop = textBox6.Text.Split(' ','.');
                box2 =   richTextBox1.Text.ToLower();
                foreach (string p in felop)
                {
                    if (box2.Contains(p))
                    {
                        textBox1.Text += " " + p;

                    }
                }



            }
 
              int  br = 0, br1 = 0,br2 = 0;
              string[] trica = new string[30];
              string[] duja = new string[500];
              duja =   richTextBox1.Text.Split(' ');
              trica = textBox3.Text.Split(' ');
              if (textBox3.Text != "" &&   richTextBox1.Text != "")
              {
                  trica = textBox3.Text.Split(' ');
                  foreach (string k in trica)
                  {
                      br2 ++;                       //Broj stringova u textbox3 tj duljina
                      foreach (string p in duja)
                      {
                          br1++;                                 //Broj stringova u textbox2  
                      }


                      if (  richTextBox1.Text.Contains(k))
                      {
                          br++;                                                //Broj stringova od pocetka txt3 do kraja txt 2 (txt3-txt2 = pocetak u txt 2)

                      }

                  }
                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectionLength = br2-br1;


              }
        */
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
           public void ye (object sender,EventArgs e)
            {
            textBox6.Text = "";
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
      
               
        }

        private void ye(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Nothing to search for")
            textBox6.Text = "";
        }
    }

}
