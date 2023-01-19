

namespace sharpChore.Models;

[ApiController]
[Route("api/[controller]")]
public class ChoresController : ControllerBase
{
  private readonly ChoreService _choreService;
  private readonly Auth0Provider _auth0provider;

  public ChoresController(ChoreService choreService, Auth0Provider auth0provider)
  {
    _choreService = choreService;
    _auth0provider = auth0provider;
  }

  [HttpGet]

  public async Task<ActionResult<List<Chore>>> Get()
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);

      List<Chore> chores = _choreService.Get(userInfo?.Id);
      return Ok(chores);

    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
  [HttpGet("{id}")]

  public async Task<ActionResult<Chore>> GetOne(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Chore chore = _choreService.GetOne(id, userInfo?.Id);
      return Ok(chore);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Chore>> Create([FromBody] Chore choreData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      choreData.CreatorId = userInfo.Id;
      Chore chore = _choreService.Create(choreData);
      chore.Creator = userInfo;
      return Ok(chore);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> Remove(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _choreService.Remove(id, userInfo.Id);
      return Ok(message);

    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
}
