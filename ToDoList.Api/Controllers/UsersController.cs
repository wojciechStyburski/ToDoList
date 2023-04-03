namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly ICommandHandler<SignUp> _signUpHandler;
        private readonly ICommandHandler<SignIn> _signInHandler;
        private readonly ITokenStorage _tokenStorage;
        private readonly IQueryHandler<GetUserDetails, UserDto> _userDetails;

        public UsersController
        (
            ICommandHandler<SignUp> signUpHandler, 
            ICommandHandler<SignIn> signInHandler, 
            ITokenStorage tokenStorage, 
            IQueryHandler<GetUserDetails, UserDto> userDetails
        )
        {
            _signUpHandler = signUpHandler;
            _signInHandler = signInHandler;
            _tokenStorage = tokenStorage;
            _userDetails = userDetails;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDetails()
        {
            var userId = Guid.Parse(User.Identity.Name);
            return Ok(await _userDetails.HandleAsync(new GetUserDetails(){Id = userId}));
        }
            

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUp command)
        {
            command = command with { UserId = Guid.NewGuid() };
            await _signUpHandler.HandleAsync(command);

            return NoContent();
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<JwtDto>> SingIn(SignIn command)
        {
            await _signInHandler.HandleAsync(command);
            var accessToken = _tokenStorage.Get();

            return Ok(accessToken);
        }
    }
}
