using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel
{
    public class Medidor
    {
        private int idMedidor;
        private string tipo;
       
        public int IdMedidor
        {
            get
            {
                return idMedidor;
            }
            set
            {
                idMedidor = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
    }
}
