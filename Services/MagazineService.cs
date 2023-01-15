using EnigpusEFCore.Entities;
using EnigpusEFCore.Repositories;
using EnigpusEFCore.Utilities;

namespace EnigpusEFCore.Services;

public class MagazineService : IMagazineService
{
    private readonly IMagazineRepository _magazineRepository;
    private readonly IPersistence _persistence;
    private readonly IMagazineUtility _magazineUtility;

    public MagazineService(IPersistence persistence, IMagazineUtility utility, IMagazineRepository magazineRepository)
    {
        _persistence = persistence;
        _magazineUtility = utility;
        _magazineRepository = magazineRepository;
    }

    public void AddMagazine(Magazine magazine)
    {
        try
        {
            var magazineSave = new Magazine
            {
                Code = _magazineUtility.GenerateCode($"{magazine.PublicationYear}"),
                Title = magazine.Title,
                PublishingPeriod = magazine.PublishingPeriod,
                PublicationYear = magazine.PublicationYear
            };
            _magazineRepository.AddMagazine(magazineSave);
            _persistence.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Magazine? SearchMagazineByTitle(string title)
    {
        try
        {
            var magazine = _magazineRepository.SearchMagazineByTitle(title);
            if (magazine is null) throw new Exception("Magazine Not Found!");
            return magazine;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Magazine? SearchMagazineById(string id)
    {
        try
        {
            var magazine = _magazineRepository.SearchMagazineById(int.Parse(id));
            if (magazine is null) throw new Exception("Magazine Not Found!");
            return magazine;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteById(string id)
    {
        try
        {
            var deletedMagazine = SearchMagazineById(id);
            _magazineRepository.DeleteMagazine(deletedMagazine);
            _persistence.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Magazine> GetAllMagazine()
    {
        return _magazineRepository.GetAllMagazine();
    }

    public void UpdateMagazine(Magazine magazine, string title, string publishing, string year)
    {
        try
        {
            magazine.Title = title is null or "" ? magazine.Title : title;
            magazine.PublishingPeriod = publishing is null or "" ? magazine.PublishingPeriod : publishing;
            magazine.PublicationYear = year is null or "" ? magazine.PublicationYear : int.Parse(year);
            _magazineRepository.UpdateMagazine(magazine);
            _persistence.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}