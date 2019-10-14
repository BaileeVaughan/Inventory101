using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        int _amount = 0;
        int _value = 0;
        int _damage = 0;
        int _armour = 0;
        int _heal = 0;
        string _name = "";
        string _description = "";
        string _icon = "";
        string _mesh = "";
        ItemType _type = ItemType.Armour;

        switch (itemID)
        {
            #region Armour 0 - 99
            case 0:
                _name = "Calming Ditao Shirt";
                _description = "Also known as 'Dead Men', the Ditao wander aimlessly thoughout their province, blind to the outside world, but holding a grand mystery. Nobody knows how the Ditao obtained these shirts, but when wore, is told to clear the mind.";
                _amount = 1;
                _value = 50;
                _type = ItemType.Armour;
                _icon = "Armour/a_19";
                _mesh = "Armour/a_19";
                _damage = 0;
                _armour = 10;
                _heal = 0;
                break;

            case 1:
                _name = "Yrvelle War Sleeve";
                _description = "Although this sleeve may look soft, they are actually made from thousands of stonewire strands. The Yrvelles' tough skin prevents them from being harmed, but normal skin would be shredded.";
                _amount = 4;
                _value = 200;
                _type = ItemType.Armour;
                _icon = "Armour/b_11";
                _mesh = "Armour/b_11";
                _damage = 30;
                _armour = 20;
                _heal = 0;
                break;

            case 2:
                _name = "Grandiorre Troop Helm";
                _description = "A common, yet useful helm worn by the protectors of Grandiorre. It offers sufficient defence against most wild beasts, and is suitable for long use: thanks to the advanced Grandiorre engineering.";
                _amount = 1;
                _value = 75;
                _type = ItemType.Armour;
                _icon = "Armour/h_23";
                _mesh = "Armour/h_23";
                _damage = 0;
                _armour = 40;
                _heal = 0;
                break;
            #endregion
            #region Craftable 100 - 199
            case 100:
                _name = "Belzebubs Joint";
                _description = "";
                _amount = 1;
                _value = 666;
                _type = ItemType.Craftable;
                _icon = "Craftable/r_01";
                _mesh = "Craftable/r_01";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 101:
                _name = "Smooth Sea Jewel";
                _description = "";
                _amount = 1;
                _value = 150;
                _type = ItemType.Craftable;
                _icon = "Craftable/t_01_a";
                _mesh = "Craftable/t_01_a";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 102:
                _name = "Powdered Shroom Branch";
                _description = "";
                _amount = 1;
                _value = 100;
                _type = ItemType.Craftable;
                _icon = "Craftable/r_01";
                _mesh = "Craftable/r_01";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Food 200 - 299
            case 200:
                _name = "Coagulated Gnome Juice";
                _description = "";
                _amount = 1;
                _value = 0;
                _type = ItemType.Food;
                _icon = "Food/c_01";
                _mesh = "Food/c_01";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 201:
                _name = "Yrvelle Leg Meat";
                _description = "";
                _amount = 1;
                _value = 0;
                _type = ItemType.Food;
                _icon = "Food/m_05";
                _mesh = "Food/m_05";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            case 202:
                _name = "Cooked Srugah Infant";
                _description = "";
                _amount = 1;
                _value = 0;
                _type = ItemType.Food;
                _icon = "Food/s_01";
                _mesh = "Food/s_01";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;
            #endregion
            #region Ingredient 300 - 399
            case 300:
                _name = "Common Gnome Beans";
                _description = "Just one of these beans is enough to bring out the animalistic nature of any being. Unfortunately they are rather common, leading to many attacks from wild animals.";
                _amount = 6;
                _value = 10;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/b_28";
                _mesh = "Ingredient/b_28";
                _damage = 0;
                _armour = 0;
                _heal = 5;
                break;

            case 301:
                _name = "Yrvelle Meat Spice";
                _description = "Famous all across the land, this spice is only obtainable in the heart of the Yrvelle Citadel, and is sought after by many adventurers looking for the perfect spice.";
                _amount = 1;
                _value = 100;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/g_32";
                _mesh = "Ingredient/g_32";
                _damage = 0;
                _armour = 0;
                _heal = 10;
                break;

            case 302:
                _name = "Poison Wine Shroom";
                _description = "Once rid of the deadly toxins, the wine from this shroom is quite the treat for someone of noble stature. Although worthless until processed, lower class citizes and merchants found with it are sentenced to three weeks in the Srugah pit.";
                _amount = 1;
                _value = 5;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/m_10";
                _mesh = "Ingredient/m_10";
                _damage = 0;
                _armour = 0;
                _heal = -10;
                break;

            #endregion
                #region Misc 400 - 499

                #endregion
                #region Money 500 - 599

                #endregion
            #region Potions 600 - 699
            case 600:
                _name = "Srugah Blood";
                _description = "These deformed beings are physically harmless, but left alone with one will drive one to the brink of madness. If a Srugah is killed while targeting another being, the blood can be collected and sold for a high price. The blood is also used to fertilise Srugah pods.";
                _amount = 1;
                _value = 100;
                _type = ItemType.Potion;
                _icon = "Potion/22";
                _mesh = "Potion/22";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;

            case 601:
                _name = "Yrvelle Piss";
                _description = "A surprisingly sweet smelling substance, this liquid is used to brew berserker potions, allowing the consumer to channel the spirit of a Yrvelle warrior in battle.";
                _amount = 1;
                _value = 50;
                _type = ItemType.Potion;
                _icon = "Potion/24";
                _mesh = "Potion/24";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;

            case 602:
                _name = "Gnome Juice";
                _description = "As the name suggests, this potion is quite crude. Consuming this potion allows for the user to speak Gnomish for up to five hours, but also takes away the abiliy to speak the users native tounge.";
                _amount = 1;
                _value = 75;
                _type = ItemType.Potion;
                _icon = "Potion/30";
                _mesh = "Potion/30";
                _damage = 0;
                _armour = 0;
                _heal = 0;
                break;

            #endregion
            #region Quest 700 - 799

            #endregion
            #region Scroll 800 - 899

            #endregion
            #region Weapon 900 - 999

            #endregion
            default:
                itemID = 300;
                _name = "Common Gnome Beans";
                _description = "Just one of these beans is enough to bring out the animalistic nature of any being. Unfortunately they are rather common, leading to many attacks from wild animals.";
                _amount = 6;
                _value = 10;
                _type = ItemType.Ingredient;
                _icon = "Ingredient/b_28";
                _mesh = "Ingredient/b_28";
                _damage = 0;
                _armour = 0;
                _heal = 5;
                break;
        }

        Item temp = new Item
        {
            ID = itemID,
            Amount = _amount,
            Value = _value,
            Damage = _damage,
            Armour = _armour,
            Heal = _heal,
            Name = _name,
            Description = _description,
            Icon = Resources.Load("Icons/" + _icon) as Texture2D,
            ItemMesh = Resources.Load("Mesh/" + _mesh) as GameObject,
            Type = _type
        };

        return temp;
    }


}
