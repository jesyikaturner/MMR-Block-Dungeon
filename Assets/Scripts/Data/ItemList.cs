using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ItemList
{
    /*
     * ItemList.cs
     * Stores a list of items which are created from ItemDictionary.json
     * 
     * Different types of Items:
     * - Equipment
     * - Junk
     * - Material
     * - Consumable
     * - Battle
     * - Breeding
     */
    private Dictionary<string, Item> _itemList;

    public ItemList(TextAsset json)
    {
        //_itemList = new Dictionary<string, Item>();

        //JSONItems items = JsonUtility.FromJson<JSONItems>(json.text);

        //string name = "", description = "", target = "";
        //Dictionary<string, Item> typeDictionary = new Dictionary<string, Item>()
        //{
        //    ["equipment"] = new EquipmentItem(name, description, target),
        //    ["junk"] = new JunkItem(name, description, target),
        //    ["material"] = new MaterialItem(name, description, target),
        //    ["consumable"] = new ConsumableItem(name, description, target),
        //    ["battle"] = new BattleItem(name, description, target),
        //    ["breeding"] = new BreedingItem(name, description, target),
        //};

        //try
        //{
        //    _itemList.Add("name", typeDictionary[ParseItemType(description)]);
        //}
        //catch (Exception e)
        //{
        //    Logger.WriteToLog(string.Format("ItemList: ItemList(): ERROR: {0}.", e));
        //}
    }

    public string ParseItemType(string description, string startChar, string endChar)
    {
        //string startChar = "[";
        //string endChar = "]";
        
        if (description.Contains(startChar) && description.Contains(endChar))
        {
            int start, end;
            start = description.IndexOf(startChar, 0) + startChar.Length;
            end = description.IndexOf(endChar, start);
            return description[start..end];
        }
        return "";
    }

    public class JSONItems
    {
        public JSONItem[] items;
    }

    public class JSONItem
    {
        public int id;
        public string name;
        public string description;
        public string target;
        public int price;
    }
}

public class Item
{
    public enum TARGET { ONE, ALL, NONE }

    public int id;
    public string name;
    public string description;
    public TARGET target;
    public int price;

    private readonly Logger _logger = Logger.Instance;

    public Item(int id, string name, string description, string target, int price)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        SetTarget(target);
        this.price = price;
    }

    /// <summary>
    /// Sets who the item is targeting.
    /// </summary>
    /// <param name="target">Should be either 'one', 'all', or 'none'.</param>
    public void SetTarget(string target)
    {
        Dictionary<string, TARGET> targetDictionary = new Dictionary<string, TARGET>()
        {
            ["one"] = TARGET.ONE,
            ["all"] = TARGET.ALL,
            ["none"] = TARGET.NONE
        };

        if(targetDictionary.ContainsKey(target))
        {
            this.target = targetDictionary[target];
            _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Set target to {0}", this.target));
        }
        else
        {
            ArgumentNullException e = new ArgumentNullException("Invalid Effect");
            _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), e.ToString());
            throw e;
        }
    }

    public virtual string Print()
    {
        return "";
    }
}

public class EquipmentItem : Item
{
    public enum SLOT { RIGHTMELEE, LEFTMELEE, TRINKET}
    public int value;
    public EquipmentItem(int id, string name, string description, string target, int price) :base(id, name, description, target, price)
    {
        this.name = name;
        this.description = description;
        SetTarget(target);
        this.price = price;
    }
    public override string Print()
    {
        return "";
    }
}

public class JunkItem : Item
{
    public JunkItem(int id, string name, string description, string target, int price) : base(id, name, description, target, price)
    {
        this.name = name;
        this.description = description;
    }
}

public class MaterialItem : Item
{
    public MaterialItem(int id, string name, string description, string target, int price) :base(id, name, description, target, price)
    {
        this.name = name;
        this.description = description;
    }
}

public class ConsumableItem : Item
{
    public ConsumableItem(int id, string name, string description, string target, int price) : base(id, name, description, target, price)
    {
        this.name = name;
        this.description = description;
    }
    public override string Print()
    {
        return "";
    }
}

public class BattleItem : Item
{
    public BattleItem(int id, string name, string description, string target, int price) : base(id, name, description, target, price)
    {
        this.name = name;
        this.description = description;
    }
    public override string Print()
    {
        return "";
    }
}

public class BreedingItem : Item
{
    public BreedingItem(int id, string name, string description, string target, int price) : base(id, name, description, target, price)
    {
        this.name = name;
        this.description = description;
    }
}