using EnigpusEFCore.Repositories;
using EnigpusEFCore.Services;
using EnigpusEFCore.UI;
using EnigpusEFCore.Utilities;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new EnigpusDBContext();
        var novelRepository = new NovelRepository(context);
        var utility = new NovelUtility(novelRepository);
        var persistence = new DbPersistence(context);
        var novelService = new NovelService(novelRepository, persistence, utility);
        var novelUi = new NovelUi(novelService);
        try
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("1. View Novel");
                Console.WriteLine("2. Create Novel");
                Console.WriteLine("3. Search Novel By Title");
                Console.WriteLine("4. Search Novel By Id");
                Console.WriteLine("5. Update Novel");
                Console.WriteLine("6. Delete Novel");
                Console.WriteLine("0. Exit");
                Console.Write("Enter option: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        novelUi.GetNovel();
                        Console.ReadKey();
                        break;
                    case 2:
                        novelUi.CreateNovel();
                        Console.ReadKey();
                        break;
                    case 3:
                        novelUi.SearchTitle();
                        Console.ReadKey();
                        break;
                    case 4:
                        novelUi.SearchById();
                        Console.ReadKey();
                        break;
                    case 5:
                        novelUi.UpdateNovel();
                        Console.ReadKey();
                        break;
                    case 6:
                        novelUi.DeleteNovel();
                        Console.ReadKey();
                        break;
                }
            } while (option != 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message : {ex.Message}");
            Console.WriteLine($"Source : {ex.Source}");
            Console.WriteLine("Some Error Ocurred");
        }
    }
}