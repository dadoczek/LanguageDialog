using System;
using System.Collections.Generic;
using System.Linq;
using AplikacjaLingwistyczna.Tests.Helper;
using Model.Models;
using Repo.AbstractRepo;
using Repo.Repositories;
using Xunit;

namespace AplikacjaLingwistyczna.Tests.EntityTest
{
    public class RepositoryTest : EntityBaseTest, IDisposable
    {
        private readonly IRepository _repository;

        public RepositoryTest()
        {
            _repository = new Repository(Context);
        }

        [Fact]
        public void RepositoryTest_Add_One_Object()
        {
            var name = Guid.NewGuid().ToString();
            var language = new Language
            {
                Name = name,
            };
            _repository.Add(language);

            var result = Context.Language.FirstOrDefault(d => d.Name == name);

            Assert.NotNull(result);
            Assert.True(result.Name == name);
        }

        [Fact]
        public void RepositoryTest_Add_Many_Object()
        {
            var name = Guid.NewGuid().ToString();
            var name2 = Guid.NewGuid().ToString();
            var language = new List<Language>
            {
                new Language
                {
                   Name = name,
                },

                new Language
                {
                    Name = name2,
                }
                
            };

            _repository.Add(language.ToArray());

            Assert.NotNull(Context.Language.FirstOrDefault(d => d.Name == name));
            Assert.NotNull(Context.Language.FirstOrDefault(d => d.Name == name2));
            var count = Context.Language.Count();
            Assert.True(count == 2);
        }

        public void Dispose()
        {
            Context.Language.RemoveRange(Context.Language);
            Context.SaveChanges();
        }
    }
}
