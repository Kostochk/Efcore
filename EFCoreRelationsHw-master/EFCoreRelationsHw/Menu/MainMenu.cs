using EFCoreRelationsHw.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationsHw.Menu
{
    public class MainMenu
    {
        private readonly UserService _userService;
        private readonly MovieService _movieService;

        public MainMenu(UserService userService, MovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Додати користувача");
                Console.WriteLine("2. Додати фільм");
                Console.WriteLine("3. Переглянути фільми");
                Console.WriteLine("4. Оновити назву фільму");
                Console.WriteLine("5. Видалити фільм");
                Console.WriteLine("0. Вихід");

                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1":
                        Console.Write("Ім'я: ");
                        var name = Console.ReadLine();
                        Console.Write("Email: ");
                        var email = Console.ReadLine();
                        Console.Write("Пароль: ");
                        var pass = Console.ReadLine();
                        _userService.CreateUser(name!, email!, pass!);
                        break;

                    case "2":
                        Console.Write("Назва фільму: ");
                        var title = Console.ReadLine();
                        Console.Write("Рік: ");
                        var year = int.Parse(Console.ReadLine()!);
                        Console.Write("Опис: ");
                        var desc = Console.ReadLine();
                        Console.Write("ID користувача: ");
                        var userId = int.Parse(Console.ReadLine()!);
                        _movieService.AddMovie(title!, year, desc!, userId);
                        break;

                    case "3":
                        var movies = _movieService.GetAllMovies();
                        foreach (var m in movies)
                            Console.WriteLine($"[{m.Id}] {m.Title} ({m.Year}) - {m.User.Username}");
                        break;

                    case "4":
                        Console.Write("ID фільму: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Console.Write("Нова назва: ");
                        string newTitle = Console.ReadLine()!;
                        _movieService.UpdateMovie(id, newTitle);
                        break;

                    case "5":
                        Console.Write("ID фільму: ");
                        int delId = int.Parse(Console.ReadLine()!);
                        _movieService.DeleteMovie(delId);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}
