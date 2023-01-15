using EnigpusEFCore.Repositories;

namespace EnigpusEFCore.Utilities;

public class MagazineUtility : IMagazineUtility
{
    private readonly IMagazineRepository _magazineRepository;

    public MagazineUtility(IMagazineRepository magazineRepository)
    {
        _magazineRepository = magazineRepository;
    }

    public string GenerateCode(string year)
    {
        try
        {
            var listMagazine = _magazineRepository.GetAllMagazine();
            string? result = null;
            int maxCounterCode = 0;
            if (listMagazine == null)
            {
                result = year + "-B-0000" + maxCounterCode++;
                return result;
            }
            else
            {
                foreach (var magazine in listMagazine)
                {
                    string[] codeMagazine = magazine.Code.Split('-');
                    if (int.Parse(codeMagazine[2]) > maxCounterCode)
                    {
                        maxCounterCode = int.Parse(codeMagazine[2]);
                    }
                }

                maxCounterCode++;
                result = year + "-B-0000" + maxCounterCode;
                return result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}