using PM2_P2Tarea2_2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2_P2Tarea2_2.Controller
{
    public class Servicios
    {
        public async Task<bool> saveFirma(Firmas firmas)
        {
            var result = await App.DBaseFirma.FirmaSaveUpdate(firmas);
            return (result > 0);

        }


        public async Task<List<Firmas>> GetFirma()
        {
            return await App.DBaseFirma.getPageList();
        }
    }
}
