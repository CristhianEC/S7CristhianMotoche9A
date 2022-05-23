using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7CristhianMotoche9A.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7CristhianMotoche9A
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Estudiante> _TablaEstudiante;
        
        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }
        
        protected async override void OnAppearing()
        {
            var resultado = await _conn.Table<Estudiante>().ToListAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaUsuarios.ItemsSource = _TablaEstudiante;
            base.OnAppearing();
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            Estudiante estudiante = (Estudiante)e.SelectedItem;
            try
            {
                Navigation.PushAsync(new Editar(estudiante));

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}