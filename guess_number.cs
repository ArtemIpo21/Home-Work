using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;

Console.WriteLine("Введите число от 1 до 100"); 
byte x = byte.Parse(Console.ReadLine());

while (true)
{
    if (0 < x && x <= 100)
    {
        break;
    }
    else
    {
       Console.WriteLine("Число должно быть в промежутке от 1 до 100");
       x = byte.Parse(Console.ReadLine());
    }
}

int r1 = 0;
int r2 = 100;
int a = 50;

while (true)
{
    if (a == x)
    {
        Console.WriteLine($"Это {x} я - гадал!!!");
        break;
    }
    Console.WriteLine($"Я думаю это {a}");
    string tf = Console.ReadLine();
    if (tf == "б")
    {
        r1 = a+1;
    }
    else if (tf == "м")
    {
        r2 = a;
    }
    else
    {
        Console.WriteLine("ошибка");
    }


    a = (r1 + r2) / 2;
}