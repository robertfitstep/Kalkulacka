using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kalkulacka
{
    public partial class Kalkulačka : Form
    {
        public Kalkulačka()
        {
            InitializeComponent();

            bt1.Tag = "1"; bt2.Tag = "2"; bt3.Tag = "3";
            bt4.Tag = "4"; bt5.Tag = "5"; bt6.Tag = "6";
            bt7.Tag = "7"; bt8.Tag = "8"; bt9.Tag = "9";
                           bt0.Tag = "0";
            
            btPlus.Tag = "+";
            btMinus.Tag = "-";
            btKrat.Tag = "*";
            btDeleno.Tag = "/";
            btZatvorkaZaciatok.Tag = "(";
            btZatvorkaKoniec.Tag = ")";
            btRovnaSa.Tag = "=";
            btBackspace.Tag = "Backspace";
        }

        private string textDispleja = "";
        private DataTable dt = new DataTable();
        
        private void KlikNaTlacidlo(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Tag)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "+":
                case "-":
                case "*":
                case "/":
                case "(":
                case ")":
                    dopisNaDisplej(b.Tag.ToString());
                    break;
                case "=":
                    vypocitaj();
                    break;
                case "Backspace":
                    vymazPismeno();
                    break;
            }
        }

        private void vymazPismeno()
        {
            textDispleja = textDispleja.Substring(0,textDispleja.Length-1);
            tbDisplej.Text = textDispleja;
        }

        private void dopisNaDisplej(string znak)
        {
            textDispleja += znak;
            tbDisplej.Text = textDispleja;
        }

        private void vypocitaj()
        {
            try
            {
                textDispleja = dt.Compute(textDispleja, "").ToString();
                tbDisplej.Text = textDispleja;
                textDispleja = "";
            }
            catch (Exception e)
            {
                Console.WriteLine("Hlaska: " + e.Message);
                zobrazChybu();
            }
        }

        private void zobrazChybu()
        {
            tbDisplej.Text = "err";
            zapnutTlacidla(false);
            Thread.Sleep(3000);
            tbDisplej.Text = textDispleja;
            zapnutTlacidla(true);
        }

        private void zapnutTlacidla(bool prepinac)
        {
            Console.WriteLine("zapnut tlacidla = {0}", prepinac);
            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button b = (Button)control;
                    b.Enabled = prepinac;
                }
            }
        }

    }
}
