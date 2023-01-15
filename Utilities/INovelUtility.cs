using EnigpusEFCore.Entities;

namespace EnigpusEFCore.Utilities;

public interface INovelUtility
{
    string GenerateCode(string year);
}