using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotaApp.Services.DataServices.Tests
{
    public class ItemServiceTests
    {
        private IItemService itemService;

        private List<Item> GetDummyItems()
        {
            return new List<Item>
            {
                new Item { Id = 1, Cost = 1000, Image = "Image one", Lore = "First lore", Name = "Item one" },
                new Item { Id = 2, Cost = 4000, Image = "Image two", Lore = "Second lore", Name = "Item two" },
                new Item { Id = 3, Cost = 1234, Image = "Image three", Lore = "Third lore", Name = "Item three" }
            };
        }

        private void SeedItems(DotaAppContext context)
        {
            context.Items.AddRange(this.GetDummyItems());
            context.SaveChanges();
        }

        [Fact]
        public void GetAll_WithDummyItems_ShoudlReturnCorrectResults()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedItems(context);

            this.itemService = new ItemService(context);

            var expectedItems = context.Items.ToList();
            var actualItems = this.itemService.GetAll();

            Assert.Equal(expectedItems.Count, actualItems.Count);
        }

        [Fact]
        public void GetById_WithDummyItems_ShouldThrowExceptionWhenItemNotFound()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedItems(context);

            this.itemService = new ItemService(context);

            int itemId = 123;
            DotaException exception = Assert.Throws<DotaException>(() => this.itemService.GetById(itemId));

            Assert.Equal(Constants.InvalidOperation, exception.Message);
        }

        [Fact]
        public void GetById_WithDummyItems_ShouldReturnCorrectResults()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedItems(context);

            this.itemService = new ItemService(context);

            int itemId = 2;

            var expectedItem = context.Items
                .First(i => i.Id == itemId);

            var actualItem = this.itemService.GetById(itemId);

            Assert.Equal(expectedItem.Id, actualItem.Id);
            Assert.Equal(expectedItem.Name, actualItem.Name);
        }
    }
}
