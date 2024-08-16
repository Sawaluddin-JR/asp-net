class Program
{
    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("Pilih salah satu opsi:");
            Console.WriteLine("1. Prime & Emirp");
            Console.WriteLine("2. Menukar dua buah bilangan");
            Console.WriteLine("3. Cek string(huruf saja/angka saja/huruf dan angka");
            Console.WriteLine("4. Angka mengandung koma");
            Console.WriteLine("0. Keluar");

            Console.Write("Masukkan pilihan Anda: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Masukkan pilihan yang valid.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    QuetionOne();
                    break;
                case 2:
                    QuetionTwo();
                    break;
                case 3:
                    QuestionThree();
                    break;
                case 4:
                    QuestionFour();
                    break;
                case 0:
                    Console.WriteLine("Keluar dari program.");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }

        } while (choice != 0);
    }

    static void QuetionOne()
    {
        Console.Write("Masukkan angka N: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (IsPrime(n))
        {
            if (IsEmirp(n))
            {
                Console.WriteLine($"{n} merupakan bilangan emirp.");
            }
            else
            {
                Console.WriteLine($"{n} merupakan bilangan prima.");
            }
        }
        else
        {
            Console.WriteLine($"{n} bukan bilangan prima.");
        }
    }

    static void QuetionTwo()
    {
        Console.Write("A = ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("B = ");
        int b = Convert.ToInt32(Console.ReadLine());

        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine("Setelah pertukaran:");
        Console.WriteLine($"A = {a}, B = {b}");
    }

    static void QuestionThree()
    {
        Console.Write("Input: ");
        string input = Console.ReadLine();

        bool hasLetter = false;
        bool hasDigit = false;

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                hasLetter = true;
            }
            else if (char.IsDigit(c))
            {
                hasDigit = true;
            }

            if (hasLetter && hasDigit)
            {
                break;
            }
        }

        string result = "Input tidak terdiri dari huruf atau angka saja";

        if (hasLetter && hasDigit)
        {
            result = "Huruf dan angka";
        }
        else if (hasLetter)
        {
            result = "Huruf saja";
        }
        else if (hasDigit)
        {
            result = "Angka saja";
        }

        Console.WriteLine(result);
    }

    static void QuestionFour()
    {
        Console.Write("Input: ");
        string input = Console.ReadLine();

        bool containsDecimal = false;

        foreach (char c in input)
        {
            if (c == ',' || c == '.')
            {
                containsDecimal = true;
                break;
            }
        }

        string result = containsDecimal ? "Mengandung angka koma" : "Tidak mengandung koma";
        Console.WriteLine(result);
    }
    static bool IsPrime(int n)
    {
        if (n <= 1)
        {
            return false;
        }

        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    static bool IsEmirp(int n)
    {
        int reversed = Reverse(n);

        return n != reversed && IsPrime(reversed);
    }

    static int Reverse(int n)
    {
        int reversed = 0;

        while (n > 0)
        {
            reversed = reversed * 10 + n % 10;
            n /= 10;
        }

        return reversed;
    }
}