﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagementClient.Controllers
{
    
    public class RolesController : Controller
    {
        
        readonly HttpClient client = new HttpClient();
        public RolesController()
        {
              client.BaseAddress = new Uri("https://localhost:44336/");
        }

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if(role == "Admin")
            {
                return View();
            }
            return RedirectToAction("Login", "Users");
            
        }  

        public JsonResult Get()
        {
            IEnumerable<Role> roles = null;
            var responseTask = client.GetAsync("Roles");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Role>>();
                readTask.Wait();
                roles = readTask.Result;
            }
            else
            {
                roles = Enumerable.Empty<Role>();
                ModelState.AddModelError(string.Empty, "404 Not Found");
            }
            ViewBag.Roles = roles;
            return Json(new { data = roles });
        }
        public JsonResult Post(Role roles)
        {
            var myContent = JsonConvert.SerializeObject(roles);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("Roles", byteContent).Result;
            return Json(new { data = result });
        }
        public JsonResult Details(string Id)
        {
            var responseTask = client.GetAsync("Roles/" + Id).Result;
            var read = responseTask.Content.ReadAsAsync<Role>().Result;
            return Json(new { data = read });
        }
        public JsonResult Delete(string Id)
        {
            var result = client.DeleteAsync("Roles/" + Id).Result;
            return Json(new { data = result });
        }
        public JsonResult Edit(string Id, RoleVM roleVM)
        {
            var myContent = JsonConvert.SerializeObject(roleVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PutAsync("Roles/" + Id, byteContent).Result;
            return Json(new { data = result });
        }
    }
}