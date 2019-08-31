using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using DotaApp.Services.Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotaApp.Services.DataServices.Tests
{
    public class CommentServiceTests
    {
        private ICommentService commentService;

        private List<Comment> GetDummyComments()
        {
            return new List<Comment>
            {
                new Comment { Id = 1, CommentMessage = "Test message", Username = "Pesho", CreatedOn = DateTime.UtcNow.ToLocalTime(), ItemId = 2, IsPending = false, IsApproved = true },
                new Comment { Id = 2, CommentMessage = "Another message message", Username = "Gosho", CreatedOn = DateTime.UtcNow.ToLocalTime(), ItemId = 2, IsPending = true, IsApproved = false },
                new Comment { Id = 3, CommentMessage = "Something message", Username = "Stamat", CreatedOn = DateTime.UtcNow.ToLocalTime(), ItemId = 2, IsPending = false, IsApproved = true },
                new Comment { Id = 4, CommentMessage = "Something message 234", Username = "Stamat", CreatedOn = DateTime.UtcNow.ToLocalTime(), ItemId = 3, IsPending = false, IsApproved = true }
            };
        }

        private List<Item> GetDummyItems()
        {
            return new List<Item>
            {
                new Item { Id = 1, Cost = 1000, Image = "Image one", Lore = "First lore", Name = "Item one" },
                new Item {
                    Id = 2, Cost = 4000, Image = "Image two", Lore = "Second lore", Name = "Item two", Comments = new List<Comment>
                    {
                        new Comment { CommentMessage = "Test message", Username = "Pesho", CreatedOn = DateTime.UtcNow.ToLocalTime(), IsPending = false, IsApproved = true },
                        new Comment { CommentMessage = "Another message message", Username = "Gosho", CreatedOn = DateTime.UtcNow.ToLocalTime(), IsPending = true, IsApproved = false },
                        new Comment { CommentMessage = "Something message", Username = "Stamat", CreatedOn = DateTime.UtcNow.ToLocalTime(), IsPending = false, IsApproved = true }
                    }
                },
                new Item { Id = 3, Cost = 1234, Image = "Image three", Lore = "Third lore", Name = "Item three" }
            };
        }

        private void SeedComments(DotaAppContext context)
        {
            context.Comments.AddRange(this.GetDummyComments());
            context.SaveChanges();
        }

        private void SeedItems(DotaAppContext context)
        {
            context.Items.AddRange(this.GetDummyItems());
            context.SaveChanges();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(233)]
        public void All_WithDummyComments_ShouldReturnCorrectResultsWhen(int itemId)
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.commentService = new CommentService(context);

            var expectedComments = context.Comments
                .Where(c => c.ItemId == itemId && !c.IsPending && c.IsApproved)
                .ToList();

            var actualComments = this.commentService.All(itemId);

            Assert.Equal(expectedComments.Count, actualComments.Count);
        }

        [Fact]
        public void AddComment_WithDummy_ShouldThrowExceptionWhenItemNotFound()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.commentService = new CommentService(context);

            var addCommentDto = new AddCommentDto
            {
                ItemId = 777,
                Comment = "New comment from test",
                Username = "Ginka"
            };

            DotaException exception = Assert.Throws<DotaException>(() => this.commentService.AddComment(addCommentDto));

            Assert.Equal(Constants.InvalidOperation, exception.Message);
        }

        [Fact]
        public void AddComment_WithDummy_ShouldAddComment()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedItems(context);

            this.commentService = new CommentService(context);

            var addCommentDto = new AddCommentDto
            {
                ItemId = 2,
                Comment = "New comment from test",
                Username = "Ginka"
            };

            int expectedId = 4;
            int actualId = this.commentService.AddComment(addCommentDto);

            Assert.Equal(expectedId, actualId);

            int expectedCommentsCount = 4;
            var actualComments = context.Comments
                .Where(c => c.ItemId == 2)
                .ToList();

            Assert.Equal(expectedCommentsCount, actualComments.Count);
        }
    }
}
