using ClienteSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedidorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            string servidor = ConfigurationManager.AppSettings["servidor"];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conectando a Servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Conectado..");
                //recibir lo que envió el servidor, el orden de estas acciones depende del protocolo
                Console.WriteLine("Ingrese ID de Medidor");
                int idMedidor = Convert.ToInt32(Console.ReadLine().Trim());
                Console.WriteLine("Ingrese Fecha");
                DateTime fecha = Convert.ToDateTime(Console.ReadLine().Trim());
                Console.WriteLine("Ingrese Consumo");
                Double consumo = Convert.ToDouble(Console.ReadLine().Trim());

                string mensaje = idMedidor + "|" + fecha + "|" + consumo;

                if (clienteSocket.Escribir(mensaje))
                {
                    Console.WriteLine("S: {0}", clienteSocket.Leer());
                }
                else
                {
                    Console.WriteLine("S: {0}", clienteSocket.Leer());
                }
                clienteSocket.Desconectar();
            }
            else
            {
                Console.WriteLine("Error de Comunicación");
            }
            Console.ReadKey();

        }
    }
}
