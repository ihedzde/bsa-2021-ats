﻿using Application.Common.Exceptions;
using AutoMapper;
using Dapper;
using Domain.Entities;
using Domain.Interfaces.Abstractions;
using Domain.Interfaces.Read;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Read
{
    public class VacancyTableRepository : ReadRepository<VacancyTable>, IReadRepository<VacancyTable>
    {
        private readonly IMapper _mapper;
        public VacancyTableRepository(IConnectionFactory connectionFactory, IMapper mapper) : base("Users", connectionFactory) 
        { 
            _mapper = mapper;
        }


        public async Task<IEnumerable<VacancyTable>> GetUsersByCompanyIdAsync(string companyId)
        {
            var connection = _connectionFactory.GetSqlConnection();
            await connection.OpenAsync();
            StringBuilder vacancySql = new StringBuilder();
            vacancySql.Append("SELECT * FROM Vacancies as VC");
            vacancySql.Append(" LEFT JOIN Users AS US ON US.Id = VC.ResponsibleHrId");
            vacancySql.Append(" WHERE VC.CompanyId = @CompanyId");
            StringBuilder candidateCountSql = new StringBuilder();
            candidateCountSql.Append("SELECT COUNT(*) FROM VacancyCandidates");
            candidateCountSql.Append(" WHERE EXISTS(SELECT * FROM Stages WHERE Stages.VacancyId = @vacancyId");
            candidateCountSql.Append(" AND EXISTS(SELECT * FROM CandidateToStages");
            candidateCountSql.Append(" WHERE CandidateToStages.CandidateId = VacancyCandidates.Id ");
            candidateCountSql.Append(" AND CandidateToStages.StageId = Stages.Id AND CandidateToStages.DateRemoved IS NULL))");
            IEnumerable<VacancyTable> vacancyTables = await connection
                .QueryAsync<VacancyTable>(vacancySql.ToString(), param: new {
                    CompanyId = companyId
                });
            foreach (var vacancyTable in vacancyTables){
                vacancyTable.CandidatesAmount = (await connection.QueryAsync<int>(candidateCountSql.ToString(), param: new {
                    vacancyId = vacancyTable.Id
                })).First();
                //vacancyTable.Department = (await _projectRepo.GetAsync(dto.ProjectId)).TeamInfo;
            }
            // 
            await connection.CloseAsync();
            return vacancyTables;
        }

        public async Task LoadRolesAsync(User user)
        {
            var connection = _connectionFactory.GetSqlConnection();
            await connection.OpenAsync();
            var sql = new StringBuilder();
            sql.Append($"SELECT * FROM UserToRoles AS UR");
            sql.Append(" INNER JOIN Roles AS R ON UR.RoleId = R.Id");
            sql.Append(" WHERE UR.UserId = @userId;");

            var userRoles = await connection.QueryAsync<UserToRole, Role, UserToRole>(sql.ToString(),
            (ur, r) =>
            {
                ur.Role = r;
                return ur;
            },
            new { userId = user.Id });
            await connection.CloseAsync();
            user.UserRoles = userRoles as ICollection<UserToRole>;
        }
    }
}
