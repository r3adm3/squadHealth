using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using squadHealth.Models;

namespace squadHealth.Controllers
{
    public class teamResultController : ApiController
    {
        // GET: api/teamResult
        public string Get([FromUri] teamResult input)
        {

            squadHealthEntities db = new squadHealthEntities();

            int qNumber = Convert.ToInt16(input.questionNumber);

            var result = (from r in db.tbl_squadHealth
                          where r.questionNumber == qNumber
                          group r by r.colour into g
                          let gCount = g.Count()
                          orderby gCount
                         select new { colour = g.Key, colourCount = g.Count() }).FirstOrDefault();

            if (result != null)
            {
                return result.colour;
            }
            else
            {
                return "green";
                
            }

            
        }
    }
}
