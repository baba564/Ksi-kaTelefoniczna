using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KsiazkaTelefoniczna.Enitity;
using KsiazkaTelefoniczna.Models;

namespace KsiazkaTelefoniczna
{
    public partial class Form1 : Form
    {
        public Tabela tabela { get; set; }
       
        public Form1()
        {
            tabela = new Tabela();
            InitializeComponent();
            LoadData();
           
        }

        public void AddContact()
        {

            

            
            Kontakty kontakt = new Kontakty();

            // string test = tabela.Database.SqlQuery<string>($@"select imie from dbo.kontakty").FirstOrDefault();


            kontakt.Imie = textBox1.Text;
            kontakt.Nazwisko = textBox2.Text;
            kontakt.NumerTelefonu = Int32.Parse(textBox3.Text);
          
            

            tabela.Kontakty.Add(kontakt);
            tabela.SaveChanges();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddContact();
            LoadData();
        }

        public void LoadData()
        {
            
            var Kontakty = tabela.Database.SqlQuery<ModelKontakt>($@"select imie,nazwisko,numertelefonu from dbo.kontakty").ToList();
            dataGridView1.DataSource=Kontakty;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        public void Search()
        {
            if(textBox3.TextLength>0)
            {
                var lista = tabela.Kontakty.Where(r => r.Nazwisko == textBox2.Text || r.Imie == textBox1.Text || r.NumerTelefonu == Int32.Parse(textBox3.Text)).ToList();
                dataGridView1.DataSource = lista;
            }
            else
            {
                var lista = tabela.Kontakty.Where(r => r.Nazwisko == textBox2.Text || r.Imie == textBox1.Text ).ToList();
                dataGridView1.DataSource = lista;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Delete()
        {
            Kontakty kontakt = new Kontakty();

            kontakt.Imie = textBox1.Text;
            kontakt.Nazwisko = textBox2.Text;
            kontakt.NumerTelefonu = Int32.Parse(textBox3.Text);
            tabela.Kontakty.Attach(kontakt);
            tabela.Kontakty.Remove(kontakt);
            tabela.SaveChanges();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
