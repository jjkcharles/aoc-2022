﻿using System;
using System.Numerics;

namespace Monkey
{
    class MonkeyMain
    {

        public static void Main()
        {
            Solve(1, 20, 3);

            Solve(2, 10000, 1);
        }

        private static void Solve(int part, int maxRounds, ulong WorryLevelFactor)
        {
            var input = GetInput("prod");

            var game = new Game(input, WorryLevelFactor);

            //foreach(var m in game.Monkies) Console.WriteLine(m);

            game.Start(maxRounds);

            var sortedMonkeis = game.Monkies.OrderByDescending(x => x.InspectCount).ToList();

            ulong monkeyB = (ulong)sortedMonkeis[0].InspectCount * (ulong)sortedMonkeis[1].InspectCount;

            Console.WriteLine("Part {0} done:", part);
            foreach(var m in sortedMonkeis) Console.WriteLine(m);

            Console.WriteLine("The monkey business Part{0} is {1}", part, monkeyB);
        }

        private static string GetInput(string type)
        {
            return type.Equals("test")?@"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1"
    :@"Monkey 0:
  Starting items: 50, 70, 89, 75, 66, 66
  Operation: new = old * 5
  Test: divisible by 2
    If true: throw to monkey 2
    If false: throw to monkey 1

Monkey 1:
  Starting items: 85
  Operation: new = old * old
  Test: divisible by 7
    If true: throw to monkey 3
    If false: throw to monkey 6

Monkey 2:
  Starting items: 66, 51, 71, 76, 58, 55, 58, 60
  Operation: new = old + 1
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 79, 52, 55, 51
  Operation: new = old + 6
  Test: divisible by 3
    If true: throw to monkey 6
    If false: throw to monkey 4

Monkey 4:
  Starting items: 69, 92
  Operation: new = old * 17
  Test: divisible by 19
    If true: throw to monkey 7
    If false: throw to monkey 5

Monkey 5:
  Starting items: 71, 76, 73, 98, 67, 79, 99
  Operation: new = old + 8
  Test: divisible by 5
    If true: throw to monkey 0
    If false: throw to monkey 2

Monkey 6:
  Starting items: 82, 76, 69, 69, 57
  Operation: new = old + 7
  Test: divisible by 11
    If true: throw to monkey 7
    If false: throw to monkey 4

Monkey 7:
  Starting items: 65, 79, 86
  Operation: new = old + 5
  Test: divisible by 17
    If true: throw to monkey 5
    If false: throw to monkey 0";
        }
    }
}