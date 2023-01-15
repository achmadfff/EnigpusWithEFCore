using EnigpusEFCore.Entities;
using EnigpusEFCore.Repositories;
using EnigpusEFCore.Services;

namespace EnigpusEFCore.Utilities;

public class NovelUtility : INovelUtility
{
    private readonly INovelRepository _novelRepository;


    public NovelUtility(INovelRepository novelRepository)
    {
        _novelRepository = novelRepository;
    }

    public string GenerateCode(string year)
    {
        try
        {
            var listNovel = _novelRepository.GetAllNovel();
            string? result = null;
            int maxCounterCode = 0;
            if (listNovel == null)
            {
                result = year + "-A-0000"  + maxCounterCode++;
                return result;
            }
            else
            {
                foreach (var novel in listNovel)
                {
                    string[] codeNovel = novel.Code.Split('-');
                    if (int.Parse(codeNovel[2]) > maxCounterCode)
                    {
                        maxCounterCode = int.Parse(codeNovel[2]);
                    }
                }
                maxCounterCode++;
                result = year + "-A-0000" + maxCounterCode;
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