﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Repositories.Abstractions;

namespace Infrastructure.Repositories.Read
{
    public class VacancyReadRepository : ReadRepository<Vacancy>
    {
        public VacancyReadRepository(IConnectionFactory connectionFactory) : base("Vacancies", connectionFactory) { }

    }
}
