using System;
using System.Linq;

// http://bgcoder.com/Contests/Practice/Index/132#0
class BinaryPasswords
{
    static void Main()
    {
        Console.WriteLine(1L << Console.ReadLine().Count(c => c == '*'));
    }
}
