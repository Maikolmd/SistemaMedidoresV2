using MedidorModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DAL
{
    public class LecturaDALArchivo : ILecturaDAL
    {
        private LecturaDALArchivo()
        {

        }

        private static LecturaDALArchivo instancia;

        public static ILecturaDAL GetInstancia()
        {
            if (instancia==null)
            {
                instancia = new LecturaDALArchivo();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";

        public void AgregarLectura(Lectura lectura)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(url, true))
                {
                    writer.Write(lectura.NroMedidor + ";" + lectura.Fecha + ";" + lectura.Consumo);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de escritura en archivo"+ex.Message);
            }
        }

        public List<Lectura> VerLectura()
        {
            List<Lectura> lecturas = new List<Lectura>();
            using (StreamReader r = new StreamReader(url))
            {
                string texto;
                do
                {
                    texto = r.ReadLine();
                    if (texto != null)
                    {
                        string[] tArr = texto.Trim().Split(';');
                        int NroMed = Convert.ToInt32(tArr[0]);
                        DateTime fecha = Convert.ToDateTime(tArr[1]);
                        double consumo = Convert.ToDouble(tArr[2]);

                        Lectura l = new Lectura()
                        {
                            NroMedidor = NroMed,
                            Fecha = fecha,
                            Consumo = consumo
                        };
                        lecturas.Add(l);
                    }
                } while (texto != null);
            }
            return lecturas;
        }
    }
}
