using System;

while (true)
{
    try
    {
        double a, b;
        char o;

        double EnterNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double chislo))
                {
                    return chislo;
                }
                Console.WriteLine("Ошибка: Введено некорректное число! Попробуйте еще раз.");
            }
        }

        char EnterOperation()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length == 1 && "+-*/".Contains(input[0]))
                {
                    return input[0];
                }
                Console.WriteLine("Ошибка: Операция должна быть одним из символов + - * /");
            }
        }

        Console.WriteLine("Введите первое число:");
        a = EnterNumber();

        Console.WriteLine("Выберите арифметическую опреацию + - * /");
        o = EnterOperation();

        Console.WriteLine("Введите второе число:");
        b = EnterNumber();

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
