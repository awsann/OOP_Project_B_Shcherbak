using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    class Program
    {
        static GameLibrary library;
        static List<GameItem> store;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            library = new GameLibrary("My Game Collection");
            store = new List<GameItem>();
            InitializeData();
            ShowMainMenu();
        }

        static void InitializeData()
        {
            // Створення платформ
            var pc = new Platform("PC", 2020);
            var ps5 = new Platform("PlayStation 5", 2020);
            var xbox = new Platform("Xbox Series X", 2020);
            // Додавання ігор до бібліотеки
            var game1 = new VideoGame(1, "The Witcher 3", Genre.RPG, pc);
            game1.AddAchievement(new Achievement("Griffin Slayer", "Defeat the Griffin", 50));
            game1.AddAchievement(new Achievement("Master Hunter", "Complete all contracts", 100));
            library.AddGame(game1);
            var game2 = new OnlineGame(2, "Fortnite", Genre.ACTION, pc, 100, false);
            game2.AddAchievement(new Achievement("First Victory", "Win your first match", 75));
            library.AddGame(game2);
            var game3 = new VideoGame(3, "FIFA 24", Genre.SPORTS, ps5);
            library.AddGame(game3);
            // Додавання товарів до магазину
            store.Add(new DigitalGame(101, "Cyberpunk 2077", 59.99m, 70000, "https://store.com/cyber"));
            store.Add(new PhysicalGame(102, "Red Dead Redemption 2", 49.99m, true, 5.99m));
            store.Add(new DigitalGame(103, "Hogwarts Legacy", 69.99m, 85000, "https://store.com/hogwarts"));
        }

        static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("-GAME LIBRARY MANAGEMENT SYSTEM-");
                Console.WriteLine();
                Console.WriteLine("1.  Показати всі ігри в бібліотеці");
                Console.WriteLine("2.  Додати нову гру");
                Console.WriteLine("3.  Видалити гру");
                Console.WriteLine("4.  Показати деталі гри");
                Console.WriteLine("5.  Додати досягнення до гри");
                Console.WriteLine("6.  Розблокувати досягнення");
                Console.WriteLine("7.  Почати ігрову сесію");
                Console.WriteLine("8.  Завершити поточну сесію");
                Console.WriteLine("9.  Показати історію сесій");
                Console.WriteLine("10. Сортувати ігри за назвою");
                Console.WriteLine("11. Клонувати гру");
                Console.WriteLine("12. Магазин ігор (поліморфізм)");
                Console.WriteLine("13. Демонстрація поліморфізму через IPlayable");
                Console.WriteLine("14. Порівняти ігри");
                Console.WriteLine("0.  Вихід");
                Console.WriteLine();
                Console.Write("Оберіть пункт меню: ");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        ShowAllGames();
                        break;
                    case "2":
                        AddNewGame();
                        break;
                    case "3":
                        RemoveGame();
                        break;
                    case "4":
                        ShowGameDetails();
                        break;
                    case "5":
                        AddAchievementToGame();
                        break;
                    case "6":
                        UnlockAchievement();
                        break;
                    case "7":
                        StartGameSession();
                        break;
                    case "8":
                        EndGameSession();
                        break;
                    case "9":
                        ShowSessionHistory();
                        break;
                    case "10":
                        SortGames();
                        break;
                    case "11":
                        CloneGame();
                        break;
                    case "12":
                        ShowStore();
                        break;
                    case "13":
                        DemonstratePolymorphism();
                        break;
                    case "14":
                        CompareGames();
                        break;
                    case "0":
                        Console.WriteLine("До побачення!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }

        static void ShowAllGames() //Показати всі ігри в бібліотеці
        {
            Console.WriteLine("-СПИСОК ІГОР У БІБЛІОТЕЦІ-\n");
            var games = library.GetAllGames();
            if (games.Count == 0)
            {
                Console.WriteLine("Бібліотека порожня.");
                return;
            }
            foreach (var game in games)
            {
                Console.WriteLine($"[ID: {game.Id}] {game.GetGameDetails()}");
            }
        }

        static void AddNewGame()
        {
            try
            {
                Console.WriteLine("-ДОДАВАННЯ НОВОЇ ГРИ-\n");
                Console.Write("ID гри: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Console.WriteLine("Помилка: ID повинен бути додатним числом!");
                    return;
                }
                if (library.GetAllGames().Any(g => g.Id == id))
                {
                    Console.WriteLine("Помилка: Гра з таким ID вже існує!");
                    return;
                }
                Console.Write("Назва гри: ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Помилка: Назва не може бути порожньою!");
                    return;
                }
                Console.WriteLine("\nОберіть жанр:");
                Console.WriteLine("1. ACTION");
                Console.WriteLine("2. RPG");
                Console.WriteLine("3. STRATEGY");
                Console.WriteLine("4. SPORTS");
                Console.WriteLine("5. ADVENTURE");
                Console.Write("Вибір: ");
                if (!int.TryParse(Console.ReadLine(), out int genreChoice) ||
                    genreChoice < 1 || genreChoice > 5)
                {
                    Console.WriteLine("Помилка: Невірний вибір жанру!");
                    return;
                }
                Genre genre = (Genre)(genreChoice - 1);
                Console.Write("\nНазва платформи: ");
                string platformName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(platformName))
                {
                    Console.WriteLine("Помилка: Назва платформи не може бути порожньою!");
                    return;
                }
                Console.Write("Рік випуску платформи: ");
                if (!int.TryParse(Console.ReadLine(), out int year) ||
                    year < 1950 || year > DateTime.Now.Year + 5)
                {
                    Console.WriteLine("Помилка: Некоректний рік випуску!");
                    return;
                }
                var platform = new Platform(platformName, year);
                Console.Write("\nЧи це онлайн-гра? (y/n): ");
                bool isOnline = Console.ReadLine()?.ToLower() == "y";
                VideoGame game;
                if (isOnline)
                {
                    Console.Write("Максимальна кількість гравців: ");
                    if (!int.TryParse(Console.ReadLine(), out int maxPlayers) || maxPlayers <= 0)
                    {
                        Console.WriteLine("Помилка: Кількість гравців повинна бути додатною!");
                        return;
                    }
                    Console.Write("Потрібна підписка? (y/n): ");
                    bool needsSub = Console.ReadLine()?.ToLower() == "y";
                    game = new OnlineGame(id, title, genre, platform, maxPlayers, needsSub);
                }
                else
                {
                    game = new VideoGame(id, title, genre, platform);
                }
                library.AddGame(game);
                Console.WriteLine("\nГру успішно додано!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні гри: {ex.Message}");
            }
        }

        static void RemoveGame()
        {
            Console.WriteLine("-ВИДАЛЕННЯ ГРИ-\n");
            ShowAllGames();
            Console.Write("\nВведіть ID гри для видалення: ");
            int id = int.Parse(Console.ReadLine());
            library.RemoveGame(id);
            Console.WriteLine("\nГру видалено!");
        }

        static void ShowGameDetails()
        {
            Console.WriteLine("-ДЕТАЛІ ГРИ-\n");
            Console.Write("Введіть ID гри: ");
            int id = int.Parse(Console.ReadLine());
            var game = library.GetAllGames().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                Console.WriteLine("Гру не знайдено!");
                return;
            }
            Console.WriteLine($"\n{game.GetGameDetails()}");
            Console.WriteLine($"Платформа: {game.Platform.GetInfo()}");
            Console.WriteLine($"Час гри: {game.GetPlayTime()} хвилин");
            Console.WriteLine("\nДосягнення:");
            if (game.Achievements.Count == 0)
            {
                Console.WriteLine("  Немає досягнень");
            }
            else
            {
                foreach (var ach in game.Achievements)
                {
                    string status = ach.IsUnlocked ? "✓" : "✗";
                    Console.WriteLine($"  {status} {ach.Title} - {ach.Description} ({ach.Points} points)");
                }
            }
        }

        static void AddAchievementToGame()
        {
            Console.WriteLine("-ДОДАВАННЯ ДОСЯГНЕННЯ-\n");
            Console.Write("ID гри: ");
            int id = int.Parse(Console.ReadLine());
            var game = library.GetAllGames().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                Console.WriteLine("Гру не знайдено!");
                return;
            }
            Console.Write("Назва досягнення: ");
            string title = Console.ReadLine();
            Console.Write("Опис: ");
            string description = Console.ReadLine();
            Console.Write("Очки: ");
            int points = int.Parse(Console.ReadLine());
            var achievement = new Achievement(title, description, points);
            game.AddAchievement(achievement);
            Console.WriteLine("\nДосягнення додано!");
        }

        static void UnlockAchievement()
        {
            Console.WriteLine("-РОЗБЛОКУВАННЯ ДОСЯГНЕННЯ-\n");
            Console.Write("ID гри: ");
            int id = int.Parse(Console.ReadLine());
            var game = library.GetAllGames().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                Console.WriteLine("Гру не знайдено!");
                return;
            }
            Console.WriteLine("\nДоступні досягнення:");
            for (int i = 0; i < game.Achievements.Count; i++)
            {
                var ach = game.Achievements[i];
                string status = ach.IsUnlocked ? "[Розблоковано]" : "";
                Console.WriteLine($"{i + 1}. {ach.Title} {status}");
            }
            Console.Write("\nОберіть номер досягнення: ");
            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < game.Achievements.Count)
            {
                game.Achievements[choice].Unlock();
            }
        }

        static void StartGameSession()
        {
            Console.WriteLine("-ПОЧАТОК ІГРОВОЇ СЕСІЇ-\n");
            ShowAllGames();
            Console.Write("\nВведіть ID гри: ");
            int id = int.Parse(Console.ReadLine());
            var game = library.GetAllGames().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                Console.WriteLine("Гру не знайдено!");
                return;
            }
            var session = library.StartSession(game);
            game.StartGame();
            Console.WriteLine($"\nСесію #{session.SessionId} розпочато!");
        }

        static void EndGameSession()
        {
            Console.WriteLine("-ЗАВЕРШЕННЯ СЕСІЇ-\n");
            if (library.Sessions.Count == 0)
            {
                Console.WriteLine("Немає активних сесій!");
                return;
            }
            var lastSession = library.Sessions.Last();
            lastSession.Game.PauseGame();
            lastSession.EndSession();
            Console.WriteLine("Сесію завершено!");
        }

        static void ShowSessionHistory()
        {
            Console.WriteLine("-ІСТОРІЯ ІГРОВИХ СЕСІЙ-\n");
            if (library.Sessions.Count == 0)
            {
                Console.WriteLine("Історія порожня.");
                return;
            }
            foreach (var session in library.Sessions)
            {
                Console.WriteLine($"Сесія #{session.SessionId}:");
                Console.WriteLine($"  Гра: {session.Game.Title}");
                Console.WriteLine($"  Початок: {session.StartTime}");
                Console.WriteLine($"  Тривалість: {session.Duration} хв\n");
            }
        }

        static void SortGames()
        {
            Console.WriteLine("-СОРТУВАННЯ ІГОР ЗА НАЗВОЮ-\n");

            var games = library.GetAllGames();
            games.Sort(); // Використання IComparable
            Console.WriteLine("Відсортовані ігри:");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Title}");
            }
        }

        static void CloneGame()
        {
            Console.WriteLine("-КЛОНУВАННЯ ГРИ-\n");
            Console.Write("Введіть ID гри для клонування: ");
            int id = int.Parse(Console.ReadLine());
            var game = library.GetAllGames().FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                Console.WriteLine("Гру не знайдено!");
                return;
            }
            var clonedGame = (VideoGame)game.Clone();
            clonedGame.Id = library.GetAllGames().Max(g => g.Id) + 1;
            clonedGame.Title = game.Title + " (Copy)";
            library.AddGame(clonedGame);
            Console.WriteLine($"\nГру клоновано! Нове ID: {clonedGame.Id}");
        }

        static void ShowStore()
        {
            Console.WriteLine("-МАГАЗИН ІГОР (Демонстрація поліморфізму)-\n");
            // Поліморфізм через абстрактний клас
            foreach (GameItem item in store)
            {
                item.DisplayInfo(); // Різні реалізації для Digital/Physical
                Console.WriteLine($"  Info: {item.GetItemInfo()}");
                Console.WriteLine($"  Total Cost: ${item.CalculateTotalCost()}\n");
            }
        }

        static void DemonstratePolymorphism()
        {
            Console.WriteLine("-ДЕМОНСТРАЦІЯ ПОЛІМОРФІЗМУ через IPlayable-\n");
            // Використання змінної типу інтерфейс
            List<IPlayable> playableGames = new List<IPlayable>();
            foreach (var game in library.GetAllGames())
            {
                playableGames.Add(game);
            }
            Console.WriteLine("Запуск всіх ігор через інтерфейс IPlayable:\n");
            foreach (IPlayable game in playableGames)
            {
                game.StartGame(); // Поліморфний виклик
                Console.WriteLine($"Час гри: {game.GetPlayTime()} хв");
                game.PauseGame();
                Console.WriteLine();
            }
        }

        static void CompareGames()
        {
            Console.WriteLine("-ПОРІВНЯННЯ ІГОР-\n");
            var games = library.GetAllGames();
            if (games.Count < 2)
            {
                Console.WriteLine("Недостатньо ігор для порівняння!");
                return;
            }
            Console.Write("ID першої гри: ");
            int id1 = int.Parse(Console.ReadLine());
            Console.Write("ID другої гри: ");
            int id2 = int.Parse(Console.ReadLine());
            var game1 = games.FirstOrDefault(g => g.Id == id1);
            var game2 = games.FirstOrDefault(g => g.Id == id2);
            if (game1 == null || game2 == null)
            {
                Console.WriteLine("Одну з ігор не знайдено!");
                return;
            }
            int result = game1.CompareTo(game2);
            Console.WriteLine($"\nРезультат порівняння (за назвою):");
            if (result < 0)
                Console.WriteLine($"'{game1.Title}' йде перед '{game2.Title}'");
            else if (result > 0)
                Console.WriteLine($"'{game2.Title}' йде перед '{game1.Title}'");
            else
                Console.WriteLine("Ігри мають однакові назви");
        }
    }
}