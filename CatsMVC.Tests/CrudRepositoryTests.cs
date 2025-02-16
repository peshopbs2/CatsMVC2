using CatsMVC.Data;
using CatsMVC.Data.Entities;
using CatsMVC.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

namespace CatsMVC.Tests
{
    [TestFixture]
    public class CrudRepositoryTests
    {
        private ApplicationDbContext _context;
        private CrudRepository<Cat> _catRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb") // Use an in-memory database
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted(); // Reset database before each test
            _context.Database.EnsureCreated();

            _context.Cat.AddRange(new List<Cat>
            {
                new Cat { Id = 1, Name = "Whiskers", Breed = "Test", ImageUrl = "https://google.com/" },
                new Cat { Id = 2, Name = "Mittens", Breed = "Test", ImageUrl = "https://google.com/" }
            });
            _context.SaveChanges();

            _catRepository = new CrudRepository<Cat>(_context);
        }

        [Test]
        public async Task CreateAsync_ShouldAddEntity()
        {
            var newCat = new Cat { Id = 3, Name = "Fluffy", Breed = "Test", ImageUrl = "https://google.com/" };
            await _catRepository.CreateAsync(newCat);

            var result = await _context.Cat.FindAsync(3);
            Assert.IsNotNull(result);
            Assert.AreEqual("Fluffy", result.Name);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            var cats = await _catRepository.GetAllAsync();
            Assert.AreEqual(2, cats.Count);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnCorrectEntity()
        {
            var cat = await _catRepository.GetByIdAsync(1);
            Assert.IsNotNull(cat);
            Assert.AreEqual("Whiskers", cat.Name);
        }

        [Test]
        public async Task DeleteByIdAsync_ShouldRemoveEntity_WhenEntityExists()
        {
            await _catRepository.DeleteByIdAsync(1);

            var cat = await _context.Cat.FindAsync(1);
            Assert.IsNull(cat);
        }

        [Test]
        public void DeleteByIdAsync_ShouldThrowException_WhenEntityDoesNotExist()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _catRepository.DeleteByIdAsync(99));
        }

        [Test]
        public async Task UpdateAsync_ShouldModifyEntity()
        {
            var existingCat = await _catRepository.GetByIdAsync(1);
            existingCat.Name = "UpdatedName";
            await _catRepository.UpdateAsync(existingCat);

            var updatedCat = await _context.Cat.FindAsync(1);
            Assert.AreEqual("UpdatedName", updatedCat.Name);
        }

        [Test]
        public void GetByFilter_ShouldReturnFilteredEntities()
        {
            var filteredCats = _catRepository.GetByFilter(c => c.Name == "Whiskers");
            Assert.AreEqual(1, filteredCats.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

    }
}