using System.ComponentModel;
using static Practice_Factory.Program;

namespace Practice_Factory
{
    internal class Program
    {
        public enum ItemType {Potion,Weapon,Armor,Food }
        static void Main(string[] args)
        {
            Item[] items = new Item[4];
            Item potion1 = ItemFactory.Create(ItemType.Potion);
            Item weapon1 = ItemFactory.Create(ItemType.Weapon);
            Item armor1 = ItemFactory.Create(ItemType.Armor);
            Item food1 = ItemFactory.Create(ItemType.Food);

            items[0] = potion1;
            items[1] = weapon1;
            items[2] = armor1;
            items[3] = food1;
            
            foreach (Item item in items)
            {
                Console.WriteLine($"이름 : {item.name}");
                Console.WriteLine($"무게 : {item.weight}");   
                // 다른 요소도 출력하고싶으면 for문과 if문을 같이 써야하나
            }
        }

        public class ItemFactory
        {
            public static Item Create(ItemType type)
            {
                if (type == ItemType.Potion)
                {
                    Potion potion = new Potion();
                    potion.name = "포션";
                    potion.weight = 3;
                    potion.amountOfRecovery = 30;
                    return potion;
                }
                else if (type == ItemType.Weapon)
                {
                    Weapon weapon = new Weapon();
                    weapon.name = "부러진 직검";
                    weapon.weight = 10;
                    weapon.AttackPoint = 30;
                    return weapon;
                }
                else if (type == ItemType.Armor)
                {
                    Armor armor = new Armor();
                    armor.name = "아스토라 갑옷";
                    armor.weight = 40;
                    armor.defensePoint = 20;
                    return armor;
                }
                else if (type == ItemType.Food)
                {
                    Food food = new Food(); //이래도 별 상관 없나
                    return food;                        
                }
                else
                {
                    Console.WriteLine("없는 아이템입니다.");
                    return null;
                }
            }
        }

        public class Item
        {
            public string name;
            public int weight;
        }

        public class Potion : Item
        {
            public int amountOfRecovery;
        }

        public class Weapon : Item
        {
            private int attackPoint;

            public int AttackPoint
            {
                get { return attackPoint; }
                set { attackPoint = value; }
            }            
        }

        public class Armor : Item
        {
            public int defensePoint;
        }

        public class Food : Item
        {
            public int statBonus;
            public Food()
            {
                this.name = "전갈 조림";
                this.weight = 5;
                this.statBonus = 20;
            }            
        }
    }
}
