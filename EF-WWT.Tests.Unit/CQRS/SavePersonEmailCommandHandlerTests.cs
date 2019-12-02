using EF_WWT.CQRS.Commands;
using EF_WWT.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EF_WWT.Tests.Unit.CQRS
{
    public class SavePersonEmailCommandHandlerTests
    {
        private readonly SavePersonEmailCommandHandler _handler;

        public SavePersonEmailCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<EFWWTContext>();
            options.UseInMemoryDatabase("mydb");
            var context = new EFWWTContext(options.Options);

            _handler = new SavePersonEmailCommandHandler(context);
        }

        [Fact]
        public async Task Handler_PersonResourceDoesntExist_RNFExceptionThrown()
        {
            var request = new SavePersonEmailCommand() { PersonIdentifier = Guid.NewGuid(), EmailAddress = "123@123.com" };
            //try
            //{
            //    Action act = () =>  await _handler.TestHandle(request, new System.Threading.CancellationToken());
            //}
            //catch(Exception exc)
            //{
            //    exc.Should().BeOfType<ResourceNotFoundException>();
            //}

            //Action act = async () =>  await _handler.TestHandle(request, new System.Threading.CancellationToken());
            //act.Should().ThrowExactly<ResourceNotFoundException>();



        }


    }
}
