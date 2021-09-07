﻿using Application.Applicants.Dtos;
using Application.MailTemplates.Dtos;
using Application.Projects.Dtos;
using Application.Vacancies.Dtos;
using Domain.Entities;
using Domain.Interfaces.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.MailTemplates.Queries
{
    public class GetMailTemplateWithReplacedPlaceholdersQuery : IRequest<MailTemplate>
    {
        public string MailTempalteId;
        public Vacancy Vacancy;
        public Applicant Applicant;
        public GetMailTemplateWithReplacedPlaceholdersQuery(
            string mailTempalteId,
            Vacancy vacancy,
            Applicant applicant) 
        {
            MailTempalteId = mailTempalteId;
            Vacancy = vacancy;
            Applicant = applicant;
        }
    }

    public class GetMailTemplateWithReplacedPlaceholdersQueryHandler : IRequestHandler<GetMailTemplateWithReplacedPlaceholdersQuery, MailTemplate>
    {

        protected readonly IReadRepository<MailTemplate> _readRepository;
        public GetMailTemplateWithReplacedPlaceholdersQueryHandler(IReadRepository<MailTemplate> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<MailTemplate> Handle(GetMailTemplateWithReplacedPlaceholdersQuery query, CancellationToken cancellationToken)
        {
            var placeholders = new Dictionary<string, string>()
            {
                {"{vacancy.title}", query.Vacancy.Title},
                {"{vacancy.description}", query.Vacancy.Description},
                {"{vacancy.requirements}", query.Vacancy.Requirements},
                {"{vacancy.salaryFrom}", query.Vacancy.SalaryFrom.ToString()},
                {"{vacancy.salaryTo}", query.Vacancy.SalaryTo.ToString()},
                {"{project.title}",  query.Vacancy.Project.Name},
                {"{project.logo}",  "<a href=\""+query.Vacancy.Project.Logo+"\"></a>"},
                {"{project.description }",  query.Vacancy.Project.Description},
                {"{project.teamInfo}",  query.Vacancy.Project.TeamInfo},
                {"{project.websiteLink}", "<a href=\""+query.Vacancy.Project.WebsiteLink+"\"></a>"},
                {"{applicant.firstName}", query.Applicant.FirstName},
                {"{applicant.lastName}", query.Applicant.LastName},
                {"{applicant.birthDate }", query.Applicant.BirthDate.ToString()},
                {"{applicant.phone}", query.Applicant.Phone},
                {"{applicant.linkedInUrl}", "<a href=\""+query.Applicant.LinkedInUrl+"\"></a>"},
                {"{applicant.experience}", query.Applicant.Experience.ToString()+" years"},
                {"{applicant.experienceDescription}", query.Applicant.ExperienceDescription},
                {"{applicant.skills}", query.Applicant.Skills},
            };

            var mailTemplate = await _readRepository.GetAsync(query.MailTempalteId);

            foreach (var placeholder in placeholders)
            {
                mailTemplate.Html = mailTemplate.Html.Replace(placeholder.Key, placeholder.Value);
            }

            return mailTemplate;
        }
    }
}
