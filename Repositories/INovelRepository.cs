using EnigpusEFCore.Entities;

namespace EnigpusEFCore.Repositories;

public interface INovelRepository
{
    void AddNovel(Novel novel);
    Novel? SearchNovelByTitle(string title);
    Novel? SearchNovelById(int id);
    void DeleteNovel(Novel novel);
    List<Novel> GetAllNovel();
    void UpdateNovel(Novel novel);
}