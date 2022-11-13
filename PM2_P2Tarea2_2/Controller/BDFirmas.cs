using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PM2_P2Tarea2_2.Models;

namespace PM2_P2Tarea2_2.Controller
{
    public class BDFirmas
    {
        readonly SQLiteAsyncConnection dbase;
        /*Constructor de clase*/

        public BDFirmas(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la base de datos
            dbase.CreateTableAsync<Firmas>();//creando tabla de firmas


        }

        #region Operaciones

        //CRUD -CREATE  -READ  


        //Create
        public Task<int> FirmaSaveUpdate(Firmas firmas)
        {
            if (firmas.id != 0)
            {
                return dbase.UpdateAsync(firmas);
            }
            else
            {
                return dbase.InsertAsync(firmas);
            }
        }

        //Read
        public Task<List<Firmas>> getPageList()
        {
            return dbase.Table<Firmas>().ToListAsync();
        }


        #endregion Operaciones
    }
}
