using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using S7CristhianMotoche9A.Models;
using System.IO;

namespace S7CristhianMotoche9A
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;

        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();

        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("SELECT * FROM  Estudiante  where Usuario  = ?  and Contrasenia = ?", usuario, contrasenia);
            
        }


        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");

                var db = new SQLiteConnection(databasePath);

                db.CreateTable<Estudiante>();

                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, usuario.Text, contrasenia.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());

                }
                else
                {
                    DisplayAlert("Alerta", "Veriifique el Usurio o Contraseña!", "OK");

                }


            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }

        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
            
        }
    }
}