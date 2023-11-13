using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace dungeon
{
    internal class Program
    {
        private static Character player;

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            String name = null;

            if(name ==  null)
            {
                Console.WriteLine("처음 오시는 분이군요! 환영합니다.");
                Console.WriteLine("이름을 불러주세요 : ");

                name = Console.ReadLine();    
            }

            // 캐릭터 정보 세팅
            player = new Character(name, "초보자", 1, 10, 5, 100, 1500);
            // 아이템 정보 세팅
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 4);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    DisplayInventory();
                    // 작업해보기
                    break;
                case 3:
                    DisplayShop(); //상점
                    break;
                case 4:
                    DisplayDungeon();
                    break;
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보르 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        static void DisplayInventory()
        {
            Console.WriteLine();
            foreach (var item in player.Inventory)
            {
                Console.WriteLine(item);
            }
            DisplayGameIntro();
        }
        static void DisplayShop()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("상점에 오신걸 환영합니다. 필요한 무기 품목을 고르세요");
            Console.WriteLine("1. 무기");
            Console.WriteLine("2. 방어구");
            Console.WriteLine("3. 소모품");
            Console.WriteLine("4. 기타");

            int input = CheckValidInput(1, 4);

            switch (input)
            {
                case 1:
                    Console.WriteLine("1. 초보자검");
                    Console.WriteLine("2. 철 검");
                    Console.WriteLine("3. 미완성 검");
                    Console.WriteLine("4. 상점주인의 부억칼");
                    break;
                case 2:
                    Console.WriteLine("1.초보자 갑옷");
                    Console.WriteLine("2.경비병의 갑옷");
                    Console.WriteLine("3. 미완성의 갑옷");
                    Console.WriteLine("4. 하벨의 갑옷");
                    break;
                case 3:
                    Console.WriteLine("1.HP물약");
                    Console.WriteLine("2.엘릭서");
                    Console.WriteLine("3.증강제");
                    break;
                case 4:
                    Console.WriteLine("4. 던전 입구 열쇠");
                    break;
            }

        }
        static void DisplayDungeon()
        {
            
            int stage = 1;
            Console.Clear();
            Console.WriteLine("이름없는 던전에 오신걸 환영합니다.");
            Console.WriteLine("한번 들어가면 클리어하거나 죽을때까지 나올수 없습니다.");
            Console.WriteLine("들어오시겠습니까? Y/N");



            while(true)
            {
                Console.WriteLine($"{stage}층 입니다.");
            }
        }

        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        static char CheckValidYESNO()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == 'Y' || input == 'N')
                {
                    return input;
                }
                else
                {
                    Console.Write("잘못된 입력입니다.");
                }
                
            }
    }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public List<string> Inventory = new List<string>();

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}