using EnigpusEFCore.Entities;

namespace EnigpusEFCore.Services;

public interface INovelService
{
    void AddNovel(Novel novel);
    Novel? SearchNovelByTitle(string title);
    Novel? SearchNovelById(string id);
    void DeleteById(string id);
    List<Novel> GetAllNovel();
    void UpdateNovel(Novel novel, string title, string publisher, string year, string author);
}