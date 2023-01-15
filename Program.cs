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
        var novelUtility = new NovelUtility(novelRepository);
        var persistence = new DbPersistence(context);
        var novelService = new NovelService(novelRepository, persistence, novelUtility);
        var novelUi = new NovelUi(novelService);

        var magazineRepository = new MagazineRepository(context);
        var magazineUtility = new MagazineUtility(magazineRepository);
        var magazineService = new MagazineService(persistence, magazineUtility, magazineRepository);
        var magazineUi = new MagazineUi(magazineService);
         
        // try
        // {
        //     int option;
        //     do
        //     {
        //         Console.Clear();
        //         Console.WriteLine("1. View Novel");
        //         Console.WriteLine("2. Create Novel");
        //         Console.WriteLine("3. Search Novel By Title");
        //         Console.WriteLine("4. Search Novel By Id");
        //         Console.WriteLine("5. Update Novel");
        //         Console.WriteLine("6. Delete Novel");
        //         Console.WriteLine("0. Exit");
        //         Console.Write("Enter option: ");
        //         option = int.Parse(Console.ReadLine());
        //
        //         switch (option)
        //         {
        //             case 1:
        //                 novelUi.GetNovel();
        //                 Console.ReadKey();
        //                 break;
        //             case 2:
        //                 novelUi.CreateNovel();
        //                 Console.ReadKey();
        //                 break;
        //             case 3:
        //                 novelUi.SearchTitle();
        //                 Console.ReadKey();
        //                 break;
        //             case 4:
        //                 novelUi.SearchById();
        //                 Console.ReadKey();
        //                 break;
        //             case 5:
        //                 novelUi.UpdateNovel();
        //                 Console.ReadKey();
        //                 break;
        //             case 6:
        //                 novelUi.DeleteNovel();
        //                 Console.ReadKey();
        //                 break;
        //         }
        //     } while (option != 0);
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine($"Message : {ex.Message}");
        //     Console.WriteLine($"Source : {ex.Source}");
        //     Console.WriteLine("Some Error Ocurred");
        // }
        try
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("1. View Magazine");
                Console.WriteLine("2. Create Magazine");
                Console.WriteLine("3. Search Magazine By Title");
                Console.WriteLine("4. Search Magazine By Id");
                Console.WriteLine("5. Update Magazine");
                Console.WriteLine("6. Delete Magazine");
                Console.WriteLine("0. Exit");
                Console.Write("Enter option: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        magazineUi.GetMagazine();
                        Console.ReadKey();
                        break;
                    case 2:
                        magazineUi.CreateMagazine();
                        Console.ReadKey();
                        break;
                    case 3:
                        magazineUi.SearchTitle();
                        Console.ReadKey();
                        break;
                    case 4:
                        magazineUi.SearchById();
                        Console.ReadKey();
                        break;
                    case 5:
                        magazineUi.UpdateMagazine();
                        Console.ReadKey();
                        break;
                    case 6:
                        magazineUi.DeleteMagazine();
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