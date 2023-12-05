using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;



namespace LibraryApp.Pages
{
    public class Admin : PageModel
    {

        public List<Signup_data> listUsers = new List<Signup_data>();
       public void OnGet()
       { 
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Library;Integrated Security=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM login";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Signup_data data = new Signup_data();
                                data.id = reader.GetInt32(0);
                                data.firstname = reader.GetString(1);
                                data.lastname = reader.GetString(2);
                                data.email = reader.GetString(3);
                                data.password = reader.GetString(4);

                                listUsers.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
       }
    }

    public class Signup_data
    {
        public int id;
        public string firstname;
        public string lastname;
        public string email;
        public string password; 
    }

}
