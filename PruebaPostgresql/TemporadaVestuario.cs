﻿using PruebaMySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaPostgresql
{
    public partial class TemporadaVestuario : Form
    {
        string consulta;
        public TemporadaVestuario()
        {
            InitializeComponent();
        }

        private void TemporadaVestuario_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionPostgresql.ejecutaConsultaSelect("SELECT *FROM TemporadaVestuario ORDER BY idTemporadaVestuario");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idTemporada = textBox1.Text;
            string idVestuario = textBox4.Text;
            consulta = "INSERT INTO TemporadaVestuario(idTemporada, idVestuario) values('" + idTemporada + "','" + idVestuario + "')";
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idTemporada = textBox1.Text;
            string idVestuario = textBox4.Text;
            int idTemporadaVestuario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE TemporadaVestuario SET idTemporada = '" + idTemporada + "',idVestuario = '" + idVestuario + "' WHERE idTemporadaVestuario = " + idTemporadaVestuario.ToString();
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTemporadaVestuario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE TemporadaVestuario SET Estatus = False WHERE idTemporadaVestuario =  " + idTemporadaVestuario.ToString(); ;
            ConexionPostgresql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            TorneoVideojuego tv = new TorneoVideojuego();
            tv.Show();
            this.Hide();
        }
    }
}
