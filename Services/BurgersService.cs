public class BurgersService
{
    private readonly BurgersRepository _repo;
    public BurgersService(BurgersRepository repo)
    {
        _repo = repo;
    }

    public List<Burger> GetBurgers()
    {
        return _repo.GetAll();
    }

    public Burger CreateBurger(Burger burgerData)
    {
        Burger burger = _repo.Create(burgerData);
        return burger;
    }

    public Burger GetBurgerById(int id)
    {
        Burger burger = _repo.GetById(id);
        return burger;
    }

    public Burger UpdateBurger(int id, Burger update)
    {
        GetBurgerById(id);
        Burger burger = _repo.Update(update);
        return burger;
    }

    public void DeleteBurger(int id)
    {
        _repo.Delete(id);
    }
}