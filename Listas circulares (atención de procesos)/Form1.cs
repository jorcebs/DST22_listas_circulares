using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_circulares__atención_de_procesos_
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            ListaCircular miLista = new ListaCircular();
            int procesosAtendidos = 0;
            int ciclosVacía = 0;
            int maxProcesosFormados = 0;

            for (int i = 0; i < 200; i++)
            {
                // 25% de probabilidades de agregar un nuevo proceso a la cola
                if (random.Next(4) == 0)
                {
                    Proceso nuevo = new Proceso(random.Next(4, 13));
                    miLista.meterAlFinal(nuevo);
                }

                Proceso atendido = miLista.sacarPrimero();

                // Si hay procesos que atender, atiéndelos
                if (atendido != null)
                {
                    // Procesa
                    atendido.ciclos--;

                    // Si no se termina de procesar, vuélvelo a meter
                    if (atendido.ciclos == 0)
                        procesosAtendidos++;
                    else
                        miLista.meterAlFinal(atendido);

                    maxProcesosFormados = (miLista.total() > maxProcesosFormados) ? miLista.total() : maxProcesosFormados;
                }
                else
                    ciclosVacía++;
            }

            // Datos
            txtLog.Text = "Se atendieron un total de " + procesosAtendidos.ToString() + " procesos" + Environment.NewLine;
            txtLog.Text += "No. máximo de procesos formados: " + maxProcesosFormados.ToString() + Environment.NewLine;
            txtLog.Text += "Procesos pendientes: " + miLista.total().ToString() + Environment.NewLine;
            txtLog.Text += "Cantidad de ciclos en los que estuvo vacía la lista: " + ciclosVacía.ToString() + Environment.NewLine;
            txtLog.Text += "Hicieron falta " + miLista.totalCiclos().ToString() + " ciclos para terminar de procesar la lista";
        }
    }
}
