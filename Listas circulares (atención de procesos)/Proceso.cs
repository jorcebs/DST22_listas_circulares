using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_circulares__atención_de_procesos_
{
    class Proceso
    {
        public int ciclos;
        public Proceso siguiente;

        public Proceso(int ciclos)
        {
            this.ciclos = ciclos;
        }
    }
}
