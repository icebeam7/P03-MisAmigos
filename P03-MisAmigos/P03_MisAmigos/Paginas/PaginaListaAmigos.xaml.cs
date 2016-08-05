using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using P03_MisAmigos.Clases;

namespace P03_MisAmigos.Paginas
{
	public partial class PaginaListaAmigos : ContentPage
	{
		public PaginaListaAmigos ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lsvAmigos.ItemsSource = App.BD.ObtenerAmigos();
        }

        private void lsvAmigos_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Amigo amigo = e.SelectedItem as Amigo;
                PaginaAmigo pagina = new PaginaAmigo();
                pagina.ID = amigo.ID;
                Navigation.PushAsync(pagina);
            }
        }

        void btnNuevo_Click(object sender, EventArgs a)
        {
            Navigation.PushAsync(new PaginaAmigo());
        }
    }
}
