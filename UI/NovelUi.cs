using EnigpusEFCore.Entities;
using EnigpusEFCore.Services;

namespace EnigpusEFCore.UI;

public class NovelUi : INovelUi
{
    private readonly NovelService _novelService;

    public NovelUi(NovelService novelService)
    {
        _novelService = novelService;
    }

    public void GetNovel()
    {
        try
        {
            var novels = _novelService.GetAllNovel();
            foreach (var novel in novels)
            {
                Console.WriteLine(novel);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void CreateNovel()
    {
        try
        {
            var titleNovel = Input("Enter Title of The Novel: ", s => s.Length < 50);
            var publisherNovel = Input("Enter Publisher of The Novel: ", s => s.Length < 50);
            var authorNovel = Input("Enter Author of The Novel: ", s => s.Length < 50);
            var publicationYearNovel = Input("Enter Publication Year of The Novel: ", s => int.TryParse(s, out _));
            var novelAdd = new Novel
            {
                Code = "",
                Title = titleNovel,
                Publisher = publisherNovel,
                PublicationYear = int.Parse(publicationYearNovel),
                Author = authorNovel
            };
            _novelService.AddNovel(novelAdd);

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
            var title = Input("Enter Title of The Novel: ", s => s.Length < 50);
            var novel = _novelService.SearchNovelByTitle(title);
            Console.WriteLine(novel);
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
            var novel = _novelService.SearchNovelById(id);
            Console.WriteLine(novel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateNovel()
    {
        try
        {
            var id = Input("Enter Id of The Novel: ", s => int.TryParse(s, out _));
            var novelToUpdate = _novelService.SearchNovelById(id);
            var newTitle = Input("Enter New Title of The Novel: ");
            var newPublisher = Input("Enter New Publisher of The Novel: ");
            var newPublicationYear = Input("Enter New Publication Year of The Novel: ");
            var newAuthor = Input("Enter New Author of The Novel: ");

            _novelService.UpdateNovel(novelToUpdate, newTitle, newPublisher, newPublicationYear, newAuthor);

            Console.WriteLine("Update Success!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteNovel()
    {
        try
        {
            var id = Input("Enter Id of The Novel: ", s => int.TryParse(s, out _));
            _novelService.DeleteById(id);
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