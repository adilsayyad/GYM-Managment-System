using Microsoft.AspNetCore.Mvc;

using GYM_Managment_System.Models;
using System.Data.SqlClient;

namespace GYM_Managment_System.Controllers
{
    
    public class AccountController : Controller


    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
       

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
      

        void connectionString()
        {
            con.ConnectionString ="Data Source=WAIANGDESK22;Initial Catalog=Gymmanagement;Integrated Security=True";
        }
        [HttpPost]
        public IActionResult Verify(Account acc )
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from Login where UserName = '" +acc.UserName+ "' and Password = '" +acc.Password+ "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }


         
        }
    }
}
