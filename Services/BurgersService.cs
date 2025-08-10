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

        if (burger == null)
        {
            throw new Exception("No burger found with the id of " + id);
        }
        return burger;
    }

    public Burger UpdateBurger(int id, Burger update)
    {
        Burger originalBurger = GetBurgerById(id);

        if (originalBurger == null)
        {
            throw new Exception("No burger found with the id of " + id);
        }

        originalBurger.Name = update.Name ?? originalBurger.Name;
        originalBurger.Price = update.Price ?? originalBurger.Price;

        _repo.Update(originalBurger);

        return originalBurger;
    }

    public void DeleteBurger(int id)
    {
        _repo.Delete(id);
    }
}