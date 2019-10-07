using MedidorModel.DAL;
using MedidorModel.DTO;
using SistemaMedidorServidor.Comunicaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaMedidorServidor
{
    class Program
    {
        private static  ILecturaDAL lecturaDAL = LecturaDALArchivo.GetInstancia();
        private static  IMedidorDAL medidorDAL = MedidorDALArchivo.GetInstancia();

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1.- Mostrar lecturas");
            Console.WriteLine("0.- Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    MostrarLectura();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Intente nuevamente");
                    break;
            }
            return continuar;
        }
        static void Main()
        {
            HebraServidor hs = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hs.Levantar));
            t.IsBackground = true;
            t.Start();
            while (Menu());
        }
        static void MostrarLectura()
        {
            List<Lectura> ls = null;
            lock (lecturaDAL)
            {
                ls = lecturaDAL.VerLectura();
            }
            foreach (Lectura lectura in ls)
            {
                Console.WriteLine(lectura);
            }
        }
    }
}
