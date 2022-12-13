using System.Numerics;

namespace Monkey
{
    class Game
    {
        private ulong WorryLevelReduceFactor { get; set; }
        private ulong MaxValue {get;set;} 
         public Game(string input, ulong wLFactor)
         {
            Monkies = new List<Monkey>();
            ParseInput(input);
            WorryLevelReduceFactor = wLFactor;
         }

         public List<Monkey> Monkies {get;set;}

         public void Start(int maxRounds = 20)
         {
            int round = 0;

            MaxValue = Monkies.Select(x=>(ulong)x.Divisor).Aggregate((x,y)=>x*y);
            Console.WriteLine(WorryLevelReduceFactor);

            for(round=0;round<maxRounds;round++)
            {
                foreach(var monkey in Monkies)
                {
                    while(monkey.Items.Any())
                    {
                        Inspect(monkey);
                        monkey.InspectCount++;
                    }
                }

                //Console.WriteLine("End Round {0}", round);
                //foreach(var m in Monkies) Console.WriteLine(m);
            }
         }

         private void Inspect(Monkey monkey)
         {
            var item = monkey.Items.Dequeue();
            var val = monkey.Operation(item);

            if(WorryLevelReduceFactor!=1) val = val/WorryLevelReduceFactor;
            val = val % MaxValue;

            int toMonkeyId = monkey.Tester(val)?monkey.TrueMonkey:monkey.FalseMonkey;
            //val = val % MaxValue;

            var toMonkey = Monkies.Where(x=>x.Id==toMonkeyId).First();
            
            toMonkey.Items.Enqueue(val);

            /*if(monkey.Id==1) {
                Console.WriteLine("Monkey Id {0} inspecting item {1} passing it as {2} to Monkey {3}", 
                    monkey.Id, item, val, toMonkeyId);
            }*/
         }

         private void ParseInput(string input)
         {
            List<string> lstInput = input.Split("\n").ToList();

            Monkey currentMonkey = null;
            foreach(var line in lstInput)
            {
                if(line.StartsWith("Monkey "))
                {
                    currentMonkey = new Monkey(ParseMonkeyId(line));
                    Monkies.Add(currentMonkey);
                }
                else if(line.Trim().StartsWith("Starting items:"))
                {
                    var list = ParseStartingItems(line.Trim().Replace("Starting items: ",""));
                    list.ForEach(x=>currentMonkey.Items.Enqueue(x));
                }
                else if(line.Trim().StartsWith("Test: divisible by "))
                {
                    int val = int.Parse(line.Trim().Replace("Test: divisible by ",""));
                    currentMonkey.Tester = (a)=>a%(ulong)val==0;
                    currentMonkey.Divisor = val;
                }
                else if(line.Trim().StartsWith("If true: throw to monkey "))
                {
                    int val = int.Parse(line.Trim().Replace("If true: throw to monkey ",""));
                    currentMonkey.TrueMonkey = val;
                }
                else if(line.Trim().StartsWith("If false: throw to monkey "))
                {
                    int val = int.Parse(line.Trim().Replace("If false: throw to monkey ",""));
                    currentMonkey.FalseMonkey = val;
                }
                else if(line.Trim().StartsWith("Operation: "))
                {
                    currentMonkey.Operation = ParseOperation(line.Trim().Replace("Operation: new = ","").Replace(" ",""));
                }

            }
         }

         private int ParseMonkeyId(string str)
         {
            str = str.Trim().Replace("Monkey ", "");
            str = str.Replace(":", "");
            return int.Parse(str);
         }

         private List<ulong> ParseStartingItems(string str)
         {
            return str.Split(",").Select(x=>ulong.Parse(x.Trim())).ToList();
         }
         private Func<ulong,ulong> ParseOperation(string str)
         {
            var tokens = str.Split(new char[]{'+','*'});
            char oper = str.Contains("+")?'+':'*';
            ulong? token1 = null, token2 = null;
            if(!tokens[0].Equals("old")) token1 = ulong.Parse(tokens[0]);
            if(!tokens[1].Equals("old")) token2 = ulong.Parse(tokens[1]);
            if(oper == '+')
            {
                return (x)=>(token1??x)+(token2??x);
            }
            return (x)=>(token1??x)*(token2??x); 
         }
    }

    class Monkey
    {
        public Monkey(int id)
        {
            Id = id;
            Items = new Queue<ulong>();
            InspectCount=0;
        }
        public int Id {get;set;}
        public Queue<ulong> Items{get;set;}
        public Func<ulong, ulong> Operation {get;set;}
        public Func<ulong, bool> Tester {get;set;}
        public int TrueMonkey {get;set;}
        public int FalseMonkey {get;set;}
        public int InspectCount {get;set;}
        public int Divisor {get;set;}

        public override string ToString()
        {
            return string.Format("Id:{0}; ItemsCount: {1}; InspectCount: {2}", Id, Items.Count, InspectCount);
        }
    }
}