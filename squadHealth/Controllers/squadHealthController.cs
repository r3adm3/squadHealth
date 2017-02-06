using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using squadHealth.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace squadHealth.Controllers
{
    public class squadHealthController : ApiController
    {

        // GET: api/squadHealth/
        public void Get([FromUri] vote input)
        {

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["directLocalDB"];
            string sprintId = ConfigurationManager.AppSettings["sprintID"];

            SqlConnection conn = new SqlConnection(settings.ToString());

            string mergeCmd = "update tbl_squadHealth set colour = '" + input.colour + "' where userid  ='" + input.userId+ "' and questionNumber = '"+ input.questionNumber+"' and sprintId = '"+ input.sprintId + "'";

            SqlCommand cmd = new SqlCommand(mergeCmd, conn);

            conn.Open();
            var noOfResults = cmd.ExecuteNonQuery();

            if (noOfResults == 0) { 

                squadHealthEntities db = new squadHealthEntities();

                tbl_squadHealth newObj = new tbl_squadHealth();

                newObj.colour = input.colour;
                newObj.lastUpdateTime = Convert.ToDateTime(input.lastUpdateTime);
                newObj.questionNumber = Convert.ToInt16(input.questionNumber);
                newObj.sprintId = Convert.ToInt16(sprintId);
                newObj.userId = input.userId;

                db.tbl_squadHealth.Add(newObj);
                db.SaveChanges();

            }
        }


       

    }
}
