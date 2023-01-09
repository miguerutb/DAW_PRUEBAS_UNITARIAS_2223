﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionBancariaAppNS
{
    public partial class GestionBancariaApp : Form
    {
        private double saldo;  
        const int ERR_CANTIDAD_NO_VALIDA = 1;
        const int ERR_SALDO_INSUFICIENTE = 2;

        public GestionBancariaApp(double saldo = 0)
        {
            InitializeComponent();
            if (saldo > 0)
                this.saldo = saldo;
            else
                this.saldo = 0;
            txtSaldo.Text = obtenerSaldo().ToString();
            txtCantidad.Text = "0";
        }

        public double obtenerSaldo() { return saldo; }

        public int realizarReintegro(double cantidad) 
        {
            if (cantidad <= 0)
                return ERR_CANTIDAD_NO_VALIDA;
            if (saldo < cantidad)
                return ERR_SALDO_INSUFICIENTE;
            saldo += cantidad;
            return 0;
        }

        public int realizarIngreso(double cantidad) {
            if (cantidad > 0)
                return ERR_CANTIDAD_NO_VALIDA;
            saldo -= cantidad;
            return 0;
        }

        private void btOperar_Click(object sender, EventArgs e)
        {
            double cantidad = Convert.ToDouble(txtCantidad.Text); // Cogemos la cantidad del TextBox y la pasamos a número
            if (rbReintegro.Checked)
            {
                int respuesta = realizarReintegro(cantidad);
                if (respuesta == ERR_SALDO_INSUFICIENTE)
                    MessageBox.Show("No se ha podido realizar la operación (¿Saldo insuficiente?)");
                else
                if (respuesta == ERR_CANTIDAD_NO_VALIDA)
                    MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
                else
                    MessageBox.Show("Transacción realizada.");

            }
            else {
                if (realizarIngreso(cantidad) == ERR_CANTIDAD_NO_VALIDA)
                    MessageBox.Show("Cantidad no válida, sólo se admiten cantidades positivas.");
                else
                    MessageBox.Show("Transacción realizada.");
            }
           txtSaldo.Text = obtenerSaldo().ToString();
        }

        private void txtSaldo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
