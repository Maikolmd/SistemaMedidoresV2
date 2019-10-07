using MedidorModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DAL
{
    public class MedidorDALArchivo : IMedidorDAL
    {
        private static List<Medidor> medidores = new List<Medidor>();
        
        public List<Medidor> ObtenerMedidor()
        {
            
            Medidor medidor1 = new Medidor
            {
                IdMedidor = 1,
                Tipo = "Monofasico"
            };
            medidores.Add(medidor1);

            Medidor medidor2 = new Medidor
            {
                IdMedidor = 2,
                Tipo = "Trifásico"

            };
            medidores.Add(medidor2);

            Medidor medidor3 = new Medidor
            {
                IdMedidor = 3,
                Tipo = "Monofasico"

            };
            medidores.Add(medidor3);

            Medidor medidor4 = new Medidor
            {
                IdMedidor = 4,
                Tipo = "Trifásico"

            };
            medidores.Add(medidor4);

            return medidores;
        }
    }
}
