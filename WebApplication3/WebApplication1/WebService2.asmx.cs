using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        const string connectionString = @"server=localhost;user id=root;Password=;database=information;persist security info=False";

        public class Person
        {
            public int id { get; set; }
            public string name { get; set; }
            public int phone { get; set; }
        }

        [WebMethod]
        public Person findperson(int id)
        {
            Person person = new Person();

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            command.CommandText = "SELECT * FROM information where id=" + Convert.ToString(id);
            command.Prepare();
            //command.Parameters.AddWithValue("@p1", item);
            reader = command.ExecuteReader();
            reader.Read();
            person.id = Convert.ToInt32(reader["id"]);
            person.name = reader["name"].ToString();
            person.phone = Convert.ToInt32(reader["phone"]);

            reader.Close();
            connection.Close();

            return person;
        }
    }
}
