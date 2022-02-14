using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2P1EJ3.Models;
using System.Threading.Tasks;

namespace PM2P1EJ3.Models
{
    public class PersonasDB
    {
        readonly SQLiteAsyncConnection db;

        // Constructor de Clase Vacio
        public PersonasDB() { }

        // Constructor de Clase
        public PersonasDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // Crear tabla de Base de Datos
            db.CreateTableAsync<Personas>();
        }

        /* Funciones DB */

        // Return tabla personas como una Lista
        public Task<List<Personas>> listapersonas()
        {
            return db.Table<Personas>().ToListAsync();
        }

        // Buscar una persona especifica por el ID
        public Task<Personas> ObtenerPersona(Int32 pId)
        {
            return db.Table<Personas>().Where(i => i.Id == pId).FirstOrDefaultAsync();
        }

        // Guardar y Actualizar Persona
        public Task<Int32> GuardarPersona(Personas persona)
        {
            if (persona.Id != 0) {
                return db.UpdateAsync(persona);
            }
            else { 
                return db.InsertAsync(persona);
            }

        }

        public Task<Int32> BorrarPersonas(Personas persona)
        {
            return db.DeleteAsync(persona);
        }
    }
}
