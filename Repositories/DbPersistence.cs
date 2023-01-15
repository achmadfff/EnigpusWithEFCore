namespace EnigpusEFCore.Repositories;

public class DbPersistence : IPersistence
{
    private readonly EnigpusDBContext _enigpusDbContext;


    public DbPersistence(EnigpusDBContext enigpusDbContext)
    {
        _enigpusDbContext = enigpusDbContext;
    }


    public void SaveChanges()
    {
        _enigpusDbContext.SaveChanges();
    }
}