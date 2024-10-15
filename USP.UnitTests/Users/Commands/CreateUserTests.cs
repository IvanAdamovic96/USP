using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using USP.Application.Common.Dto;
using USP.Application.Users.Commands;
using USP.BaseTests;
using USP.BaseTests.Builders.Commands;
using USP.BaseTests.Builders.Dto;

namespace USP.UnitTests.Users.Commands;

public class CreateUserTests : Base
{
    //test - svi podaci su validni
    [Fact]
    public async Task CreateUserCommand_User_UserCreated()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Ivan")
            .WithLastName("Adamovic")
            .WithEmail("iadamovic@gmail.com")
            .Build();
        
        //var dto = new EditUserDto("Ivan", "Adamovic", "iadamovic@gmail.com", null);
        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var jsonRequest = JsonSerializer.Serialize(command); 
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    
    //test - firstName je invalid
    [Fact]
    public async Task CreateUserCommand_InvalidFirstName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithLastName("Adamovic")
            .WithEmail("iadamovic@gmail.com")
            .Build();

        //var dto = new EditUserDto("-", "-", "iadamovic@gmail.com", null);
        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();

        var jsonRequest = JsonSerializer.Serialize(command); 
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    
    //test - lastName je invalid
    [Fact]
    public async Task CreateUserCommand_InvalidLastName_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Ivan")
            .WithEmail("iadamovic@gmail.com")
            .Build();

        //var dto = new EditUserDto("-", "-", "iadamovic@gmail.com", null);
        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();

        var jsonRequest = JsonSerializer.Serialize(command); 
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    
    //test - email je invalid
    [Fact]
    public async Task CreateUserCommand_InvalidEmail_BadRequest()
    {
        //Given (Arrange) - what is part of request
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Ivan")
            .WithLastName("Adamovic")
            .Build();

        //var dto = new EditUserDto("-", "-", "iadamovic@gmail.com", null);
        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();

        var jsonRequest = JsonSerializer.Serialize(command); 
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}