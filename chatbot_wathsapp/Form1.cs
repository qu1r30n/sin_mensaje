﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using chatbot_wathsapp.clases;
using chatbot_wathsapp.clases.herramientas;
using chatbot_wathsapp.formularios;

namespace chatbot_wathsapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            poner_al_inicio_del_programa pon_inicio = new poner_al_inicio_del_programa();
            pon_inicio.inicio();
            //Tex_base.GG_base_arreglo_de_arreglos
            
        }

        private void btn_chatbot_Click(object sender, EventArgs e)
        {
            chatbot ch_bot = new chatbot();
            ch_bot.Show();
        }
    }
}
