using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Seeker_Folder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VistaFolderBrowserDialog fdb = new VistaFolderBrowserDialog();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fdb.Description = "Seleccionar directorio.";
            fdb.UseDescriptionForTitle = true;

            if (fdb.ShowDialog() == false) return;
            dirName.Content = fdb.SelectedPath;
            leerDirectorios(dirName.Content.ToString());
        }

        public static void leerDirectorios(string path)
        {
       

            List<string> listDirectory = new List<string>();
            try
            {
                if (Directory.Exists(path))
                {
                    List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));

                    foreach (var dir in dirs)
                    {
                        string namesOfDirectory = $"{dir.Substring(dir.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1)}";

                        listDirectory.Add(namesOfDirectory);

                    }
                    DirectoryInfo dis = new DirectoryInfo(path);
                    DirectoryInfo parentDir = dis.Parent;
                    string lastFolderName = System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(path));
                    MessageBox.Show(lastFolderName);
                    Console.WriteLine(parentDir);
                    /*if (!Directory.Exists(Directory.GetCurrentDirectory()))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory());
                    }*/
                    foreach (string dir in listDirectory)
                    {
                        if (!Directory.Exists(@".\" + "/ListSeekerFolders/" + lastFolderName + dir))
                        {
                            Directory.CreateDirectory(@".\" + "/ListSeekerFolders/" + lastFolderName + dir);
                        }
                    }
                    MessageBox.Show("Tarea completada");
                    //resultFolder.Text = listDirectory.Items.Count.ToString();
                }
                else
                {
                    MessageBox.Show("No se necuentra este directorio");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
