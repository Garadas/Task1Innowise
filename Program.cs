using System;

while (true)
{
    try
    {

        Console.WriteLine("Введите первое число:");
        string inputa = Console.ReadLine();
        if (!double.TryParse(inputa, out double a))
        {
            Console.WriteLine("Ошибка: Введено некорректное число!");
            continue;
        }

        Console.WriteLine("Выберите арифметическую опреацию + - * /");
        string inputo = Console.ReadLine();
        if (string.IsNullOrEmpty(inputo) || inputo.Length != 1|| !"+-*/".Contains(inputo[0]))
        {
            Console.WriteLine("Ошибка: Операция должна быть одним из символов + - * /");
            continue;
        }
        char o = inputo[0];

        Console.WriteLine("Введите второе число:");
        string inputb = Console.ReadLine();
        if (!double.TryParse(inputb, out double b))
        {
            Console.WriteLine("Ошибка: Введено некорректное число!");
            continue;
        }
        double result = o switch
        {
            '+'=>a+b,
            '*'=>a*b,
            '-' => a - b,
            '/' => b != 0 ? a / b : throw new DivideByZeroException(),
            _ => throw new Exception("Выбран неверный знак операции")
        };

        if (double.IsInfinity(result))
            throw new OverflowException("Результат операции слишком большой");
        if (double.IsNaN(result))
            throw new InvalidOperationException("Результат операции неопределен");

        Console.WriteLine($"результат {a}{o}{b} = {result}");
    }

    catch (DivideByZeroException)
    {
        Console.WriteLine("Ошибка: Деление на ноль!");
    }
    catch (OverflowException)
    {
        Console.WriteLine("Ошибка: Результат операции слишком большой!");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("Нажмите пробел/spacebar если желаете продолжить.");
    Console.WriteLine("Или любую другую клавишу для завершения.");
    if (Console.ReadKey().Key != ConsoleKey.Spacebar) break;
}
