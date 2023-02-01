using Microsoft.AspNetCore.Mvc;
using Ornek_Web_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ornek_Web_App.Controllers
{
    //Burada contributeler ile bu controller'ın api olduğu belirtilir.
    [ApiController]
    [Route("api/[controller]")]
    //API Controller ControllerBase'den referans alır.
    public class HomeController : ControllerBase
    {
        //[HttpGet]
        //public string Get()
        //{
        //    return "Home";
        //}

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "Home" + id;
        //}

        private List<User> users = Fake.FakeData.GetUsers(100);

        [HttpGet] //Tüm verileri çekme
        public List<User> GetUsers() 
        { 
            return users; 
        }

        [HttpGet("{id}")] //ID ye göre veri çekme
        public User GetUsers(int id)
        {
            return users.FirstOrDefault(x=>x.Id == id);
        }

        //Frombody kullanıcının hangi şekilde ekleneceği yazıyor.
        [HttpPost] //Ekleme
        public User Post([FromBody]User user)
        {
            users.Add(user);
            return user;
        }

        [HttpPut] //Update
        public User Put([FromBody]User user)
        {
            var editUser = users.FirstOrDefault(x => x.Id == user.Id);
            editUser.FirstName= user.FirstName;
            editUser.LastName= user.LastName;
            editUser.Address= user.Address;
            return user;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedUser = users.FirstOrDefault(x => x.Id == id);
            users.Remove(deletedUser);
        }
    }
}
