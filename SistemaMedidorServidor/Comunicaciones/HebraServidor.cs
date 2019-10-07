using MedidorModel.DAL;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaMedidorServidor.Comunicaciones
{
    public class HebraServidor
    {
        private static IMedidorDAL medidorDAL = new MedidorDALArchivo();

        public void Levantar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket servidor = new ServerSocket(puerto);
            Console.WriteLine("Se está levantando el Server en puerto {0}", puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("Esperando Cliente...");
                    Socket cliente = servidor.ObtenerCliente();
                    ClienteCom clienteCom = new ClienteCom(cliente);
                    HebraCliente clienteHebra = new HebraCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteHebra.Ejecutar));

                }
            }
        }
    }
}
