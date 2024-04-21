using System.Text;

namespace Generate_W_Q_R
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.OutputEncoding = Encoding.UTF8;
            string input = "1 2 5 16 30 86 180 483";

            //List<int> W = ConvertStringToList(input);
            List<int> W = GenerateSuperincreasingSequence(8).ToList();
            int q = rand.Next(W.Sum() + 1, W.Sum() * 2 + 1);
            int r = GenerateCoprime(q, rand);
            List<int> B = CalculateSequenceB(W, r, q);

            Print_W(W);
            Console.WriteLine("q = " +  q);
            Console.WriteLine("r = " +  r);
            Print_Private_Key(W, q, r);
            Print_Public_Key(B);

        }

        static int[] GenerateSuperincreasingSequence(int n)
        {
            Random rand = new Random();
            int[] sequence = new int[n];

            sequence[0] = rand.Next(1, 10); 

            for (int i = 1; i < n; i++)
                sequence[i] = sequence[i - 1] + rand.Next(sequence[i - 1] + 1, sequence[i - 1] * 2 + 1);
            
            return sequence;
        }
        static void Print_W(List<int> W)
        {
            Console.Write("W:  ");
            for (int i = 0; i < W.Count; i++)
            {
                Console.Write(W[i] + " ");
            }
            Console.WriteLine();
        }
        static void Print_Private_Key(List<int> W, int q, int r)
        {
            Console.Write("Private Key:   ");
            for (int i = 0; i < W.Count; i++)
            {
                Console.Write(W[i] + " ");
            }

            Console.WriteLine(q + " " + r);
        }


        static void Print_Public_Key(List<int> B)
        {
            Console.Write("Public Key:    ");
            for (int i = 0; i < B.Count; i++)
            {
                Console.Write(B[i] + " ");
            }
        }


        static List<int> ConvertStringToList(string input)
        {
            string[] numberStrings = input.Split(' ');
            List<int> numbers = new List<int>();

            foreach (string numberString in numberStrings)
            {
                if (!int.TryParse(numberString, out int number)) throw new FormatException();
                numbers.Add(number);
            }
            return numbers;
        }

        static int GenerateCoprime(int q, Random rand)
        {
            int r;
            do
            {
                r = rand.Next(2, q); // Randomly generate r between 2 and q-1
            }
            while (GreatestCommonDivisor(r, q) != 1); // Repeat until r and q are coprime

            return r;
        }

        static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static List<int> CalculateSequenceB(List<int> W, int r, int q)
        {
            List<int> B = new List<int>();

            foreach (int wi in W)
            {
                int bi = (r * wi) % q;
                B.Add(bi);
            }

            return B;
        }
    }
}
