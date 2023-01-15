using EnigpusEFCore.Entities;

namespace EnigpusEFCore.Services;

public interface IMagazineService
{
    void AddMagazine(Magazine magazine);
    Magazine? SearchMagazineByTitle(string title);
    Magazine? SearchMagazineById(string id);
    void DeleteById(string id);
    List<Magazine> GetAllMagazine();
    void UpdateMagazine(Magazine magazine, string title, string publishing, string year);
}