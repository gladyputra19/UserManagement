using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagement.Models;
using UserManagementClient.ViewModels;

namespace UserManagementClient.Controllers
{
    public class UsersController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public UsersController()
        {
            client.BaseAddress = new Uri("https://localhost:44336/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODUyNzQwNDEsImlzcyI6ImJvb3RjYW1wcmVzb3VyY2VtYW5hZ2VtZW50IiwiYXVkIjoicmVhZGVycyJ9.YA-M_KN25FWmUuIS1bd9F5ioiRkVY8NCas1Bjma8kjQ");
        }
        // GET: Users
        public ActionResult Index()
        {
            return View(GetRole());
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserVM userVM)
        {
            var myContent = JsonConvert.SerializeObject(userVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var data = client.PostAsync("Login", byteContent).Result;
            if (data.IsSuccessStatusCode)
            {
                var readTask = data.Content.ReadAsStringAsync().Result.Replace("\"", "").Split("...");
                var token = "Bearer " + readTask[0];
                var username = readTask[1];
                var id = readTask[2];
                var role = readTask[3];
                HttpContext.Session.SetString("Token", token);
                return Json(new { data = readTask, data.StatusCode });
            }
            else
            {
                var users = data.Content.ReadAsStringAsync().Result.Replace("\"", "").Split("...");
                if(users[0] == "300")
                {
                    var statusCode = users[0];
                    var locktoken = users[1];
                    return Json(new { statusCode, locktoken });
                }
                else
                {
                    var count = users[0];
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        public ActionResult GenerateResetPasswordToken(UserVM userVM)
        {
            var myContent = JsonConvert.SerializeObject(userVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var data = client.PostAsync("GenerateResetPasswordToken", byteContent).Result;
            if (data.IsSuccessStatusCode)
            {
                var readTask = data.Content.ReadAsAsync<UserVM>().Result;
                //Url.Action("ForgotPassword", "Users", new { Token = readTask.Token }, protocol: Request.Scheme);
                var callbackUrl = "https://localhost:44387/ForgotPassword/"+readTask.Token;
                string message = "Please proceed to this <a href=\"" + callbackUrl + "\">link</a> to reset your password. <br> Best Regards, <br> Admin";

                MailMessage sMail = new MailMessage();
                sMail.To.Add(new MailAddress(userVM.Email));
                sMail.From = new MailAddress("cobamvc@gmail.com");
                sMail.Subject = "[Account Confirmation] " + DateTime.Now.ToString("dd/mm/yyyy/hh:mm:ss");
                sMail.Body = message;
                sMail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("cobamvc@gmail.com", "@Bootcamp33");
                smtp.Send(sMail);
                return Ok(readTask);
            }
            return BadRequest();
        }

        [HttpGet("{Token}")]
        [Route("ForgotPassword/{Token}")]
        public ActionResult ForgotPassword(string Token)
        {
            var user = client.GetAsync("GetToken/" + Token).Result;
            if(user != null)
            {
                var read = user.Content.ReadAsAsync<Employee>().Result;
                if(read.TokenStatus == true)
                {
                    return View();
                }
                return BadRequest();
            }
            return NotFound();
        }
        [HttpPut("{Token}")]
        [Route("Users/ForgotPassword/{Token}")]
        public ActionResult ForgotPassword(string Token, UserVM userVM)
        {
            var user = client.GetAsync("GetToken/" + Token).Result;
            if (user.IsSuccessStatusCode)
            {
                //var userRead = user.Content.ReadAsAsync<UserVM>().Result;
                userVM.Token = Token;
                var myContent = JsonConvert.SerializeObject(userVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var data = client.PutAsync("ForgotPassword/" + userVM.Token, byteContent).Result;
                return Json(new { data = userVM, statusCode = 200 });
            }
            return BadRequest();
        }
        public JsonResult Get()
        {
            IEnumerable<Employee> employees = null;
            var responseTask = client.GetAsync("Get");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employees = readTask.Result;
            }
            else
            {
                employees = Enumerable.Empty<Employee>();
                ModelState.AddModelError(string.Empty, "404 Not Found");
            }
            return Json(new { data = employees });
        }

        [HttpGet]
        public JsonResult Details(string Id)
        {
            var responseTask = client.GetAsync("Get/" + Id).Result;
            var read = responseTask.Content.ReadAsAsync<Employee>().Result;
            return Json(new { data = read });

        }

        public IList<Role> GetRole()
        {
            IList<Role> roles = null;
            var responseTask = client.GetAsync("Roles");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Role>>();
                readTask.Wait();
                roles = readTask.Result;

            }
            ViewBag.Roles = roles;
            return roles;
        }
        
        [HttpPost("{IdUser}")]
        [Route("Users/AssignRole/{IdUser}")]
        public JsonResult AssignRole(string IdUser, RoleVM roleVM)
        {
            var myContent = JsonConvert.SerializeObject(roleVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("AddToRole/"+IdUser, byteContent).Result;
            return Json(new { data = result });
        }

        [HttpGet("{Token}")]
        [Route("LockedAccount/{Token}")]
        public ActionResult LockedAccount(string Token)
        {
            var user = client.GetAsync("GetToken/" + Token).Result;
            if (user.IsSuccessStatusCode && user.Content.ReadAsAsync<UserVM>().Result.LockedStatus == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }
    }
}