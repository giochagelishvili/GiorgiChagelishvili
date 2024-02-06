using CompanyManagement.Application;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService CompanyService { get; set; }

        public CompanyController()
        {
            CompanyService = new CompanyService();
        }

        [HttpGet]
        public IEnumerable<Company> Get() => CompanyService.GetCompanies();

        [HttpGet("{id}")]
        public Company Get(int id) => CompanyService.GetCompanyById(id);

        [HttpDelete("{id}")]
        public bool Delete(int id) => CompanyService.Delete(id);

        [HttpPost]
        public bool AddCompany() => CompanyService.AddCompany(); 
    }
}
