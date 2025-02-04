using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

using PluralKit.Core;

namespace PluralKit.API;

[ApiController]
[Route("v1/a")]
public class AccountController: ControllerBase
{
    private readonly IDatabase _db;
    private readonly ModelRepository _repo;

    public AccountController(IDatabase db, ModelRepository repo)
    {
        _db = db;
        _repo = repo;
    }

    [HttpGet("{aid}")]
    public async Task<ActionResult<JObject>> GetSystemByAccount(ulong aid)
    {
        var system = await _repo.GetSystemByAccount(aid);
        if (system == null)
            return NotFound("Account not found.");

        return Ok(system.ToJson(User.ContextFor(system)));
    }
}