using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using sol_denka_stockmanagement.Commons;
using sol_denka_stockmanagement.Database;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;

namespace sol_denka_stockmanagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try 
            {
                EnsureDbDirectory();
                using var db = new AppDbContext();
                db.Database.Migrate();
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show(Messages.InitializeDbError);
                Shutdown();
            }
        }

        private void EnsureDbDirectory()
        {
            var dir = @"C:\DenkaStockManagementDb";
            Directory.CreateDirectory(dir);
        }
    }
}
