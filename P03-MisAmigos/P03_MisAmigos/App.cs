using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using P03_MisAmigos.Clases;
using P03_MisAmigos.Paginas;

namespace P03_MisAmigos
{
	public class App : Application
	{
        public static BaseDatos BD;

        public App ()
		{
            string db = "amigos.db3";
            string ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), db);
            BD = new BaseDatos(ruta);

            // The root page of your application
            MainPage = new NavigationPage(new PaginaListaAmigos());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
