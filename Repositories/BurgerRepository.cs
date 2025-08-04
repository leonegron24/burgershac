
public class BurgersRepository : IRepository<Burger>
{
    private readonly IDbConnection _db;
    public BurgersRepository(IDbConnection db)
    {
        _db = db;
    }

    public List<Burger> GetAll()
    {
        string sql = "SELECT * FROM burgers;";
        return _db.Query<Burger>(sql).ToList();
    }

    public Burger GetById(int id)
    {
        string sql = "SELECT * FROM burgers WHERE id = @Id;";
        return _db.Query<Burger>(sql, new { Id = id }).SingleOrDefault();
    }

    public Burger Create(Burger burgerData)
    {
        // TODO
        string sql = @"
        INSERT INTO 
        burgers (name, price) 
        VALUES 
        (@Name, @Price);
        SELECT * FROM burgers WHERE id = LAST_INSERT_ID();";
        Burger burger = _db.Query<Burger>(sql, burgerData).SingleOrDefault();
        return burger;
    }

    public void Delete(int id)
    {
        // TODO
        string sql = @"DELETE FROM burgers WHERE id = @Id LIMIT 1;";
        int rowsAffected = _db.Execute(sql, new { Id = id });

        if (rowsAffected != 1)
        {
            throw new Exception(rowsAffected + "rows were affected and that is bad");
        }
    }

    public Burger Update(Burger burger)
    {
        // TODO
        throw new NotImplementedException();
    }

    public Burger Update(int id, Burger updateData)
    {
        throw new NotImplementedException();
    }
}