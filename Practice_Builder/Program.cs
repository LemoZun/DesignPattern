using System.Reflection.PortableExecutable;

namespace Practice_Builder
{
    public enum Skill { 장풍, 승룡, 커잡, 필살기, 없음 }
    public enum Type { Standard, Grappler, Power }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CharacterBuilder standardBuilder = new CharacterBuilder();
            standardBuilder
                .SetName("RYU")
                .SetAttackPoint(50)
                .SetdefensePoint(50)
                .SetSkill(Type.Standard)
                .SetHP(100);
            CharacterBuilder grapplerBuilder = new CharacterBuilder();
            grapplerBuilder
                .SetName("Zangief")
                .SetAttackPoint(80)
                .SetdefensePoint(80)
                .SetSkill(Type.Grappler)
                .SetHP(120);
            CharacterBuilder powerBuilder = new CharacterBuilder();
            powerBuilder
                .SetName("Sol Badguy")
                .SetAttackPoint (80)
                .SetdefensePoint(30)
                .SetSkill(Type.Power)
                .SetHP (100);
            CharacterBuilder noobBuilder = new CharacterBuilder();

            Character[] characters = new Character[5];

            characters[0] = standardBuilder.Build();
            characters[1] = grapplerBuilder.Build();
            characters[2] = powerBuilder.Build();
            characters[3] = noobBuilder.Build();

            noobBuilder
                .SetName("조금 성장한 훈련생")
                .SetAttackPoint(20)
                .SetdefensePoint(20)
                .SetHP(60);
            characters[4] = noobBuilder.Build();

            int count = 1;
            foreach(Character character in characters)
            {

                Console.WriteLine($"{count++}. {character.name}");
                Console.WriteLine($"공격력 : {character.attackPoint}");
                Console.WriteLine($"방어력 : {character.defensePoint} " +
                    $"\n체력 : {character.hp}");
                Console.WriteLine("보유한 스킬 목록");
                for (int i = 0; i < character.skills.Length; i++)
                {
                    Console.Write($"{character.skills[i]} ");
                }
                Console.WriteLine("\n");                
            }
        }

        public class CharacterBuilder
        {
            public string name;
            public int attackPoint;
            public int defensePoint;
            public int hp;
            public Skill[] skills;

            public CharacterBuilder()
            {
                name = "훈련생";
                attackPoint = 10;
                defensePoint = 10;
                hp = 50;
                skills = new Skill[4];
                skills[0] = Skill.없음;
                skills[1] = Skill.없음;
                skills[2] = Skill.없음;
                skills[3] = Skill.없음;
            }

            public Character Build()
            {
                Character character = new Character();
                character.name = name;
                character.attackPoint = attackPoint;
                character.defensePoint = defensePoint;
                character.hp = hp;
                character.skills = skills;
                return character;
            }

            public CharacterBuilder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public CharacterBuilder SetAttackPoint(int attackPoint)
            {
                this.attackPoint = attackPoint;
                return this;
            }
            public CharacterBuilder SetdefensePoint(int defensePoint)
            {
                this.defensePoint = defensePoint;
                return this;
            }
            public CharacterBuilder SetHP(int hp)
            {
                this.hp = hp;
                return this;
            }
            public CharacterBuilder SetSkill(Type type)
            {
                switch (type)
                {
                    case Type.Standard:
                        skills[0] = Skill.장풍;
                        skills[1] = Skill.승룡;
                        skills[2] = Skill.없음;
                        skills[3] = Skill.필살기;
                        return this;
                    case Type.Grappler:
                        skills[0] = Skill.없음;
                        skills[1] = Skill.없음;
                        skills[2] = Skill.커잡;
                        skills[3] = Skill.필살기;
                        return this;
                    case Type.Power:
                        skills[0] = Skill.없음;
                        skills[1] = Skill.승룡;
                        skills[2] = Skill.없음;
                        skills[3] = Skill.필살기;
                        return this;
                    default:
                        Console.WriteLine("잘못된 타입 입력");
                        return null;
                }
            }           
        }
        public class Character
        {
            public string name;
            public int attackPoint;
            public int defensePoint;
            public int hp;
            public Skill[] skills;

        }
    }
}