using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static DesignPattern.Item;

namespace DesignPattern
{
    // 상속을 통해서만 아이템 종류를 양산하면
    // 1. 유형별로 클래스가 너무 많이 생김
    // 2. 각각의 클래스마다 가져야 하는 값이나 구현방법들을 찾아야함

    // 상속이 아닌 다형성확보를 통해 만드는 경우
    // 1. 매번 생성마다 각각의 필드를 지정해줘야함
    // 2. 다른 값을 집어넣어서 상이한 데이터를 가지는 같은 유형의 객체가 있을 수 있다.
    internal class Program
    {
        static void Main(string[] args)
        {
            Item potion1 = ItemFactory.Instantiate("포션");
            Item potion2 = ItemFactory.Instantiate("큰 포션");
        }
    }

    public class ItemFactory

        //아이템 테이블 (단일책임)
        // 견본품   (프로토타입)
        // 추가과정 (팩토리메서드)
        // 제작부품 (빌더)
    {
        //public static T Instantiate<T>(string name) where T : Item //제약조건을 걸어 형변환이 불가능한 상황을 받지 않는다
        //{
        //    if (name == "포션")
        //    {
        //        Potion potion = new Potion();
        //        potion.name = "포션";
        //        potion.weight = 3;
        //        potion.image = "유리병에 담긴 빨간액체";
        //        potion.hp = 30;
        //        return potion as T;
        //    }
        //    else if (name == "큰포션")
        //    {
        //        Potion potion = new Potion();
        //        potion.name = "큰포션";
        //        potion.weight = 10;
        //        potion.image = "뚱뚱한 유리병에 담긴 빨간액체";
        //        potion.hp = 100;
        //        return potion as T;
        //    }
        //    else
        //    {
        //        Console.WriteLine("해당 이름의 아이템이 없습니다.");
        //        return null;
        //    }
        //}


        // enum { 큰포션, 작은포션,노랑포션}
        public static Item Instantiate(string name)
        {
            if (name == "포션")
            {
                Potion potion = new Potion();
                potion.name = "포션";
                potion.weight = 3;
                potion.image = "유리병에 담긴 빨간 액체";
                potion.hp = 30;
                return potion;

            }
            else if (name == "큰 포션")
            {
                Potion potion = new Potion();
                potion.name = "큰포션";
                potion.weight = 10;
                potion.image = "뚱뚱한 유리병에 담긴 빨간 액체";
                potion.hp = 100;
                return potion;
            }
            else
            {
                Console.WriteLine("그 아이템은 없습니다.");
                return null;
            }
        }
    }


    public class Item
    {
        public string name;
        public int weight;
        public string image;

        public Item()
        {
            this.name = "아이템";
            this.weight = 1;
            this.image = "기본 이미지";
        }

        public class Potion : Item
        {
            public int hp;           
        }
    }    
}
