using System;

Console.Title = "Калькулятор";

while (true)
{
    try
    {
        //блок запросов ввода
        Console.WriteLine("Введите первое число:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Выберите арифметическую опреацию + - * /");
        char o = char.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        int b = int.Parse(Console.ReadLine());

        //выполнение операции
        switch (o)
        {
            case '+':
                Console.WriteLine($"результат {a}{o}{b} = {a + b}");
                break;
            case '*':
                Console.WriteLine($"результат {a}{o}{b} = {a * b}");
                break;
            case '/':
                Console.WriteLine($"результат {a}{o}{b} = {a / b} и {a % b} в остатке");
                break;
            case '-':
                Console.WriteLine($"результат {a}{o}{b} = {a - b}");
                break;
            default: throw new Exception("Выбран неверный знак операции");//исключение неверного знака операции
        }
    }

    // блок обработки исключений
    catch (FormatException)
    {
        Console.WriteLine("Ошибка: Введены некорректные данные!");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Ошибка: Деление на ноль!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    //повторный запуск
    Console.WriteLine("Нажмите пробел/spacebar если желаете продолжить.");
    Console.WriteLine("Или любую другую клавишу для завершения.");
    if (Console.ReadKey().Key != ConsoleKey.Spacebar) break;
}
