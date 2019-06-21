using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Commons;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace MM.DataServices.Controllers
{

    [Route("services/[controller]/[action]")]

    public class CommonController : Controller
    {
        CommonDataManager comMgr;
        readonly ILogger<CommonController> _log;

        public CommonController(ILogger<CommonController> log)
        {
            comMgr = new CommonDataManager();
            _log = log;
        }


        /// <summary>
        /// Gets the public school cities list by a given state.
        /// </summary>
        /// <returns>The public school cities.</returns>
        /// <param name="state">The state you want to find all cities.</param>
        [HttpGet]
        public List<string> GetPublicSchoolCities([FromQuery]string state)
        {
            return comMgr.GetPulicSchoolCities(state);
        }

        /// <summary>
        /// Gets the list of recent news.
        /// </summary>
        /// <returns>The recent news.</returns>
        [HttpGet]
        public List<TbRecentNews> GetRecentNews()
        {
            return comMgr.GetRecentNews ();
        }

        /// <summary>
        /// Gets the list of states.
        /// </summary>
        /// <returns>The states.</returns>
        [HttpGet]
        [Authorize]
        public List<TbStates> GetStates()
        {
            return comMgr.GetStates ();
        }

        /// <summary>
        /// Encrypts a gvien string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="str">The string to encrypt.</param>
        [HttpGet]
        public string EncryptString(string str)
        {
            string mykey = "r0b1nr0y";
            return EncryptStrings.Encrypt(str, mykey);
        }

        /// <summary>
        /// Decrypts an encrypted string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="str">The string to decrypt.</param>
        [HttpGet]
        public string DecryptString(string str)
        {
            string mykey = "r0b1nr0y";
            return EncryptStrings.Decrypt(str, mykey) ;
        }

        /// <summary>
        /// Logs the specified obj log model to file including error msg and stack trace.
        /// </summary>
        /// <param name="obj">the object model to log.</param>
        [HttpPost]
        public void Logs([FromBody] LogModel obj)
        {
            string msg = obj.message;
            string stack = "";
            if (obj.additional != null)
            {
                stack = obj.additional[0];
            }
            string level = obj.level.ToString();
            string datetime = obj.timestamp.ToString();
            string fileName = obj.fileName;
            string fileNumber = obj.fileNumber.ToString();
            string logText =  LogText(msg, stack, level, datetime, fileName, fileNumber);
            _log.LogError(logText);
        }

        /// <summary>
        /// Logs the text.
        /// </summary>
        /// <returns>The text.</returns>
        /// <param name="msg">Message.</param>
        /// <param name="stack">Stack.</param>
        /// <param name="level">Level.</param>
        /// <param name="dateTime">Date time.</param>
        /// <param name="fileName">File name.</param>
        /// <param name="fileNumber">File number.</param>
        private string LogText(string msg, string stack, string level, string dateTime, string fileName, string fileNumber)
        {
            string txt = "";
            txt = txt + "File Name: ";
            txt = txt + fileName + "; File Number: " + fileNumber + "\n\n";
            txt = txt + "Message: " + msg + "\n\n";
            txt = txt + "Stack Trace: " + stack + "\n\n";
            return txt;
        }
    }

    public class LogModel
    {
        public string message { get; set; }
        public string[] additional { get; set; }
        public int level { get; set; }
        public DateTime timestamp { get; set; }
        public string fileName { get; set; }
        public Int32 fileNumber { get; set; }
    }
}
