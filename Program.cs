namespace UocChungLonNhat
{
    class Runner
    {
        //      Dạng thường gặp nhất của trò chơi này gồm một bộ các đĩa kích thước khác nhau, 
        //      có lỗ ở giữa, nằm xuyên trên ba cái cọc.Bài toán đố bắt đầu bằng cách sắp xếp 
        //      các đĩa theo trật tự kích thước vào một cọc sao cho đĩa nhỏ nhất nằm trên cùng, 
        //      tức là tạo ra một dạng hình nón.Yêu cầu của trò chơi là di chuyển toàn bộ số đĩa 
        //      sang một cọc khác, tuân theo các quy tắc sau:

        //      Chỉ có 3 cột để di chuyển.
        //      Một lần chỉ được di chuyển một đĩa (không được di chuyển đĩa nằm giữa).
        //      Một đĩa chỉ có thể được đặt lên một đĩa lớn hơn(không nhất thiết hai đĩa này 
        //      phải có kích thước liền kề, tức là đĩa nhỏ nhất có thể nằm trên đĩa lớn nhất).

        public static void Main(string[] args)
        {
            HanoiTower();
        }
        public struct Disk
        {
            public Stack<int> stack;
            public string name;

            public Disk(string rodName)
            {
                stack = new Stack<int>();
                name = rodName;
            }
        }
        public static void HanoiTower()
        {
            Console.WriteLine("Input:");
            int input = int.Parse(Console.ReadLine());

            Disk A = new Disk("A");
            Disk B = new Disk("B");
            Disk C = new Disk("C");

            for (int i = input; i >= 1; i--)
            {
                A.stack.Push(i);
            }
            Console.WriteLine("Original stacks");
            PrintStack(ref A);
            PrintStack(ref C);
            PrintStack(ref B);
            //Logic1(input, ref A, ref C, ref B);
            Logic2(input, ref A, ref C, ref B);
            Console.WriteLine(total_step);
        }
        public static int total_step = 0;
        public static void Logic1(int n, ref Disk fromRod, ref Disk toRod, ref Disk midRod)
        {
            if (n == 0)
            {
                return;
            }

            Logic1(n - 1, ref fromRod, ref midRod, ref toRod);

            int disk = fromRod.stack.Pop();
            toRod.stack.Push(disk);
            total_step++;
            Console.WriteLine($"Move disk D{disk}: {fromRod.name} -> {toRod.name}");
            Console.WriteLine($"Rod {fromRod.name}: {fromRod.stack.Count()} Rod {midRod.name}: {midRod.stack.Count()} Rod {toRod.name}: {toRod.stack.Count()}");
            Logic1(n - 1, ref midRod, ref toRod, ref fromRod);
        }
        public static void Logic2(int n, ref Disk fromRod, ref Disk toRod, ref Disk midRod)
        {
            if (n == 0)
            {
                return;
            }

            Logic2(n - 2, ref fromRod, ref midRod, ref toRod);

            if (fromRod.stack.Count >= 2)
            {
                int disk_1 = fromRod.stack.Pop();
                int disk_2 = fromRod.stack.Pop();
                toRod.stack.Push(disk_2);
                toRod.stack.Push(disk_1);
                total_step++;
                Console.WriteLine($"Move disk D{disk_1} and D{disk_2}: {fromRod.name} -> {toRod.name}");
                PrintStack(ref fromRod);
                PrintStack(ref toRod);
                PrintStack(ref midRod);
            }
            else if (fromRod.stack.Count == 1)
            {
                int disk = fromRod.stack.Pop();
                toRod.stack.Push(disk);
                total_step++;
                Console.WriteLine($"Move disk D{disk}: {fromRod.name} -> {toRod.name}");
                PrintStack(ref fromRod);
                PrintStack(ref toRod);
                PrintStack(ref midRod);
            }
            Console.WriteLine($"Rod {fromRod.name}: {fromRod.stack.Count()} Rod {midRod.name}: {midRod.stack.Count()} Rod {toRod.name}: {toRod.stack.Count()}");
            Logic2(n - 2, ref midRod, ref toRod, ref fromRod);
        }
        public static void PrintStack(ref readonly Disk disk)
        {
            Console.WriteLine($"Disk: {disk.name}");
            Console.Write("[");
            foreach (int i in disk.stack)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine("]");
        }

    }
}
