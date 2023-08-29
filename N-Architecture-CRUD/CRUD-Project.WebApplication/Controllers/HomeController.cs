using CRUD_Project.BLL.Services;
using CRUD_Project.Models;
using CRUD_Project.WebApplication.Models;
using CRUD_Project.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace CRUD_Project.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactServices _contactServices;

        public HomeController(IContactServices contactServ)
        {
            _contactServices = contactServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IQueryable<Contact> queryContactSQL = await _contactServices.GetAll();

            List<VMContact> list = queryContactSQL.Select(c => new VMContact { ContactId = c.ContactId, Name = c.Name, Phone = c.Phone, BirthDate = c.BirthDate.Value.ToString("dd/mm/yyyy") }).ToList();
            return StatusCode(StatusCodes.Status200OK, list);
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] VMContact model)
        {
            Contact NewModel = new Contact()
            {
                Name = model.Name,
                Phone = model.Phone,
                BirthDate = DateTime.ParseExact(model.BirthDate, "dd/mm/yyyy", CultureInfo.CreateSpecificCulture("Argentina"))

            };
            bool response = await _contactServices.Insert(NewModel);
            return StatusCode(StatusCodes.Status200OK, new { value = response });
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VMContact model)
        {
            Contact NewModel = new Contact()
            {
                ContactId = model.ContactId,
                Name = model.Name,
                Phone = model.Phone,
                BirthDate = DateTime.ParseExact(model.BirthDate, "dd/mm/yyyy", CultureInfo.CreateSpecificCulture("Argentina"))

            };
            bool response = await _contactServices.Update(NewModel);
            return StatusCode(StatusCodes.Status200OK, new { value = response });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            bool response = await _contactServices.Delete(Id);
            return StatusCode(StatusCodes.Status200OK, new { value = response });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}