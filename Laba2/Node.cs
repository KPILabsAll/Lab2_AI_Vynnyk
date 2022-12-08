namespace Laba2
{
    internal class Node : ICloneable
    {
        public string[,] Puzzle { get; set; }
        public int Level { get; set; }
        public int ValueF { get; set; }
        public Direction Direction { get; set; }

        public Node() { }

        public Node(string[,] puzzle, int level = 0, int valueF = 0, Direction direction = Direction.Default)
        {
            Puzzle = puzzle;
            Level = level;
            ValueF = valueF;
            Direction = direction;
        }

        private static (int, int) Find(string[,] puz, char symbol)
        {
            for (var i = 0; i < puz.GetLength(0); i++)
            {
                for (var j = 0; j < puz.GetLength(1); j++)
                {
                    if (puz[i, j] == symbol.ToString())
                    {
                        return (i, j);
                    }
                }
            }
            return (4, 4);
        }
        public List<Node> CreateNewNode()
        {
            (int x, int y) xy = Find(Puzzle, ' ');
            var cords = new List<(int x, int y)>()
            {
                (xy.x, xy.y - 1),
                (xy.x, xy.y + 1),
                (xy.x - 1, xy.y),
                (xy.x + 1, xy.y)
            };
            var nodes = new List<Node>();
            foreach (var i in cords)
            {
                var newPuzzle = Move(Puzzle, xy.x, xy.y, i.x, i.y);
                if (newPuzzle != null)
                {
                    var newNode = new Node(newPuzzle, Level + 1);
                    nodes.Add(newNode);
                }
                else
                {
                    nodes.Add(null);
                }
            }
            return nodes;
        }

        public static string[,]? Move(string[,] puz, int x1, int y1, int x2, int y2)
        {
            if (x2 >= 0 && x2 < puz.GetLength(0) && y2 >= 0 && y2 < puz.GetLength(1))
            {
                var cloned = (string[,])puz.Clone();
                (cloned[x2, y2], cloned[x1, y1]) = (cloned[x1, y1], cloned[x2, y2]);
                return cloned;
            }
            else
            {
                return null;
            }
        }

        public void Print()
        {
            for (var i = 0; i < Puzzle.GetLength(0); i++)
            {
                for (var j = 0; j < Puzzle.GetLength(1); j++)
                {
                    Console.Write(Puzzle[i, j] + ' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public bool Equals(string[,] goal)
        {
            return  Puzzle.Rank == goal.Rank &&
                    Enumerable.Range(0, Puzzle.Rank).All(dimension => Puzzle.GetLength(dimension) == goal.GetLength(dimension)) &&
                    Puzzle.Cast<string>().SequenceEqual(goal.Cast<string>());
        }
    }
}
