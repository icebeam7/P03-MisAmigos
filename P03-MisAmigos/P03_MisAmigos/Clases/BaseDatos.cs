using System;
using System.Linq;
using System.Collections.ObjectModel;
using SQLite;

namespace P03_MisAmigos.Clases
{
    public class BaseDatos : SQLiteConnection
    {
        public BaseDatos(string path) : base(path)
        {
            CrearTablas();
        }

        void CrearTablas()
        {
            CreateTable<Amigo>();
        }

        public ObservableCollection<Amigo> ObtenerAmigos()
        {
            return new ObservableCollection<Amigo>(this.Table<Amigo>().ToList());
        }

        public Amigo ObtenerAmigo(string id)
        {
            return (id == "") ? new Amigo() : Table<Amigo>().Where(t => t.ID == id).First();
        }

        public void GuardarAmigo(string id, string nombre, int sexo, DateTime cumple, string correo, string telefono, bool esMejorAmigo)
        {
            Amigo amigo = ObtenerAmigo(id);
            amigo.Nombre = nombre;
            amigo.Sexo = sexo;
            amigo.Cumple = cumple;
            amigo.Correo = correo;
            amigo.Telefono = telefono;
            amigo.EsMejorAmigo = esMejorAmigo;

            if (id == "")
                AgregarAmigo(amigo);
            else
                ActualizarAmigo(amigo);
        }

        private void AgregarAmigo(Amigo amigo)
        {
            amigo.ID = Guid.NewGuid().ToString();
            this.Insert(amigo);
        }

        private void ActualizarAmigo(Amigo amigo)
        {
            this.Update(amigo);
        }

        public void EliminarAmigo(string id)
        {
            Amigo amigo = Table<Amigo>().Where(t => t.ID == id).First();
            this.Delete(amigo);
        }

    }
}
