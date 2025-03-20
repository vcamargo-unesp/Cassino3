﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cassino3
{
    public partial class Form1 : Form
    {
        int[] roleta;
        int[] ciclos;
        Label[] tela;
        Random r;
        public Form1()
        {
            InitializeComponent();
            roleta = new int[3];
            ciclos = new int[3];
            tela = new Label[] { lbl1, lbl2, lbl3 };
            r = new Random();
            for (int i = 0; i < roleta.Length; i++)
            {
                roleta[i] = r.Next(0, 10);
                Atualizar(i);
            }
        }

        void Atualizar(int i)
        {
            tela[i].Text = roleta[i].ToString();
        }

        private void btGirar_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < ciclos.Length; i++)
            {
                ciclos[i] = r.Next(1, 21);
                tela[i].ForeColor = Color.Black;
            }
            Array.Sort(ciclos);
            btGirar.Enabled = false;
            tmrGiro.Enabled = true;
        }

        private void tmrGiro_Tick(object sender, EventArgs e)
        {
            bool parado = true;
            for (int i = 0;i < ciclos.Length; i++)
            {
                if (ciclos[i] > 0)
                {
                    ciclos[i]--;
                    if (ciclos[i] == 0)
                    {
                        tela[i].ForeColor = Color.Red;
                    }
                    roleta[i]++;
                    if (roleta[i] == 10)
                        roleta[i] = 0;
                    Atualizar(i);
                    parado &= false;
                }
                else
                {
                    parado &= true;
                }
            }

            if (parado)
            {
                tmrGiro.Enabled = false;
                btGirar.Enabled = true;
            }
        }
    }
}
