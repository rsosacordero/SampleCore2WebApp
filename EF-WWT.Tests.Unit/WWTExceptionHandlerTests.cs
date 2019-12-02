using EF_WWT.Exceptions;
using EF_WWT.Filters;
using FluentAssertions;
using System;
using Xunit;

namespace EF_WWT.Tests.Unit
{
    public class WWTExceptionHandlerTests
    {
        private WWTExceptionHandler _handler;

        public WWTExceptionHandlerTests()
        {
            _handler = new WWTExceptionHandler();
        }

        [Fact]
        public void HandleException_NullException_InternalServerErrorApiErrorTypeReturned()
        {
            var result = _handler.HandleException(null);
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void HandleException_GenericExceptionCaught_InternalServerErrorApiErrorTypeReturned()
        {
            var result = _handler.HandleException(new Exception("Some message"));
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void HandleException_ResourceNotFoundExceptionReceived_NotFoundApiErrorTypeReturned()
        {
            var result = _handler.HandleException(new ResourceNotFoundException("A resource wasn't found"));
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
