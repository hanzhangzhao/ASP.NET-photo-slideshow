using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


public class Conn
{
    public static IReadOnlyList<Photo> GetAllPhotos()
    {
        try
        {
            var photos = new List<Photo>();
            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT * FROM slideshow", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        photos.Add(new Photo(reader.GetInt32("ID"), reader.GetString("Name"), reader.GetString("Url"),
                            reader.GetString("Description")));

                }
            }
            return photos;
        }
        catch (MySqlException e)
        {
            throw new Exception("Unable to connect to SQL database");
        }
    }
}
