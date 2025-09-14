using System.Collections.Generic;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bai 1: Tim so lon nhat trong 3 so: 10, 37, 12 ");
        int max1 = Find_the_largest_number(10, 37, 12);
        Console.WriteLine("So lon nhat la: " + max1+"\n");
        Console.Write("Nhap chuoi cac tham so de tim so lon nhat (cac tham so cach nhau bang 1 dau cach): ");
        string doc_chuoi = Console.ReadLine(); // doc chuoi
        string[] tach_chuoi = doc_chuoi.Split(' ');// tach chuoi bang dau cach
        int[] numbers = new int[tach_chuoi.Length]; //mang de luu cac so
        for (int i = 0; i < tach_chuoi.Length; i++)
        {
            if (!int.TryParse(tach_chuoi[i], out numbers[i]))
            {
                Console.WriteLine("Chuoi ban nhap khong hop le!\nChu y cac so cach nhau bang 1 dau cach.");
                return;
            }
            numbers[i] = int.Parse(tach_chuoi[i]); //chuyen chuoi thanh so nguyen
        }
        int max2 = Improve_version_Find_the_largest_number(numbers);
        Console.WriteLine("So lon nhat la: " + max2+"\n");
        Console.WriteLine("Bai 2: Tinh giai thua cua 1 so nguyen khong am");
        Console.Write("Nhap so: ");
        if (int.TryParse((Console.ReadLine()), out int giai_thua))
        {
            if (giai_thua < 0)
            {
                Console.WriteLine("Vui long nhap lai so lon hon hoac bang 0!!!");
                return;
            }
        }
        else
        {
            Console.WriteLine("Vui long nhap vao so");
            return;
        }
        long factorial = factorial_of_a_number(giai_thua);
        Console.WriteLine($" {giai_thua}! = " + factorial);
        Console.WriteLine("\n3.Write a C# function that takes a number as a parameter and checks whether the number is prime or not.");
        Console.Write("Kiem tra so 3:");
        Console.WriteLine(is_prime(3));
        Console.WriteLine("\nBai 4: Write a C# function to print");
        Console.Write("\n1. Nhap mot so: ");
        int so = int.Parse(Console.ReadLine());
        Console.WriteLine("\nCac so nguyen to nho hon " + so);
        all_prime_numbers_that_less_than_a_number(so);
        Console.WriteLine("\n"+so + " so nguyen to dau tien");
        the_first_N_prime_numbers(so);
        Console.WriteLine("\nWrite a C# function to check whether a number is \"Perfect\" or not. Then print all perfect number that less than 1000.");
        check_whether_a_number_is_Perfect_or_not(so);
        Console.WriteLine("\nTat ca cac so hoan hao nho hon 1000:");
        for (int i = 1; i < 1000; i++)
        {
            if (is_perfect(i))
            {
                Console.Write(i + ", ");
            }
        }
        Console.WriteLine("\n\nWrite a C# function to check whether a string is a pangram or not.");
        Console.Write("Kiem tra chuoi \"The quick brown fox jumps over the lazy cat\":");
        string s = "The quick brown fox jumps over the lazy cat";
        var b = is_pangram(s);
        Console.WriteLine(b);
    }
    public static int Find_the_largest_number(int a, int b, int c)
    {
        int max1 = a;
        if (b > max1)
        {
            max1 = b;
        }
        else if (c > max1)
        {
            max1 = c;
        }
        return max1;
    }
    public static int Improve_version_Find_the_largest_number(params int[] numbers)
    {
        int max2 = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max2)
            {
                max2 = numbers[i];
            }
        }
        return max2;
    }
    public static long factorial_of_a_number(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    public static bool is_prime(long n)
    {
        if (n < 2) return false;
        for (long i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    public static void all_prime_numbers_that_less_than_a_number(int a)
    {
        for (int i = 2; i < a; i++)
        {
            if (is_prime(i))
            {
                Console.Write(i + ", ");
            }
        }
        Console.WriteLine();
    }
    public static void the_first_N_prime_numbers(int n)
    {
        long so = 2;
        int dem = 0;
        while (dem < n)
        {
            if (is_prime(so))
            {
                dem++;
                Console.Write(so + ", ");
            }
            so++;
        }
        Console.WriteLine( );
    }
    public static void check_whether_a_number_is_Perfect_or_not(int n)
    {
         if (is_perfect(n))
            {
                Console.WriteLine(n + " la so hoan hao.");
            }
            else
            {
                Console.WriteLine(n + " khong phai la so hoan hao.");
            }
    }

    public static bool is_perfect(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        int sum = 1;
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                sum += i;
                if (i * i != n)
                {
                    sum += n / i;
                }
            }
        }
        return sum == n;

    }
    public static bool is_pangram(string s)
    {
        string alp = "abcdefghijklmnopqrstuvwxyz";
        s = s.ToLower();
        
        foreach (char c in alp)
        {
            if (!s.Contains(c))
            {
                return false;
            }
        }
        return true;
    }
}