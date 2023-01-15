using EnigpusEFCore.Entities;
using EnigpusEFCore.Repositories;
using EnigpusEFCore.Utilities;

namespace EnigpusEFCore.Services;

public class NovelService : INovelService
{
    private readonly INovelRepository _novelRepository;
    private readonly IPersistence _persistence;
    private readonly INovelUtility _novelUtility;

    public NovelService(INovelRepository novelRepository, IPersistence persistence, INovelUtility novelUtility)
    {
        _novelRepository = novelRepository;
        _persistence = persistence;
        _novelUtility = novelUtility;
    }

    public void AddNovel(Novel novel)
    {
        var novelSave = new Novel
        {
            Code = _novelUtility.GenerateCode($"{novel.PublicationYear}"),
            Title = novel.Title,
            Publisher = novel.Publisher,
            PublicationYear = novel.PublicationYear,
            Author = novel.Author
        };
        _novelRepository.AddNovel(novelSave);
        _persistence.SaveChanges();
    }

    public Novel? SearchNovelByTitle(string title)
    {
        try
        {
            
            var novel = _novelRepository.SearchNovelByTitle(title);
            if (novel is null) throw new Exception("Novel Not Found!");
            return novel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Novel? SearchNovelById(string id)
    {
        try
        {
            var novel = _novelRepository.SearchNovelById(int.Parse(id));
            if (novel is null) throw new Exception("Novel Not Found!");
            return novel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteById(string id)
    {
        var deletedNovel = SearchNovelById(id);
        _novelRepository.DeleteNovel(deletedNovel);
        _persistence.SaveChanges();
    }

    public List<Novel> GetAllNovel()
    {
        return _novelRepository.GetAllNovel();
    }

    public void UpdateNovel(Novel novel, string title, string publisher, string year, string author)
    {
        try
        {
            novel.Title = title is null or "" ? novel.Title : title;
            novel.Publisher = publisher is null or "" ? novel.Publisher : publisher;
            novel.PublicationYear = year is null or "" ? novel.PublicationYear : int.Parse(year);
            novel.Author = author is null or "" ? novel.Author : author;
            _novelRepository.UpdateNovel(novel);
            _persistence.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
}