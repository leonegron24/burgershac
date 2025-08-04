[ApiController]
[Route("api/[controller]")]
public class BurgersController : ControllerBase
{
    private readonly BurgersService _service;
    public BurgersController(BurgersService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Burger>> GetBurgers()
    {
        try
        {
            var burgers = _service.GetBurgers();
            return Ok(burgers);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<Burger> CreateBurger([FromBody] Burger burgerData)
    {
        try
        {
            Burger newBurger = _service.CreateBurger(burgerData);
            return Ok(newBurger);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Burger> GetBurgerById(int id)
    {
        try
        {
            Burger burger = _service.GetBurgerById(id);
            return Ok(burger);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Burger> UpdateBurger(int id, [FromBody] Burger update)
    {
        try
        {
            var burger = _service.UpdateBurger(id, update);
            return Ok(burger);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<Burger> DeleteBurger(int id)
    {
        try
        {
            _service.DeleteBurger(id);
            return Ok("burger was deleted!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}