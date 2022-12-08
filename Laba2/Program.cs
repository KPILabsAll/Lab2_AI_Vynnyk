﻿using Laba2;

var puzzle = new Puzzle();
var AllPuzles = new List<string[,]> { new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", " ", "8" } },
                                      new string[,] { { "1", "2", "3" }, { "4", " ", "6" }, { "7", "5", "8" } },
                                      new string[,] { { "1", "2", "3" }, { "4", "6", " " }, { "7", "5", "8" } },
                                      new string[,] { { "1", "2", " " }, { "4", "6", "3" }, { "7", "5", "8" } },
                                      new string[,] { { "1", " ", "2" }, { "4", "6", "3" }, { "7", "5", "8" } },
                                      new string[,] { { "1", "6", "2" }, { "4", " ", "3" }, { "7", "5", "8" } },
                                      new string[,] { { "1", "6", "2" }, { "4", "3", " " }, { "7", "5", "8" } },
                                      new string[,] { { "1", "2", "3" }, { "4", "5", " " }, { "7", "8", "6" } },
                                      new string[,] { { "1", "2", " " }, { "4", "5", "3" }, { "7", "8", "6" } },
                                      new string[,] { { "1", " ", "2" }, { "4", "5", "3" }, { "7", "8", "6" } },
                                      new string[,] { { " ", "1", "2" }, { "4", "5", "3" }, { "7", "8", "6" } },
                                      new string[,] { { "4", "1", "2" }, { " ", "5", "3" }, { "7", "8", "6" } },
                                      new string[,] { { "4", "1", "2" }, { "5", " ", "3" }, { "7", "8", "6" } },
                                      new string[,] { { "4", "1", "2" }, { "5", "8", "3" }, { "7", " ", "6" } },
                                      new string[,] { { "4", "1", "2" }, { "5", "8", "3" }, { "7", "6", " " } },
                                      new string[,] { { "4", "1", "2" }, { "5", "8", " " }, { "7", "6", "3" } },
                                      new string[,] { { "4", "1", " " }, { "5", "8", "2" }, { "7", "6", "3" } },
                                      new string[,] { { "4", " ", "1" }, { "5", "8", "2" }, { "7", "6", "3" } },
                                      new string[,] { { "4", "8", "1" }, { "5", " ", "2" }, { "7", "6", "3" } },
                                      new string[,] { { "4", "8", "1" }, { " ", "5", "2" }, { "7", "6", "3" } } };

var goal = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", " " } };

var Limits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
for (var i = 0; i < AllPuzles.Count; i++)
{

    Console.WriteLine((i + 1) + ": ");
    puzzle.LDFS(AllPuzles[i], goal, Limits[i]);
    Console.WriteLine();
    puzzle.AStar(AllPuzles[i], goal);
    Console.WriteLine();
}
//puzzle.LDFS(AllPuzles[6], Limits[6]);
//puzzle.AStar(AllPuzles[6]);