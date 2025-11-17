using Application.Identity.Interfaces;
using Core.Identity.Dtos;
using Core.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Api.AccountManagement.Logging;
using Web.Api.AccountManagement.Models;
using Web.Errors;

namespace Web.Api.AccountManagement.Controllers;

[ApiController]
[Route("account-management")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ITokenService tokenService,
        ILogger<AccountController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _logger = logger;
    }

    /// <summary>
    /// Logs in a user using the specified login model.
    /// </summary>
    /// <param name="loginModel">The login model containing the user's username.</param>
    /// <returns>Returns an <see cref="ActionResult&lt;UserDto&gt;"/> representing the result of the login operation.
    /// </returns>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginModel loginModel)
    {
        _logger.LoginAttempt(loginModel.UserName);
        
        var user = await _userManager.FindByNameAsync(loginModel.UserName);
        if (user == null)
        {
            _logger.LoginFailed(loginModel.UserName);
            return Unauthorized(new ApiResponse(401));
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
        if (!result.Succeeded)
        {
            _logger.LoginFailed(loginModel.UserName);
            return Unauthorized(new ApiResponse(401));
        }
        
        _logger.LoginSucceeded(loginModel.UserName);

        return Ok(new UserDto
        {
            Token = _tokenService.CreateToken(user),
            UserName = user.UserName,
            Role = user.Role.ToString(),
            Station = user.Station
        });
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="registerModel">The registration model containing user information.</param>
    /// <returns>The registered user DTO.</returns>
    [Authorize(Roles = "Admin")]
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterModel registerModel)
    {
        _logger.RegisterAttempt(registerModel.UserName, registerModel.Station, registerModel.Role.ToString());
        
        var existingUser = await _userManager.FindByNameAsync(registerModel.UserName);
        if (existingUser != null)
        {
            _logger.RegisterExists(registerModel.UserName);
            return BadRequest("Username already exists.");
        }
        
        var user = new AppUser
        {
            UserName = registerModel.UserName,
            Role =  registerModel.Role,
            Station = registerModel.Station,
        };
        
        var result = await _userManager.CreateAsync(user, registerModel.Password);
        
        if (!result.Succeeded)
        {
            return BadRequest(new ApiResponse(400));
        }
        
        _logger.RegisterSucceeded(registerModel.UserName);

        return Ok(new UserDto
        {
            Token = "This will be a token",
            UserName = user.UserName,
            Role = user.Role.ToString(),
            Station = user.Station
        });
    }

    /// <summary>
    /// Checks if a username exists in the system.
    /// </summary>
    /// <param name="userName">The username to check.</param>
    /// <returns>Returns a boolean value indicating whether the username exists or not.</returns>
    [HttpGet("username-exists")]
    public async Task<ActionResult<bool>> CheckUserNameExistsAsync([FromQuery] string userName)
    {
        _logger.CheckUserNameExists(userName);
        return await _userManager.FindByNameAsync(userName) != null;
    }
}