using EnigpusEFCore.Entities;
using EnigpusEFCore.Services;

namespace EnigpusEFCore.UI;

public class MagazineUi : IMagazineUi
{
    private readonly IMagazineService _magazineService;

    public MagazineUi(IMagazineService magazineService)
    {
        _magazineService = magazineService;
    }

    public void GetMagazine()
    {
        var magazines = _magazineService.GetAllMagazine();
        foreach (var magazine in magazines)
        {
            Console.WriteLine(magazine);
        }
    }

    public void CreateMagazine()
    {
        try
        {
            var titleMagazine = Input("Enter Title of The Magazine: ", s => s.Length < 50);
            var publishingPeriod = Input("Enter Publishing Period of The Magazine: ", s => s.Length < 50);
            var publicationYearMagazine = Input("Enter Publication Year of The Magazine: ", s => int.TryParse(s, out _));
            var magazineAdd = new Magazine
            {
                Code = "",
                Title = titleMagazine,
                PublishingPeriod = publishingPeriod,
                PublicationYear = int.Parse(publicationYearMagazine)
            };
            _magazineService.AddMagazine(magazineAdd);
            Console.WriteLine("Create Success!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void SearchTitle()
    {
        try
        {
            var title = Input("Enter Title of The Magazine: ", s => s.Length < 50);
            var magazine = _magazineService.SearchMagazineByTitle(title);
            Console.WriteLine(magazine);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void SearchById()
    {
        try
        {
            var id = Input("Enter Id of The Novel: ", s => int.TryParse(s, out _));
            var magazine = _magazineService.SearchMagazineById(id);
            Console.WriteLine(magazine);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateMagazine()
    {
        try
        {
            var id = Input("Enter Id of The Magazine: ", s => int.TryParse(s, out _));
            var magazineToUpdate = _magazineService.SearchMagazineById(id);
            var newTitle = Input("Enter New Title of The Magazine: ");
            var newPublishingPeriod = Input("Enter New Publishing Period of The Magazine: ");
            var newPublicationYear = Input("Enter New Publication Year of The Magazine: ");

            _magazineService.UpdateMagazine(magazineToUpdate, newTitle, newPublishingPeriod, newPublicationYear);

            Console.WriteLine("Update Success!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteMagazine()
    {
        try
        {
            var id = Input("Enter Id of The Magazine: ", s => int.TryParse(s, out _));
            _magazineService.DeleteById(id);
            Console.WriteLine("Delete Success!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static string Input(string info, Func<string, bool> validate)
    {
        while (true)
        {
            Console.Write($"{info} : ");
            var input = Console.ReadLine();
            if (input is null or "" || !validate(input)) continue;
            return input;
        }
    }

    public static string Input(string info)
    {
        Console.Write($"{info} : ");
        var input = Console.ReadLine();
        return input;
    }
}