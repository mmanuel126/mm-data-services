using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MM.DataServices.Models;
using MM.DataServices.Organizations;

namespace MM.DataServices.Controllers
{
    [Route("services/[controller]/[action]")]
    public class OrganizationsController : Controller
    {
        private readonly OrganizationsDataManager orgMgr;

        public OrganizationsController()
        {
            orgMgr = new  OrganizationsDataManager();
        }

        /// <summary>
        /// Gets the list of company sectors.
        /// </summary>
        /// <returns>The company sectors.</returns>
        [HttpGet]
        public List<string> GetCompanySectors()
        {
            return orgMgr.GetCompanySectors();
        }

        /// <summary>
        /// Gets lis of the industries for a sector.
        /// </summary>
        /// <returns>The industries.</returns>
        /// <param name="sector">Sector.</param>
        [HttpGet]
        public List<string> GetIndustries([FromQuery] string sector)
        {
            return orgMgr.GetIndustries(sector);
        }

        /// <summary>
        /// Gets school by state.
        /// </summary>
        /// <returns>The school by state.</returns>
        /// <param name="state">State.</param>
        /// <param name="institutionType">Institution type.</param>
        [HttpGet]
        public List<SchoolByStateModel> GetSchoolByState([FromQuery] string state, [FromQuery] string institutionType)
        {
            return orgMgr.GetSchoolsByState(state, institutionType);
        }

        /// <summary>
        /// Gets list of companies base on sector and industry.
        /// </summary>
        /// <returns>The companies.</returns>
        /// <param name="sector">Sector.</param>
        /// <param name="industry">Industry.</param>
        [HttpGet]
        public List<CompanyBySectorIndustryModel> GetCompanies([FromQuery] string sector, [FromQuery] string industry)
        {
            return orgMgr.GetCompanies(sector, industry);
        }

        [HttpGet]
        public List<CompanyBySectorIndustryModel> GetInterests()
        {
            return orgMgr.GetInterests();
        }

    }
}
