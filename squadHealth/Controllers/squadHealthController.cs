using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using squadHealth.Models;

namespace squadHealth.Controllers
{
    public class squadHealthController : ApiController
    {

        // GET: api/squadHealth/
        public void Get([FromUri] vote input)
        {

            squadHealthEntities db = new squadHealthEntities();

            tbl_squadHealth newObj = new tbl_squadHealth();

            newObj.colour = input.colour;
            newObj.lastUpdateTime = Convert.ToDateTime(input.lastUpdateTime);
            newObj.questionNumber = Convert.ToInt16(input.questionNumber);
            newObj.sprintId = Convert.ToInt16(input.sprintId);
            newObj.userId = input.userId;

            var row = (from r in db.tbl_squadHealth
                      where r.sprintId == newObj.sprintId &&
                        r.userId == newObj.userId &&
                        r.questionNumber == newObj.questionNumber
                      select r);
                      
            db.tbl_squadHealth.Add(newObj);
            db.SaveChanges();

         
        }

 
    }
}
