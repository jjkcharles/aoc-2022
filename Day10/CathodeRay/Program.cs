using System;

namespace Packing
{

    class PackingMain
    {

        public static void Main()
        {
            var input = GetInput();
            List<string> lstInput = input.Split("\n").ToList();
            var dictCaptures = new Dictionary<int, int>();

            List<int> lstRegX = new List<int>();
            int startRegX = 1;
            int cycle = 0;
            int currentVal = 0;
            foreach(var str in lstInput)
            {
                //Console.WriteLine(cycle);
                if(str.Trim().StartsWith("noop"))
                {
                    lstRegX.Add(cycle==0?startRegX:currentVal+lstRegX[cycle-1]);
                    currentVal = 0;
                    cycle++;
                    Console.WriteLine("noop {0}:{1}", cycle, lstRegX.Last());
                }
                else
                {
                    lstRegX.Add(cycle==0?startRegX:currentVal+lstRegX[cycle-1]);
                    currentVal = 0;
                    cycle++;
                    Console.WriteLine("noop {0}:{1}", cycle, lstRegX.Last());
                    lstRegX.Add(lstRegX[cycle-1]+currentVal);
                    cycle++;
                    Console.WriteLine("noop {0}:{1}", cycle, lstRegX.Last());
                    currentVal = int.Parse(str.Trim().Replace("addx ",""));
                }
            }
            lstRegX.Add(lstRegX[cycle-1]+currentVal);
            cycle++;
            Console.WriteLine("noop {0}:{1}", cycle, lstRegX.Last());

            dictCaptures.Add(20,lstRegX[20-1]);
            dictCaptures.Add(60,lstRegX[60-1]);
            dictCaptures.Add(100,lstRegX[100-1]);
            dictCaptures.Add(140,lstRegX[140-1]);
            dictCaptures.Add(180,lstRegX[180-1]);
            dictCaptures.Add(220,lstRegX[220-1]);

            foreach(var i in dictCaptures)
            {
                Console.WriteLine("{0}:{1}", i.Key, i.Value);
            }

            Console.WriteLine("Answer for part1 is {0}", dictCaptures.Sum(x=>x.Key * x.Value));

            Console.WriteLine("\nAnswer for part2 is:");
            for(int i=0;i<6;i++)
            {
                for(int j=0;j<40;j++)
                {
                    if( j >= lstRegX[(i*40)+j]-1 && j <= lstRegX[(i*40)+j]+1 )
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine("");
            }
        }

        private static string GetInput()
        {
            return @"noop
addx 5
addx -2
noop
noop
addx 7
addx 15
addx -14
addx 2
addx 7
noop
addx -2
noop
addx 3
addx 4
noop
noop
addx 5
noop
noop
addx 1
addx 2
addx 5
addx -40
noop
addx 5
addx 2
addx 15
noop
addx -10
addx 3
noop
addx 2
addx -15
addx 20
addx -2
addx 2
addx 5
addx 3
addx -2
noop
noop
noop
addx 5
addx 2
addx 5
addx -38
addx 3
noop
addx 2
addx 5
noop
noop
addx -2
addx 5
addx 2
addx -2
noop
addx 7
noop
addx 10
addx -5
noop
noop
noop
addx -15
addx 22
addx 3
noop
noop
addx 2
addx -37
noop
noop
addx 13
addx -10
noop
addx -5
addx 10
addx 5
addx 2
addx -6
addx 11
addx -2
addx 2
addx 5
addx 3
noop
addx 3
addx -2
noop
addx 6
addx -22
addx 23
addx -38
noop
addx 7
noop
addx 5
noop
noop
noop
addx 9
addx -8
addx 2
addx 7
noop
noop
addx 2
addx -4
addx 5
addx 5
addx 2
addx -26
addx 31
noop
addx 3
noop
addx -40
addx 7
noop
noop
noop
noop
addx 2
addx 4
noop
addx -1
addx 5
noop
addx 1
noop
addx 2
addx 5
addx 2
noop
noop
noop
addx 5
addx 1
noop
addx 4
addx 3
noop
addx -24
noop";
        }
    }
}
