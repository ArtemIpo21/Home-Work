using System;
using System.IO;

class FileDirect
{
    static string currentPath = Directory.GetCurrentDirectory();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Текущий путь: " + currentPath);
            Console.WriteLine("\n1. Показать содержимое каталога");
            Console.WriteLine("2. Перейти в подкаталог");
            Console.WriteLine("3. Вернуться в родительский каталог");
            Console.WriteLine("4. Открыть TXT файл");
            Console.WriteLine("5. Создать каталог");
            Console.WriteLine("6. Создать TXT файл");
            Console.WriteLine("7. Удалить файл или каталог");
            Console.WriteLine("8. Показать доступные диски");
            Console.WriteLine("9. Выбрать диск");
            Console.WriteLine("0. Выход");

            Console.Write("\nВыбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": 
                    ShowDirectoryContents();
                    break;
                case "2": 
                    EnterSubdirectory(); 
                    break;
                case "3": 
                    GoToParentDirectory(); 
                    break;
                case "4":
                    OpenTextFile();
                    break;
                case "5": 
                    CreateDirectory();
                    break;
                case "6": 
                    CreateTextFile(); 
                    break;
                case "7": 
                    DeleteFileOrDirectory(); 
                    break;
                case "8": 
                    ShowDrives();
                    break;
                case "9": 
                    SelectDrive();
                    break;
                case "0": 
                    return;
                default: Console.WriteLine("Неверный выбор!"); break;
            }

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }
    }

    static void ShowDirectoryContents()
    {
        try
        {
            string[] dirs = Directory.GetDirectories(currentPath);
            string[] files = Directory.GetFiles(currentPath);

            Console.WriteLine("\nКаталоги:");
            foreach (var dir in dirs)
                Console.WriteLine("  [D] " + Path.GetFileName(dir));

            Console.WriteLine("\nФайлы:");
            foreach (var file in files)
                Console.WriteLine("  [F] " + Path.GetFileName(file));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    static void EnterSubdirectory()
    {
        Console.Write("Имя подкаталога: ");
        string dir = Console.ReadLine();
        string newPath = Path.Combine(currentPath, dir);
        if (Directory.Exists(newPath))
            currentPath = newPath;
        else
            Console.WriteLine("Каталог не найден!");
    }

    static void GoToParentDirectory()
    {
        DirectoryInfo parent = Directory.GetParent(currentPath);
        if (parent != null)
            currentPath = parent.FullName;
        else
            Console.WriteLine("Вы уже в корневом каталоге");
    }

    static void OpenTextFile()
    {
        Console.Write("Имя файла: ");
        string file = Console.ReadLine();
        string filePath = Path.Combine(currentPath, file);
        if (File.Exists(filePath))
            Console.WriteLine(File.ReadAllText(filePath));
        else
            Console.WriteLine("Файл не найден!");
    }

    static void CreateDirectory()
    {
        Console.Write("Имя нового каталога: ");
        string dirName = Console.ReadLine();
        string dirPath = Path.Combine(currentPath, dirName);
        Directory.CreateDirectory(dirPath);
        Console.WriteLine("Каталог создан");
    }

    static void CreateTextFile()
    {
        Console.Write("Имя файла: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(currentPath, fileName);
        Console.WriteLine("Введите текст для записи:");

        using (StreamWriter sw = new StreamWriter(filePath))
        {
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                sw.WriteLine(line);
        }

        Console.WriteLine("Файл создан.");
    }

    static void DeleteFileOrDirectory()
    {
        Console.Write("Имя файла или каталога: ");
        string name = Console.ReadLine();
        string path = Path.Combine(currentPath, name);

        if (File.Exists(path))
        {
            Console.Write("Удалить файл? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                File.Delete(path);
                Console.WriteLine("Файл удалён.");
            }
        }
        else if (Directory.Exists(path))
        {
            Console.Write("Удалить каталог и всё его содержимое? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Directory.Delete(path, true);
                Console.WriteLine("Каталог удалён.");
            }
        }
        else
            Console.WriteLine("Файл/каталог не найден.");
    }

    static void ShowDrives()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            Console.WriteLine($"\nДиск: {drive.Name}");
            if (drive.IsReady)
            {
                Console.WriteLine($"  Файловая система: {drive.DriveFormat}");
                Console.WriteLine($"  Всего места: {drive.TotalSize / 1024 / 1024} MB");
                Console.WriteLine($"  Свободно: {drive.AvailableFreeSpace / 1024 / 1024} MB");
            }
            else
            {
                Console.WriteLine("  Диск не готов.");
            }
        }
    }

    static void SelectDrive()
    {
        Console.Write("Введите букву диска (например, C): ");
        string driveLetter = Console.ReadLine()?.ToUpper() + ":\\";
        if (Directory.Exists(driveLetter))
            currentPath = driveLetter;
        else
            Console.WriteLine("Диск не найден.");
    }
}