using EnigpusEFCore.Entities;

namespace EnigpusEFCore.Repositories;

public interface IMagazineRepository
{
    void AddMagazine(Magazine magazine);
    Magazine? SearchMagazineByTitle(string title);
    Magazine? SearchMagazineById(int id);
    void DeleteMagazine(Magazine magazine);
    List<Magazine> GetAllMagazine();
    void UpdateMagazine(Magazine magazine);
}