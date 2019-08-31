using DotaApp.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotaApp.Services.DataServices.Tests
{
    public static class DotaAppContextInitializer
    {
        public static DotaAppContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<DotaAppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new DotaAppContext(options);
        }
    }
}
