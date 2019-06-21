using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MM.DataServices.Controllers
{
    [Route("api/[controller]")]
    public class CopyrightsController : Controller
    {
        // GET api/copyrights
        [HttpGet]
        public string Get()
        {
            return "Ⓒ MarcMan.xyz. The actual or attempted unauthorized access, use, or modification of this service is " +
                "strictly prohibited. Unauthorized users are subject to disciplinary proceedings and/or criminal and civic " +
                "penalties under applicable state, fedreal, or applicable demestic and foreign laws. The users of this service " +
                "may be monitored and recorded for administrative and security reasons. Anyone accessing this service " +
                "expressly consents to such monitoring and is advised that if monitoring reveals possible evidence of " +
                "activity, we may provide information of such activity to law enforcement officials.";
        }
    }
}
