using System.Collections.Generic;
using System.Linq;
using MM.DataServices.Models;
using System.Net;
using System.Net.Mail;
using System;

namespace MM.DataServices.Commons
{
    /// <summary>
    /// describes the functionalities to manage the business and data requirements for Site Common usage needs
    /// </summary>
    public class CommonDataManager
    {

        /// <summary>
        /// Get Recent news 
        /// </summary>
        /// <returns></returns>
        public List<TbRecentNews> GetRecentNews()
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                {
                    var q = (from r in context.TbRecentNews orderby r.PostingDate descending select r).Take(8).ToList();
                    return q;
                }
            }
        }

        /// <summary>
        /// Get states
        /// </summary>
        /// <returns></returns>
        public List<TbStates> GetStates()
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var q = (from s in context.TbStates orderby s.Name ascending select s).ToList();
                return q;
            }
        }

        /// <summary>
        /// Get public school Cities
        /// </summary>
        /// <returns></returns>
        public List<string> GetPulicSchoolCities(string state)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var Cities = (from s in context.TbPublicSchools where s.State.Equals(state) orderby s.City ascending select s.City).Distinct().ToList();
                return Cities;
            }
        }

        public void SendGenEmailToUser(string memberName, string fromEmail, string toEmail, string fromName, string toName, string subject, string msg)
        {
            string name = memberName;

            if (string.IsNullOrEmpty(memberName))
                name = "LG Administration";

            //(1) Create the MailMessage instance
            fromEmail = "postmaster@marcman.xyz"; //required for smarterasp.net hosting (see value in web config)

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, name); //IMPORTANT: This must be same as your smtp authentication address.
            mail.To.Add(toEmail);

            //(2) Assign the MailMessage's properties
            mail.Subject = subject;
            mail.Body = HTMLBodyText(fromName, toName, msg);
            mail.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            string smtpHost = "mail.marcman.xyz";  //host required for smarterasp.net hosting (see value in web.config)
            SmtpClient smtp = new SmtpClient(smtpHost);
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = false;
            //smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            //IMPORANT:  Your smtp login email MUST be same as your FROM address.
            NetworkCredential Credentials = new NetworkCredential(fromEmail, "Tasia360#");
            smtp.Credentials = Credentials;

            //(4) Send the MailMessage
            smtp.Send(mail);
        }

        private static string HTMLBodyText(string fromName, string toName, string msg)
        {
            string str = "";
            //string firstName = Request.Cookies["FirstName"].Value.ToString();

            str = str + "<table width='100%' style='text-align: center;'>";
            str = str + "<tr>";
            str = str + "<td style='font-weight: bold; font-size: 14pt; height: 25px; text-align: left; background-color: #4a6792;";
            str = str + "vertical-align: middle; color: White; font-family:Lucida Grande, tahoma, helvetica;'>";
            str = str + "&nbsp;LinkedGlobe";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "<tr><td>&nbsp;</td></tr>";
            str = str + "<tr>";
            str = str + "<td style='font-size: 12pt; text-align: left; width: 100%; font-family: font-family:Lucida Grande, tahoma, helvetica;'>";
            str = str + "<p>Hi " + toName + ",<p/>";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "<tr>";
            str = str + "<td style='font-size: 12pt; text-align: left; width: 100%; font-family: font-family:Lucida Grande, tahoma, helvetica;'>";
            str = str + "<p>" + fromName + " has sent you the following message from LinkedGlobe:<br/><br/>";
            str = str + "<p></p><p>";
            str = str + "<p> " + msg + "<br/>";
            str = str + "</p>";

            str = str + "<p></p><p>";

            str = str + "You can access the site via the link below. <br />";
            str = str + "<a href='www.linkedglobe.com/lg/index.html'>www.marcman.xyz/index.html</a></p>";

            str = str + "<p>";
            str = str + "Sincerely yours,<br />";
            str = str + "The LinkedGlobe Team <br />";
            str = str + "</p>";
            str = str + "</td>";
            str = str + "</tr>";
            str = str + "</table>";

            return str;
        }

        public void SendMail(string memberName, string fromEmail, string toEmail, string subject, string body, bool isBodyHtml)
        {
            string name = memberName;

            if (string.IsNullOrEmpty(name))
                name = "LG Administration";

            //(1) Create the MailMessage instance
            fromEmail = "postmaster@marcman.xyz";

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, name); //IMPORTANT: This must be same as your smtp authentication address.
            mail.To.Add(toEmail);

            //(2) Assign the MailMessage's properties
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            string smtpHost = "mail.marcman.xyz";
            SmtpClient smtp = new SmtpClient(smtpHost);
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = false;
            //smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential Credentials = new NetworkCredential(fromEmail, "Tasia360#");
            smtp.Credentials = Credentials;

            //(4) Send the MailMessage
            smtp.Send(mail);
        }

    }

}
