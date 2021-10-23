using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapsamlı_Kayıt_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("TC KİMLİK NO", 150);
            listView1.Columns.Add("ADI SOYADI", 200);
            listView1.Columns.Add("YAŞ", 50);
            listView1.Columns.Add("MEZUNİYET", 150);
            listView1.Columns.Add("CİNSİYET", 125);
            listView1.Columns.Add("DOĞUM YERİ", 125);
            listView1.Columns.Add("TELEFON NO", 125);

            string[] mezuniyet = { "İlköğretim", "Ortaöğretim", "Lisans", "Yüksek Lisans","Doktora" };
            comboBox1.Items.AddRange(mezuniyet);
            kayitsayisiyaz();


        }
        private void kayitsayisiyaz()
        {
            int kayitsayisi = listView1.Items.Count;
            label8.Text = Convert.ToString(kayitsayisi);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tc = "", adsoyad = "", yas="0", mezuniyet = "", cinsiyet="", dogumyeri="", telno = "";
            tc = textBox1.Text;
            adsoyad = textBox2.Text;
            yas = textBox3.Text;
            mezuniyet = comboBox1.Text;
            if (radioButton1.Checked == true)
                cinsiyet = radioButton1.Text;
            else if (radioButton2.Checked == true)
                cinsiyet = radioButton2.Text;

            dogumyeri = textBox5.Text;
            telno = textBox6.Text;

            string[] bilgiler = { tc, adsoyad, yas, mezuniyet, cinsiyet, dogumyeri, telno };

            bool aranankayitkonrolu = false;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text==textBox1.Text)
                {
                    aranankayitkonrolu = true;
                    MessageBox.Show(textBox1.Text + " TC KİMLİK NUMARASI ZATEN KAYITLI!!");
                }
                
            }
            if (aranankayitkonrolu==false)
            {
                ListViewItem lst = new ListViewItem(bilgiler);
                if (tc != "" && adsoyad != "" && yas !=  "" && mezuniyet != ""  && cinsiyet != "" && dogumyeri != "" && telno != "")
                {
                    listView1.Items.Add(lst);
                }
                else
                    MessageBox.Show("Kayit Bilgilerinde Eksiklik Var!");
            }
            kayitsayisiyaz();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int secilensayisi = listView1.CheckedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.CheckedItems)
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secilensayisi.ToString() + " Adet Kayit Silindi.");
            kayitsayisiyaz();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secilensayisi = listView1.SelectedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.SelectedItems)
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secilensayisi.ToString() + " Adet Kayit Silindi.");
            kayitsayisiyaz();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            kayitsayisiyaz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool aranankayitkontrolu = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    aranankayitkontrolu = true;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text = listView1.Items[i].SubItems[2].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[3].Text;
                    if (listView1.Items[i].SubItems[4].Text == "BAY")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[4].Text=="BAYAN")
                    {
                        radioButton2.Checked = true;
                    }
                    textBox5.Text = listView1.Items[i].SubItems[5].Text;
                    textBox6.Text = listView1.Items[i].SubItems[6].Text;
                    textBox2.Enabled = false;textBox3.Enabled = false;comboBox1.Enabled = false;
                    groupBox1.Enabled = false; textBox5.Enabled = false; textBox6.Enabled = false;


                }
            }
            if (aranankayitkontrolu == false)
                MessageBox.Show(textBox1.Text + " TC KİMLİK NUMARALI KAYIT BULUNAMADI!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true; textBox3.Enabled = true; comboBox1.Enabled = true;
            groupBox1.Enabled = true; textBox5.Enabled = true; textBox6.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            
            
        }
    }
}
