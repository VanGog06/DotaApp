using DotaApp.Common;
using DotaApp.Data;
using DotaApp.Data.Common;
using DotaApp.Data.DbModels;
using DotaApp.Services.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotaApp.Services.DataServices.Tests
{
    public class AdminServiceTests
    {
        private IAdminService adminService;

        private List<Comment> GetDummyComments()
        {
            return new List<Comment>
            {
                new Comment { Id = 1, CommentMessage = "Test message", Username = "Pesho", CreatedOn = DateTime.UtcNow.ToLocalTime(), IsPending = false, IsApproved = true, Item = new Item { } },
                new Comment { Id = 2, CommentMessage = "Another message message", Username = "Gosho", CreatedOn = DateTime.UtcNow.ToLocalTime(), IsPending = true, IsApproved = false, Item = new Item { } },
                new Comment { Id = 3, CommentMessage = "Something message", Username = "Stamat", CreatedOn = DateTime.UtcNow.ToLocalTime(), IsPending = false, IsApproved = true, Item = new Item { } },
                new Comment { Id = 4, CommentMessage = "Something message 234", Username = "Stamat", CreatedOn = DateTime.UtcNow.ToLocalTime(), IsPending = false, IsApproved = true, Item = new Item { } }
            };
        }

        private void SeedComments(DotaAppContext context)
        {
            context.Comments.AddRange(this.GetDummyComments());
            context.SaveChanges();
        }

        [Fact]
        public void DeleteCommentById_WithDummyComments_ShouldThrowExceptionWhenCommentNotFound()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.adminService = new AdminService(context);

            int commentId = 123;

            DotaException exception = Assert.Throws<DotaException>(() => this.adminService.DeleteCommentById(commentId));

            Assert.Equal(Constants.InvalidOperation, exception.Message);
        }

        [Fact]
        public void DeleteCommentById_WithDummyComments_ShouldDeleteCommentWhenValidIdIsPassed()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.adminService = new AdminService(context);

            int commentId = 4;

            this.adminService.DeleteCommentById(commentId);

            var expectedCommentsCount = 3;
            var actualComments = context.Comments.ToList();

            Assert.Equal(expectedCommentsCount, actualComments.Count);
        }

        [Fact]
        public void Review_WithDummyComments_ShouldReturnCorrectResults()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.adminService = new AdminService(context);

            var expectedComments = context.Comments
                .Where(c => !c.IsApproved && c.IsPending)
                .ToList();

            var actualComments = this.adminService.Review();

            Assert.Equal(expectedComments.Count, actualComments.Count);
        }

        [Fact]
        public void Approve_WithDummyComments_ShouldThrowExceptionWhenCommentNotFound()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.adminService = new AdminService(context);

            int commentId = 123;

            DotaException exception = Assert.Throws<DotaException>(() => this.adminService.Approve(commentId));

            Assert.Equal(Constants.InvalidOperation, exception.Message);
        }

        [Fact]
        public void Approve_WithDummyComments_ShouldApproveTheCorrectComment()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.adminService = new AdminService(context);

            int commentId = 1;

            this.adminService.Approve(commentId);

            var actualComment = context.Comments
                .First(c => c.Id == commentId);

            Assert.False(actualComment.IsPending);
            Assert.True(actualComment.IsApproved);
        }

        [Fact]
        public void Reject_WithDummyComments_ShouldThrowExceptionWhenCommentNotFound()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.adminService = new AdminService(context);

            int commentId = -2;

            DotaException exception = Assert.Throws<DotaException>(() => this.adminService.Reject(commentId));

            Assert.Equal(Constants.InvalidOperation, exception.Message);
        }

        [Fact]
        public void Reject_WithDummyComments_ShouldRejectTheCorrectComment()
        {
            var context = DotaAppContextInitializer.InitializeContext();
            this.SeedComments(context);

            this.adminService = new AdminService(context);

            int commentId = 1;

            this.adminService.Reject(commentId);

            var actualComment = context.Comments
                .First(c => c.Id == commentId);

            Assert.False(actualComment.IsPending);
            Assert.False(actualComment.IsApproved);
        }
    }
}
