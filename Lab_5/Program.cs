// See https://aka.ms/new-console-template for more information
using Lab_5;

class Program
{
    static List<BasketballPlayer> players = new List<BasketballPlayer>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - Додати гравця");
            Console.WriteLine("2 - Вивести гравців");
            Console.WriteLine("3 - Знайти гравця");
            Console.WriteLine("4 - Видалити гравця");
            Console.WriteLine("5 - Демонстрація поведінки");
            Console.WriteLine("0 - Вийти з програми");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некоректний ввід. Будь ласка, виберіть опцію з меню.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddPlayer();
                    break;
                case 2:
                    PrintPlayers();
                    break;
                case 3:
                    FindPlayer();
                    break;
                case 4:
                    RemovePlayer();
                    break;
                case 5:
                    DemonstrateBehavior();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некоректний ввід. Будь ласка, виберіть опцію з меню.");
                    break;
            }
        }
    }

    // Функція для додавання гравця
    static void AddPlayer()
    {
        BasketballPlayer player;

        string enteredName;
        string enteredAge;
        Position enteredPosition;
        double enteredHeight;
        double enteredWeight;
        int enteredShirtNumber;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Оберіть тип створення гравця:");
            Console.WriteLine("1 - Ввести обов'язкові параметри");
            Console.WriteLine("2 - Ввести всі параметри");
            Console.WriteLine("3 - Додати за допомогою TryParse");
            Console.WriteLine("0 - Повернутися до головного меню");
            Console.WriteLine("Ваш вибір: ");
            Console.WriteLine();

            if (!int.TryParse(Console.ReadLine(), out int creationChoice) || (creationChoice < 0 || creationChoice > 3))
            {
                Console.WriteLine("Некоректний вибір");
                continue;
            }

            switch (creationChoice)
            {
                case 0:
                    return;
                case 1:

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введіть ім'я гравця:");
                        enteredName = Console.ReadLine();
                        try
                        {
                            player = new BasketballPlayer(enteredName, 1);
                            break;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введіть вік гравця:");
                        enteredAge = Console.ReadLine();

                        if (int.TryParse(enteredAge, out int age))
                        {
                            try
                            {
                                player.Age = age;
                                break;
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                                continue;
                            }
                        }
                        else
                        {
                            try
                            {
                                throw new FormatException("Вік повинен бути числом");
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }

                    players.Add(player); // Додавання гравця до списку
                    Console.WriteLine("Гравець доданий успішно.");
                    break;



                case 2:

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введіть ім'я гравця:");
                        Console.WriteLine();
                        enteredName = Console.ReadLine();
                        try
                        {
                            player = new BasketballPlayer(enteredName, 1, Position.SmallForward, 1, 1, false, 1);
                            break;
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введіть вік гравця:");
                        enteredAge = Console.ReadLine();

                        if (int.TryParse(enteredAge, out int age))
                        {
                            try
                            {
                                player.Age = age;
                                break;
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                                continue;
                            }
                        }
                        else
                        {
                            try
                            {
                                throw new FormatException("Вік повинен бути числво");
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введіть зріст гравця:");
                        string heightInputSrt = Console.ReadLine();

                        if (double.TryParse(heightInputSrt, out double height))
                        {

                            try
                            {
                                player.Height = height;
                                break;
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                throw new FormatException("Зріст гравця повинен бути числом");
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Введіть вагу гравця:");
                        string weightInputStr = Console.ReadLine();

                        if (double.TryParse(weightInputStr, out double weight))
                        {

                            try
                            {
                                player.Weight = weight;
                                break;
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                throw new FormatException("Вага гравця повинен бути числом");
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    Position playerPosition;
                    do
                    {
                        Console.WriteLine("Виберіть позицію гравця:");
                        foreach (Position position in Enum.GetValues(typeof(Position)))
                        {
                            Console.WriteLine($"{(int)position} - {position}");
                        }
                    }
                    while (!Enum.TryParse(Console.ReadLine(), out playerPosition) || !Enum.IsDefined(typeof(Position), playerPosition));
                    player.PlayerPosition = playerPosition;

                    int shirtNumber;
                    do
                    {
                        Console.WriteLine("Введіть номер гравця на футболці(0-99):");
                    }
                    while (!int.TryParse(Console.ReadLine(), out shirtNumber) || shirtNumber < 0 && shirtNumber > 99);

                    player.ShirtNumber = shirtNumber;
                    bool isInjured = false;

                    players.Add(player);
                    Console.WriteLine("Гравець доданий успішно.");
                    break;

                case 3:
                    Console.WriteLine("Введіть рядок характеристик гравця (name, age, position, height, weight, isInjured, shirtNumber):");
                    string playerData = Console.ReadLine();

                    BasketballPlayer newPlayer;
                    if (BasketballPlayer.TryParse(playerData, out newPlayer))
                    {
                        players.Add(newPlayer);
                        Console.WriteLine("Гравець доданий успішно.");
                    }
                    else
                    {
                        Console.WriteLine("Помилка при додаванні гравця. Некоректні дані.");
                    }
                    break;

            }
        }
    }


    static void PrintPlayers()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Немає гравців для виведення.");
            return;
        }

        Console.WriteLine("Список гравців:");
        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {players[i].Name}, Вік: {players[i].Age},  Позиція: {players[i].PlayerPosition}, Зріст: {players[i].Height} см, Вага: {players[i].Weight} кг, Стан травмованості: {players[i].IsInjured}, Номер футболки: {players[i].ShirtNumber} ");
        }
    }

    // Функція для пошуку гравця
    static void FindPlayer()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Немає гравців для пошуку.");
            return;
        }
        Console.WriteLine("");
        Console.WriteLine("Виберіть характеристику для пошуку:");
        Console.WriteLine("1 - По імені");
        Console.WriteLine("2 - По віку");
        Console.WriteLine("3 - По позиції");

        int searchChoice;
        do
        {
            Console.WriteLine("Виберіть один із варіантів (1, 2 або 3):");
        } while (!int.TryParse(Console.ReadLine(), out searchChoice) || searchChoice < 1 || searchChoice > 3);

        switch (searchChoice)
        {
            case 1:
                Console.WriteLine("Введіть ім'я для пошуку:");
                string nameToSearch = Console.ReadLine();
                var playersByName = players.Where(player => player.Name == nameToSearch).ToList();
                PrintSearchResults(playersByName);
                break;
            case 2:
                int ageToSearch;

                do
                {
                    Console.WriteLine("Введіть вік для пошуку (додатнє число):");
                } while (!int.TryParse(Console.ReadLine(), out ageToSearch) || ageToSearch < 0);


                var playersByAge = players.Where(player => player.Age == ageToSearch).ToList();
                PrintSearchResults(playersByAge);
                break;
            case 3:
                Position positionToSearch;

                do
                {
                    Console.WriteLine("Виберіть позицію для пошуку:");
                    foreach (var position in Enum.GetValues(typeof(Position)))
                    {
                        Console.WriteLine($"{(int)position} - {position}");
                    }
                } while (!Enum.TryParse(Console.ReadLine(), out positionToSearch) || !Enum.IsDefined(typeof(Position), positionToSearch));
                var playersByPosition = players.Where(player => player.PlayerPosition == positionToSearch).ToList();
                PrintSearchResults(playersByPosition);
                break;
        }
    }

    // Функція для виведення результатів пошуку
    static void PrintSearchResults(List<BasketballPlayer> searchResults)
    {
        if (searchResults.Count == 0)
        {
            Console.WriteLine("");
            Console.WriteLine("Немає результатів для виведення.");
            return;
        }

        Console.WriteLine("Результати пошуку:");
        foreach (var player in searchResults)
        {
            Console.WriteLine(player);
        }
    }

    // Функція для видалення гравця
    static void RemovePlayer()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Немає гравців для видалення.");
            return;
        }

        Console.WriteLine("Виберіть спосіб видалення:");
        Console.WriteLine("1 - За номером");
        Console.WriteLine("2 - За іменем");

        int removeChoice;
        do
        {
            Console.WriteLine("Виберіть опцію видалення (1 або 2):");
        } while (!int.TryParse(Console.ReadLine(), out removeChoice) || (removeChoice != 1 && removeChoice != 2));

        switch (removeChoice)
        {
            case 1:
                int playerNumber;
                do
                {
                    for (int i = 0; i < players.Count; i++)
                    {
                        Console.WriteLine("Введіть номер гравця для видалення:");
                        Console.WriteLine($"{i + 1} - {players[i].Name}");

                    }

                } while (!int.TryParse(Console.ReadLine(), out playerNumber) || playerNumber < 1 || playerNumber > players.Count);

                players.RemoveAt(playerNumber - 1);
                Console.WriteLine("Гравець видалений успішно.");
                break;

            case 2:
                Console.WriteLine("Введіть ім'я гравця для видалення:");
                string nameToRemove = Console.ReadLine();

                var playerToRemove = players.FirstOrDefault(player => player.Name == nameToRemove);
                if (playerToRemove != null)
                {
                    players.Remove(playerToRemove);
                    Console.WriteLine("Гравець видалений успішно.");
                }
                else
                {
                    Console.WriteLine("Гравця з таким іменем не знайдено.");
                }
                break;
        }
    }

    // Функція для демонстрації поведінки
    static void DemonstrateBehavior()
    {
        if (players.Count == 0)
        {
            Console.WriteLine("Список гравців порожній.");
            return;
        }

        Console.WriteLine("Демонстрація поведінки гравця:");

        PrintPlayers();

        Console.Write("Введіть номер гравця, для якого ви хочете змінити інформацію (позицію або травмованість): ");
        if (int.TryParse(Console.ReadLine(), out int playerIndex) && playerIndex > 0 && playerIndex <= players.Count)
        {
            BasketballPlayer player = players[playerIndex - 1];

            Console.WriteLine($"Поточна позиція гравця {player.Name}: {player.PlayerPosition}");
            Console.WriteLine($"Поточний стан травмованості гравця {player.Name}: {player.IsInjured}");

            Console.WriteLine("Виберіть опцію:");
            Console.WriteLine("1 - Змінити позицію");
            Console.WriteLine("2 - Змінити стан травмованості");

            int optionChoice;
            if (int.TryParse(Console.ReadLine(), out optionChoice) && (optionChoice == 1 || optionChoice == 2))
            {
                switch (optionChoice)
                {
                    case 1:
                        Console.WriteLine("Виберіть нову позицію гравця:");
                        foreach (var playerPosition in Enum.GetValues(typeof(Position)))
                        {
                            Console.WriteLine($"{(int)playerPosition} - {playerPosition}");
                        }

                        if (Enum.TryParse(Console.ReadLine(), out Position newPosition))
                        {
                            player.PlayerPosition = newPosition;
                            Console.WriteLine($"Позиція гравця {player.Name} змінена на: {player.PlayerPosition}");
                        }
                        else
                        {
                            Console.WriteLine("Некоректна позиція. Позиція гравця залишається незмінною.");
                        }
                        break;

                    case 2:
                        Console.Write("Введіть стан травмованості гравця (true/false): ");
                        if (bool.TryParse(Console.ReadLine(), out bool isInjured))
                        {
                            player.IsInjured = isInjured;
                            Console.WriteLine($"Стан травмованості гравця {player.Name} змінений на: {player.IsInjured}");
                        }
                        else
                        {
                            Console.WriteLine("Некоректний ввід стану травмованості. Стан травмованості залишається незмінним.");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некоректний вибір опції. Інформація про гравця залишається незмінною.");
            }
        }
        else
        {
            Console.WriteLine("Некоректний номер гравця.");
        }
    }
}
