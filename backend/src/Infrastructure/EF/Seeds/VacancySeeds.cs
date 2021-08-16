using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.EF.Seeds
{
    public class VacancySeeds
    {
        private Random _random = new Random();
        public  DateTime GetRandomDateTime(int daysOffset = 0)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days - daysOffset;
            return start.AddDays(_random.Next(range));
        }
        private  IList<VacancyStatus> Statuses = new List<VacancyStatus>{
            VacancyStatus.Invited,
            VacancyStatus.Active,
            VacancyStatus.Vacation,
            VacancyStatus.Former
        };
        private  IList<Tier> Tiers = new List<Tier>{
           Tier.Junior,
           Tier.Middle,
           Tier.Senior,
           Tier.TeamLead
        };
        private Vacancy GenerateVacancy(string id){
            return  new Vacancy
            {
                Id = id,
                Title = Titles[_random.Next(Titles.Count)],
                Requirements = "¯\\_(ツ)_/¯",
                Status = Statuses[_random.Next(Statuses.Count)],
                CreationDate = GetRandomDateTime(30),
                DateOfOpening = GetRandomDateTime(-10),
                ModificationDate = GetRandomDateTime(2),
                IsRemote = _random.Next() % 2 == 0,
                IsHot = _random.Next() % 2 == 0,
                SalaryFrom = _random.Next(1200, 1300),
                SalaryTo = _random.Next(1300, 56000),
                CompletionDate = GetRandomDateTime(-29),
                PlannedCompletionDate = GetRandomDateTime(-30),
                TierFrom = Tiers[_random.Next(Tiers.Count)],
                TierTo = Tiers[_random.Next(Tiers.Count)],
                Sources = "¯\\_(ツ)_/¯",
                ProjectId = ProjectIds[_random.Next(ProjectIds.Count)],
                ResponsibleHrId = ResponsibleHrIds[_random.Next(ResponsibleHrIds.Count)],
                CompanyId = "1",
            };
        }
        public IEnumerable<Vacancy> Vacancies (){
            IList<Vacancy> list =  new List<Vacancy>();
            foreach(string id in VacancyIds){
                list.Add(GenerateVacancy(id));
            }
            return list;
        }
        private IList<string> Titles = new List<string>{
            "Devops",
            "QA",
            "Software Enginner",
            "Project Designer",
            "UI/UX Frontend",
            "Developer",
            "Web Developer",
            "Project Manager"
        };
        private  IList<string> ProjectIds = new List<string>{
            "pd45e3b4-cdf6-4f67-99de-795780c70b8f",
            "p9e10160-0522-4c2f-bfcf-a07e9faf0c04",
            "p8b0e8ca-54ff-4186-8cc0-5f71e1ec1d3c",
            "p0679037-9b5e-45df-b24d-edc5bbbaaec4",
            "paa3320f-866a-4b02-9076-5e8d12796710",
        };
        private  IList<string> ResponsibleHrIds = new List<string>{
            "057c23ff-58b1-4531-8012-0b5c1f949ee1",
            "fb055f22-c5d1-4611-8e49-32a46edf58b2",
            "ac78dabf-929c-4fa5-9197-7d14e18b40ab",
            "f8afcbaa-54bd-4103-b3f0-0dd17a5226ca",
            "8be08dba-5dac-408a-ab6e-8d162af74024",
        };
        public  IList<string> VacancyIds = new List<string>{
            "c17322f5-1d00-42ce-b1d8-b2cad9a72f32",

            "d701f2d8-11ca-49c4-85aa-c4593cace3a9",

            "db1646f4-1c00-4d72-832f-9fd1093ae6dc",

            "1d4128f9-3d3f-4b19-91f3-f1766e42576b",

            "a43a0590-1aad-4564-94d0-a9e5e6e51c12",

            "25faa343-1b96-4679-9ca9-dc9af08f891b",

            "ffbd3588-1666-40ea-980a-373c9824417e",

            "154065a4-1f7d-4706-b9fd-7a97646870d0",

            "c0444497-1e0f-4b93-83ab-f5522c4391d7",

            "f2531da3-18da-4e64-aab9-c4ec10957dcc",

            "0c1bde8f-1622-44b3-86d0-67ec69665134",

            "d12218ee-3688-42d1-8874-fd80a1634340",

            "34366ad0-15ed-4775-b0cf-826f84b1c095",

            "27730877-1d1e-46ee-a8cb-9b019be065fe",

            "13f41ed3-108c-4100-b030-197773798d44",

            "28c49bd7-17da-415b-88bf-5844843d5fac",

            "6532e19d-1bc1-482d-9413-cbf7b5d547c4",

            "90a4b78a-1bb4-4321-891d-8f36b67f2c36",

            "32aa24b6-1f28-4be3-9cf9-b09e044f47fe",

            "e3f41ed3-108c-4100-b030-197773798d44",

            "e8c49bd7-17da-415b-88bf-5844843d5fac",

            "e532e19d-1bc1-482d-9413-cbf7b5d547c4",

            "e0a4b78a-1bb4-4321-891d-8f36b67f2c36",

            "e2aa24b6-1f28-4be3-9cf9-b09e044f47fe",
        };
    }
}