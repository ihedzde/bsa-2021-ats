using System;
using Domain.Common;

namespace Domain.Entities
{
    public class VacancyCandidate : Entity
    {
        public DateTime FirstContactDate { get; set; }
        public DateTime SecondContactDate { get; set; }
        public DateTime ThirdContactDate { get; set; }
        public int SalaryExpectation { get; set; }
        public string ContactedBy { get; set; }
        public string Comments { get; set; }
        public string Experience { get; set; }
        public string StageId { get; set; }

        public Applicant Applicant { get; private set; }
        public Stage Stage { get; private set; }
    }
}