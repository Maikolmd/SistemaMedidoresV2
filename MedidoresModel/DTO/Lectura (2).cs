using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DTO
{
    public class Lectura
    {
        private int nroMedidor;
        private DateTime fecha;
        private double consumo;

        public int NroMedidor
        {
            get
            {
                return nroMedidor;
            }
            set
            {
                nroMedidor = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
            
        }
        public double Consumo
        {
            get
            {
                return consumo;
            }
            set
            {
                consumo = value;
            }
        }
    }
}
