using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Elastic.Seeding
{
    public static class ElasticTagsSeeds
    {
        private static IEnumerable<Tag> GetRandomTags()
        {
            Random _random = new Random();
            IList<Tag> tags = new List<Tag>();
            foreach(var tag in Tags)
            {
                if (_random.Next() % 2 == 0)
                    tags.Add(tag);
            }
            return tags;
        }
        
        #region Tags
        private readonly static IList<Tag> Tags = new List<Tag>
        {
            new Tag
            {
                Id = "f926cc1a-d5e5-4753-b1ff-6af2baacfe13",
                TagName = "Web Developer",
            },
            new Tag
            {
                Id = "c53fd98d-6324-43f6-a310-e8099e428e31",
                TagName = "Fullstack"
            },
            new Tag
            {
                Id = "f926cc1a-d5e5-4753-b1ff-6af2baacf213",
                TagName = "Angular/Dotnet"
            },
            new Tag
            {
                Id = "b62e6e4f-9dc2-4418-80d0-b787279a676e",
                TagName = "UI/UX"
            },
            new Tag
            {
                Id = "528d29f8-c790-4a09-b115-1a992c03a225",
                TagName = "Devops"
            },
            new Tag
            {
                Id = "4e20103e-09a4-4fb2-adcc-4b3793725c1d",
                TagName = "QA"
            },
            new Tag
            {
                Id = "80714c7c-8b25-470d-983e-2f43576483c8",
                TagName = "Product manager"
            }
        };
        #endregion

        public static IEnumerable<ElasticEntity> GetSeed()
        {
            return new List<ElasticEntity>
            {
                new ElasticEntity
                {
                    Id = "732f84f8-0625-5098-adbf-4aabcabb5b0c",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity
                {
                    Id = "bffcc629-77ef-5304-9d4a-d9b44b5739d6",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity
                {
                    Id = "4e5d00dc-f1ab-5a74-9e6f-4edae70fca02",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },

                new ElasticEntity{
                    Id = "3e84df9f-f6c3-50d8-8787-d0e2a94af2b6",
                    Tags = new List<Tag>{
                        Tags[1]
                    },
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity
                {
                    Id = "8bf07b5b-af46-58be-b536-58eeca69f661",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "8be38dd0-8767-54c5-8f78-aa33e11997e9",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                //
                new ElasticEntity{
                    Id = "c8698455-0a05-503f-a6a6-b8557093a67e",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "32e88c57-7a44-51fa-abeb-b9253dacc14f",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "6a9e4cf9-1a02-50dd-9d32-d82fa566c5a2",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "5f08c0b7-e605-5672-acce-328b8d660989",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "342f8205-6c3f-5b33-8148-bf6fa9ebda64",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "8f906dbd-f7dd-54fc-b59f-17d7b1a153dc",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "eec0eb4b-1999-5b4a-8dad-5f41c8b3e83c",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "388b41ec-993a-5196-9dee-fe831257dda7",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "d6f8a112-c9bb-5e0e-a960-53a9da2495ab",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "eccf7842-db64-5e70-b010-67cb3806f2e4",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "aa2d6886-ef45-5d0e-a2fa-4c839f5f6e99",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "98954928-1256-557a-b79f-7058641f0b4b",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "74c1dac0-d4bb-51d9-a2e2-647952974ad6",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },
                new ElasticEntity{
                    Id = "91f8c039-6798-5692-9bb9-68bc16bc4a82",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.ApplicantTags
                },

                //
                new ElasticEntity
                {
                    Id = "c17322f5-1d00-42ce-b1d8-b2cad9a72f32",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.VacancyTags
                },
                new ElasticEntity
                {
                    Id = "d701f2d8-11ca-49c4-85aa-c4593cace3a9",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.VacancyTags
                },
                new ElasticEntity
                {
                    Id = "db1646f4-1c00-4d72-832f-9fd1093ae6dc",
                    Tags = GetRandomTags(),
                    ElasticType = ElasticType.VacancyTags
                },
            };
        }
    }
}