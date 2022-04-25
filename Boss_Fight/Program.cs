using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable All

namespace Boss_Fight
{
    /*
    Vi skal utvide Konsoll-Applikasjonen vår til å inkludere muligheten for “heroen” til å plukke opp items i slosskampen.

    Lag en klasse som heter Item med en property av type string som heter ItemType.
    Et item kan ha en av følgende itemtypes: StaminaPotion, HealthPotion og StrengthPotion

    Dersom Heroen har 30 eller mindre i Health, skal health potion være den item typen som skal droppes.

    Logg til konsollen når et item droppes og brukes av heroen, samt effekten av den. */
    public static class ListExtentions
    {
        public static Item GetHealthFromList(this List<Item> itms)
        {
            return itms.Find(item => item.ItemType == "HealthPotion");
        }
    }
    class Program
    {
        private static List<string> _itemTypes;
        private static List<Item> _itemList;
        static void Main(string[] args)
        {
            _itemTypes = new List<string>();
            _itemTypes.Add("StaminaPotion");
            _itemTypes.Add("HealthPotion");
            _itemTypes.Add("StrengthPotion");

            var random = new Random();
            var hero = new GameCharacter(100,20,40,"Terje");
            var boss = new GameCharacter(400,20,10,"Erlend");
            var itemList = new List<Item>();
            itemList.Add(new Item(){ItemType = "HealthPotion"});
            for (int i = 1; i < 10; i++)
            {
                var itemType = _itemTypes.ElementAt(random.Next(0, 3));
                itemList.Add(new Item() { ItemType = itemType });
            }

            /* For hver tredje runde av slosskampen skal en item ha mulighet til å “droppe”.
            Om en item “droppes” eller ikke er random. 
            Når et item “droppes” blir den plukket opp av heroen som umiddelbart får effekten den gir.*/

            var count = 0;

            while (hero.Health >0 && boss.Health > 0)
            {
                if (count == 2)
                {
                    count = -1;
                    bool itemDrop = Convert.ToBoolean(random.Next(0, 2));
                    var item = hero.Health < 30 ? _itemList.GetHealthFromList() : itemList.ElementAt(random.Next(0, 10));
                }
                hero.Fight(boss);
                boss.Fight(hero,random.Next(0,30));
                count++;
            }
        }

       
    }
}
