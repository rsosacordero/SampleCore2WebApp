using EF_WWT.CQRS.Commands;
using EF_WWT.Exceptions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EF_WWT.Tests.Unit.CQRS
{
    public class SavePersonEmailCommandHandlerTests: IClassFixture<TestInMemoryContext>
    {
        private TestInMemoryContext _inMemoryContext; 
        private SavePersonEmailCommandHandler _handler;

        public SavePersonEmailCommandHandlerTests(TestInMemoryContext inMemoryContext)
        {
            _inMemoryContext = inMemoryContext;
            _handler = new SavePersonEmailCommandHandler(_inMemoryContext.Context);
        }

        [Fact]
        public async Task Handler_PersonResourceDoesntExist_RNFExceptionThrown()
        {
            var request = new SavePersonEmailCommand() { PersonIdentifier = Guid.NewGuid(), EmailAddress = "123@123.com" };
            Func<Task> func = async () => await _handler.TestHandle(request, new System.Threading.CancellationToken());
            func.Should().ThrowExactly<ResourceNotFoundException>();
        }


        [Fact]
        public async Task Handler_PersonExistsEmailUpdated_TaskCompleted()
        {
            var request = new SavePersonEmailCommand() { PersonIdentifier = new Guid("92C4279F-1207-48A3-8448-4636514EB7E2"), EmailAddress = "ken0@adventure-works.com" };
            await _handler.TestHandle(request, new System.Threading.CancellationToken());

            var person = _inMemoryContext.Context.Person.Include(c => c.EmailAddress).First(c => c.Rowguid == request.PersonIdentifier);
            person.EmailAddress.FirstOrDefault(c => c.EmailAddress1 == request.EmailAddress).Should().NotBeNull(); 
        }



    }
}
