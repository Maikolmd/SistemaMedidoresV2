using MedidorModel;
using MedidorModel.DAL;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedidorServidor.Comunicaciones
{
    class HebraCliente
    {
        private ClienteCom clienteCom;
        private IMedidorDAL medidorDAL = new MedidorDALArchivo();
        private ILecturaDAL lecturaDAL = LecturaDALArchivo.GetInstancia();
        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        } 
         
        public void Ejecutar()
        {
            string mensaje;
            mensaje = clienteCom.Leer();
            string[] tArr = mensaje.Trim().Split('|');
            int NroMed = Convert.ToInt32(tArr[0]);
            DateTime fecha = Convert.ToDateTime(tArr[1]);
            double consumo = Convert.ToDouble(tArr[2]);

            Lectura l = new Lectura()
            {
                NroMedidor = NroMed,
                Fecha = fecha,
                Consumo = consumo
            };
            List<Medidor> medidor = medidorDAL.ObtenerMedidor().FindAll(m => m.IdMedidor == NroMed);
            if (medidor.Count > 0)
            {
                lock (lecturaDAL)
                {
                    lecturaDAL.AgregarLectura(l);
                }
                clienteCom.Escribir("LISTO");
            }
            else
            {
                clienteCom.Escribir("ERROR");
            }

            clienteCom.Desconectar();
        }

    }
}
