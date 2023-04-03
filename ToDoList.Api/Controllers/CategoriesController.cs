namespace ToDoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICommandHandler<CreateCategory> _createCategoryHandler;
    private readonly ICommandHandler<ChangeCategoryDescription> _changeCategoryDescriptionCommandHandler;
    private readonly ICommandHandler<DeleteCategory> _deleteCategoryHandler;

    private readonly IQueryHandler<GetCategories, IEnumerable<CategoryDto>> _categoryQueryHandler;
    private readonly IQueryHandler<GetUserCategories, IEnumerable<CategoryDto>> _userCategoryQueryHandler;

    public CategoriesController
    (
        ICommandHandler<CreateCategory> createCategoryHandler, 
        IQueryHandler<GetCategories, IEnumerable<CategoryDto>> categoryQueryHandler, 
        IQueryHandler<GetUserCategories, IEnumerable<CategoryDto>> userCategoryQueryHandler, 
        ICommandHandler<ChangeCategoryDescription> changeCategoryDescriptionCommandHandler, 
        ICommandHandler<DeleteCategory> deleteCategoryHandler
    )
    {
        _createCategoryHandler = createCategoryHandler;
        _categoryQueryHandler = categoryQueryHandler;
        _userCategoryQueryHandler = userCategoryQueryHandler;
        _changeCategoryDescriptionCommandHandler = changeCategoryDescriptionCommandHandler;
        _deleteCategoryHandler = deleteCategoryHandler;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories([FromQuery] GetCategories query) 
        => Ok(await _categoryQueryHandler.HandleAsync(query));

    [HttpGet("user")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetUserCategories([FromQuery] GetUserCategories query)
    {
        query.UserId = Guid.Parse(User.Identity.Name);
        return Ok(await _userCategoryQueryHandler.HandleAsync(query));
    }

    [HttpPost]
    public async Task<ActionResult> Create (CreateCategory command)
    {
        await _createCategoryHandler.HandleAsync(command with
        {
            Id = Guid.NewGuid(),
            UserId = Guid.Parse(User.Identity.Name)
        });

        return CreatedAtAction(nameof(Create), new { id = command.Id }, null);
    }

    [HttpPut]
    public async Task<ActionResult> ChangeDescription(ChangeCategoryDescription command)
    {
        await _changeCategoryDescriptionCommandHandler.HandleAsync(command with
        {
            UserId = Guid.Parse(User.Identity.Name)
        });

        return NoContent();
    }

    [HttpDelete("{categoryId:guid}")]
    [Authorize(Policy = "is-admin")]
    public async Task<ActionResult> DeleteCategory(Guid categoryId)
    {
        await _deleteCategoryHandler.HandleAsync(new DeleteCategory(categoryId));
        return NoContent();
    }
}