using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using opg_201910_interview.Data;
using opg_201910_interview.Models;

namespace opg_201910_interview.Controllers
{
    public class ClientController : Controller
    {
        private readonly IConfiguration _config;
        public ClientController(IConfiguration config)
        {
            this._config = config;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClientData(int id)
        {
            string clientId = _config.GetSection($"ClientSettings:ClientId{id}").Value;
            string folder = _config.GetSection($"ClientSettings:FileDirectoryPath{id}").Value;
            string sortOrder = _config.GetSection($"ClientSettings:SortOrder{id}").Value;

            var data = ClientData.GetClientDataFromDirectory(clientId, folder, sortOrder);

            List<ClientViewModel> json = JsonConvert.DeserializeObject<List<ClientViewModel>>(data);

            return new JsonResult(json);

        }

       
    }
}