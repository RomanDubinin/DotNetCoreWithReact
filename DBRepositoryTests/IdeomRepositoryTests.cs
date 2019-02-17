using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DBRepository;
using FluentAssertions;
using Models;
using Npgsql;
using NUnit.Framework;

namespace Tests
{
    public class IdeomRepositoryTests : TestFixture
    {
        private IdeomRepository ideomRepository { get; set; }

        [SetUp]
        public async Task Setup()
        {
            base.Setup();
            ideomRepository = new IdeomRepository(ConnectionString);
        }
        [Test]
        public async Task Test1()
        {
            var ideom = new Ideom
            {
                Id = Guid.NewGuid(),
                EnglishText = "eng",
                RussianText = "rus"
            };
            await ideomRepository.SaveAsync(ideom, CancellationToken.None).ConfigureAwait(false);
            var ideoms = await ideomRepository.SelectAsync().ConfigureAwait(false);
            ideoms.Count.Should().BeLessOrEqualTo(1);
            ideoms[0].Should().BeEquivalentTo(ideom);
        }
    }
}