using System.Text;

namespace _02._Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //체인 메서드
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("안녕하시오").AppendLine("반갑소").AppendLine("");

            OrcBuilder warriorOrcBuilder = new OrcBuilder();
            warriorOrcBuilder.SetName("오크 전사");
            warriorOrcBuilder.SetHP(300);

            OrcBuilder archorOrcBuilder = new OrcBuilder();
            archorOrcBuilder.SetName("오크 궁수");
            archorOrcBuilder.SetWeapon("나무 활");
            archorOrcBuilder.SetLevel(10);

            OrcBuilder shamanOrcBuilder = new OrcBuilder();
            shamanOrcBuilder.SetName("오크 주술사");
            shamanOrcBuilder.SetWeapon("저주받은 지팡이");
            shamanOrcBuilder.SetArmor("의식복");
            shamanOrcBuilder.SetHP(50);

            OrcBuilder chiefShamanOrcBuilder = new OrcBuilder();
            chiefShamanOrcBuilder.SetName("오크 주술사 족장");
            chiefShamanOrcBuilder.SetWeapon("의식의 지팡이");
            chiefShamanOrcBuilder.SetArmor("족장의 옷");
            chiefShamanOrcBuilder.SetHP(100);


            Orc[] orcs = new Orc[9];

            //Orc orc1 = warriorOrcBuilder.Build();
            //Orc orc2 = warriorOrcBuilder.Build();
            //Orc orc3 = warriorOrcBuilder.Build();

            //Orc orc4 = archorOrcBuilder.Build();
            //Orc orc5 = archorOrcBuilder.Build();
            //Orc orc6 = archorOrcBuilder.Build();

            //Orc orc7 = shamanOrcBuilder.Build();
            //Orc orc8 = shamanOrcBuilder.Build();
            //Orc orc9 = shamanOrcBuilder.Build();
             orcs[0] = warriorOrcBuilder.Build();
             orcs[1] = warriorOrcBuilder.Build();
             orcs[2] = warriorOrcBuilder.Build();
                
             orcs[3] = archorOrcBuilder.Build();
             orcs[4] = archorOrcBuilder.Build();
             orcs[5] = archorOrcBuilder.Build();
                
             orcs[6] = shamanOrcBuilder.Build();
             orcs[7] = shamanOrcBuilder.Build();
             orcs[8] = shamanOrcBuilder.Build();

            OrcBuilder uniqueOrcBuilder = new OrcBuilder();
            uniqueOrcBuilder
                .SetName("희귀 오크")
                .SetWeapon("희귀 무기")
                .SetArmor("희귀 옷")
                .SetHP(50);

            // 스트링 빌더도 빌더다
            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine("안녕하세요");
            sb2.AppendLine("반갑습니다"); // 조립과정
            string str = sb2.ToString(); // 결과물

            // 서브웨이 : 빌더
            // 맥도날드 : 팩토리
        }
    }

    public class OrcBuilder
    {
        public string name;
        public string weapon;
        public string armor;
        public int level;
        public int hp;

        public OrcBuilder()
        {
            name = "오크";
            weapon = "몽둥이";
            armor = "천옷";
            level = 1;
            hp = 100;
        }

        public Orc Build()
        {
            Orc orc = new Orc();
            orc.name = name;
            orc.weapon = weapon;
            orc.armor = armor;
            orc.level = level;
            orc.hp = hp;

            return orc;
        }

        //public void SetName(string name)
        //{
        //    this.name = name;
        //}

        // 자기 자신을 결과로 주는 체인 메서드 방식, 기존처럼 쓰는것도 지장없음
        public OrcBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public OrcBuilder SetWeapon(string weapon)
        {
            this.weapon = weapon;
            return this;
        }

        public OrcBuilder SetArmor(string armor)
        {
            this.armor = armor;
            return this;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }

        public void SetHP(int hp)
        {
            this.hp = hp;
        }
    }

    public class Orc
    {
        public string name;
        public string weapon;
        public string armor;
        public int level;
        public int hp;
    }
}
