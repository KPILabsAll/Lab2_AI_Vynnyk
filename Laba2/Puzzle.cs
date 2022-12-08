using System.Diagnostics;

namespace Laba2
{
    internal class Puzzle
    {
        public int Size { get; set; }
        public List<Node> Open { get; set; } = new List<Node>();
        public List<Node> Closed { get; set; } = new List<Node>();
        public Stack<Node> Stack { get; set; } = new Stack<Node>();

        public Puzzle(int size = 3)
        {
            Size = size;
        }


        public void LDFS(string[,] enter, string[,] goal, int limit)
        {
            var watch = new Stopwatch();
            watch.Start();
            var start = new Node(enter, 0);
            Stack.Push(start);
            start.Print();
            var maxCount = 0;
            var count = 0;
            while (true)
            {
                if (Stack.Count == 0)
                {
                    Console.WriteLine("Not found");
                    break;
                }
                if(Stack.Count >= maxCount)
                    maxCount = Stack.Count;
                var puz = Stack.Pop();
                //puz.Print();
                if (puz.Equals(goal))
                {
                    watch.Stop();
                    Console.WriteLine("LDFS:");
                    Console.WriteLine("Time:" + watch.Elapsed.Milliseconds + " ms");
                    Console.WriteLine("Generated nodes:" + count);
                    Console.WriteLine("Max generated nodes:" + maxCount);
                    break;
                }
                if (puz.Level != limit)
                {
                    var cloned = (Node)puz.Clone();
                    //up
                    if (puz.Direction != Direction.Down)
                    {
                        var up = cloned.CreateNewNode()[2];
                        if (up != null)
                        {
                            up.Direction = Direction.Up;
                            Stack.Push(up);
                            count++;
                        }
                    }
                    //left
                    if (puz.Direction != Direction.Right)
                    {
                        var left = cloned.CreateNewNode()[0];
                        if (left != null)
                        {
                            left.Direction = Direction.Left;
                            Stack.Push(left);
                            count++;
                        }
                    }
                    //down
                    if (puz.Direction != Direction.Up)
                    {
                        var down = cloned.CreateNewNode()[3];
                        if (down != null)
                        {
                            down.Direction = Direction.Down;
                            Stack.Push(down);
                            count++;
                        }
                    }
                    //right
                    if (puz.Direction != Direction.Left)
                    {
                        var right = cloned.CreateNewNode()[1];
                        if (right != null)
                        {
                            right.Direction = Direction.Right;
                            Stack.Push(right);
                            count++;
                        }
                    }
                }
            }
        }
        public void AStar(string[,] enter, string[,] goal)
        {
            var watch = new Stopwatch();
            watch.Start();
            var start = new Node(enter, 0);
            start.ValueF = F(start, goal);
            Open.Add(start);
            var maxCount = 0;
            var count = 0;
            while (true)
            {
                if (Open.Count >= maxCount)
                    maxCount = Open.Count;
                var puz = Open[0];
                Open.RemoveAt(0);
                //puz.Print();
                if (puz.Equals(goal))
                {
                    watch.Stop();
                    Console.WriteLine("AStar:");
                    Console.WriteLine("Time:" + watch.ElapsedMilliseconds + " ms");
                    Console.WriteLine("Generated nodes:" + count);
                    Console.WriteLine("Max generated nodes:" + maxCount);
                    Open.Clear();
                    break;
                }
                foreach (var i in puz.CreateNewNode())
                {
                    if (i is not null && !Closed.Contains(i))
                    {
                        i.ValueF = F(i, goal);
                        Open.Add(i);
                        count++;
                    }
                }
                Closed.Add(puz);
                Open = new List<Node>(Open.OrderBy(o => o.ValueF));
            }
        }
        public int H(string[,] start, string[,] goal)
        {
            var temp = 0;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (start[i, j] != goal[i, j] && start[i, j] != " ")
                    {
                        temp++;
                    }
                }
            }
            return temp;
        }
        public int F(Node start, string[,] goal)
        {
            return H(start.Puzzle, goal) + start.Level;
        }
    }
}
