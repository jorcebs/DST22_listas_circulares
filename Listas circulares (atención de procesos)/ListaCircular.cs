using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_circulares__atención_de_procesos_
{
    class ListaCircular
    {
        Proceso inicio = null;

        public void meterAlFinal(Proceso nuevo)
        {
            if (inicio == null)
                inicio = nuevo;
            else
            {
                Proceso temp = inicio;
                while (temp.siguiente != null && temp.siguiente != inicio)
                    temp = temp.siguiente;
                temp.siguiente = nuevo;
            }
            nuevo.siguiente = inicio;
        }
        
        private Proceso buscar(Proceso proceso)
        {
            if (inicio == null)
                return null;
            else
            {
                Proceso temp = inicio;
                do
                {
                    if (temp == proceso)
                        return temp;
                    temp = temp.siguiente;
                }
                while (temp != inicio);
                return null;
            }
        }

        public void eliminar(Proceso proceso)
        {
            if (buscar(proceso) != null)
            {
                if (inicio == proceso)
                    eliminarInicio();
                else
                {
                    Proceso temp = inicio;
                    while (temp.siguiente != proceso)
                        temp = temp.siguiente;
                    temp.siguiente = temp.siguiente.siguiente;
                }
            }
        }

        private void eliminarInicio()
        {
            if (inicio != null)
            {
                if (inicio.siguiente == inicio)
                {
                    inicio.siguiente = null;
                    inicio = null;
                }
                else
                {
                    Proceso temp = inicio;
                    while (temp.siguiente != inicio)
                        temp = temp.siguiente;
                    temp.siguiente = inicio.siguiente;
                    inicio = inicio.siguiente;
                }
            }
        }

        public Proceso sacarPrimero()
        {
            Proceso primero = inicio;
            eliminar(inicio);
            return primero;
        }

        public int total()
        {
            int total = 0;
            if (inicio != null)
            {
                Proceso temp = inicio;
                do
                {
                    total++;
                    temp = temp.siguiente;
                }
                while (temp != inicio);
            }
            return total;
        }

        public int totalCiclos()
        {
            int totalCiclos = 0;
            if (inicio != null)
            {
                Proceso temp = inicio;
                do
                {
                    totalCiclos+=temp.ciclos;
                    temp = temp.siguiente;
                }
                while (temp != inicio);
            }
            return totalCiclos;
        }
    }
}