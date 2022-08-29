using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ShowSQL
{
   
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Server = FLO-PC\\MYSQLSERVER; Database = FlorianDB; Trusted_Connection = Yes";       
        public MainWindow()
        {     
        InitializeComponent();    
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var oTask = new Task(TaskName.Text, TaskTime.Text, TaskPic.Text);
            using (SqlConnection oSqlConnection = new SqlConnection(ConnectionString))
            {
                oSqlConnection.Open();
                using (SqlCommand oSqlCommand = new SqlCommand())
                {
                    oSqlCommand.Connection = oSqlConnection;
                    oSqlCommand.Parameters.AddWithValue("@TaskName", oTask.Name);
                    oSqlCommand.Parameters.AddWithValue("@TaskTime", oTask.dateTime.ToString("HH:mm"));
                    //Es soll noch ein Bild eingefügt werden
                    oSqlCommand.CommandText = @"
INSERT INTO Task
(
  TaskName,
 TaskTime
) VALUES (
  @TaskName,
  @TaskTime
)";

                    if(oSqlCommand.ExecuteNonQuery() == 1)
                    {                       
                        MessageBox.Show("Datensatz erfolgreich eingefügt.");
                    }
                    else
                    {
                        MessageBox.Show("Datensatz konnte nicht eingefügt werden.");
                    }
                }
            }
            ListItemTask.Items.Add(oTask);
        }

        

        private void Button_Close(object sender, RoutedEventArgs e)
        {     
            Button btn = sender as Button;
            // Ich muss noch herausfinden wie das Objekt erkennen auf dem der Button ist
            ListItemTask.Items.RemoveAt(0);
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
