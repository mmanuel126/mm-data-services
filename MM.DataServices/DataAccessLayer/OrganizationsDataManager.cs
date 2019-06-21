using System.Collections.Generic;
using System.Linq;
using MM.DataServices.Models;

namespace MM.DataServices.Organizations
{
    /// <summary>
    /// describes the functionalities to manage the business and data requirements for Site Common usage needs
    /// </summary>
    public class OrganizationsDataManager
    {

        /// <summary>
        /// Get Recent news 
        /// </summary>
        /// <returns></returns>
        public List<string> GetCompanySectors()
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                {
                    var q = (from c in context.TbCompanies orderby c.Sector ascending select c.Sector).Distinct().ToList();
                    return q;
                }
            }
        }

        /// <summary>
        /// Get states
        /// </summary>
        /// <returns></returns>
        public List<string> GetIndustries(string sector)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var i = (from s in context.TbCompanies where s.Sector == sector orderby s.Industry ascending select s.Industry).Distinct().ToList();
                return i;
            }
        }

        public List<string> GetIndustries()
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {

                var i = (from s in context.TbCompanies orderby s.Industry ascending select s.Industry).Distinct().ToList();
                return i;
            }
        }

        public List<CompanyBySectorIndustryModel> GetInterests()
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var i = (from s in context.TbInterests orderby s.InterestDesc  ascending
                         select new CompanyBySectorIndustryModel()
                         {
                             id = s.InterestId.ToString(),
                             name = s.InterestDesc 
                         }

                         ).Distinct().ToList();

                return i;
            }
        }


        public List<SchoolByStateModel> GetSchoolsByState(string state, string institutionType) {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                List<SchoolByStateModel> sM = new List< SchoolByStateModel>();
                if (institutionType == "1") //public
                {
                    sM = (from s in context.TbPublicSchools where s.State==state orderby s.SchoolName ascending 

                             select new SchoolByStateModel() {
                                schoolId = s.SchoolId,
                                schoolName = s.SchoolName
                             }
                            ).Distinct().ToList();
                }
                else if (institutionType == "2") //private
                {
                    sM = (from s in context.TbPrivateSchools where s.State==state
                          orderby s.SchoolName ascending

                          select new SchoolByStateModel()
                          {
                              schoolId = s.Lgid.ToString(),
                              schoolName = s.SchoolName
                          }
                            ).Distinct().ToList();
                }
                else if (institutionType == "3") //colleges
                {
                    sM = (from s in context.TbColleges where s.State == state
                          orderby s.Name ascending

                          select new SchoolByStateModel()
                          {
                              schoolId = s.SchoolId.ToString(),
                              schoolName = s.Name
                          }
                            ).Distinct().ToList();
                }
                return sM;
            }
        }

        public List<CompanyBySectorIndustryModel> GetCompanies(string sector, string industry)
        {
            using (DB_9B0E5C_linkedglobeContext context = new DB_9B0E5C_linkedglobeContext())
            {
                var i = (from s in context.TbCompanies
                         where s.Sector == sector && s.Industry == industry
                         orderby s.Name ascending

                         select new CompanyBySectorIndustryModel()
                         {
                             id = s.Id.ToString(),
                             name = s.Name
                         }).Distinct().ToList();
                return i;
            }
        }
    }

}
