using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> itemsMisc = new List<Item>();
    public List<Item> itemsRaw = new List<Item>();
    public List<Item> itemsChopped = new List<Item>();
    public List<Item> itemsCooked = new List<Item>();
    public GameObject orangeRaw, orangeChopped, orangeCooked,
                      bunRaw,
                      burgerRaw, onionRaw, burgerCooked,
                      lettuceRaw, lettuceChopped,
                      tomatoRaw, tomatoChopped,
                      cheeseRaw, cheeseChopped, onionChopped,
                      dirtyPlate, cleanPlate;

    private void Awake()
    {
        // Bug with database
        // hardcoding in adding in all the elemetns
        // BuildItemDatabase();
    }

    public Item GetItem(string whichItem, int id)
    {
        if(whichItem == "raw")
        {
            return itemsRaw.Find(item => item.id == id);
        } else if(whichItem == "chopped")
        {
            Debug.Log("return chopped item.");
            Debug.Log("does choped item exist: " + itemsChopped.Exists(item => item.id == id));
            return itemsChopped.Find(item => item.id == id);
           
        } else if(whichItem == "cooked")
        {
            return itemsCooked.Find(item => item.id == id);
        }
        return null;
        
    }

    public Item GetItem(string whichItem, string name)
    {
        if (whichItem == "raw")
        {
            return itemsRaw.Find(item => item.name == name);
        }
        else if (whichItem == "chopped")
        {
            return itemsChopped.Find(item => item.name == name);
        }
        else if (whichItem == "cooked")
        {
            return itemsCooked.Find(item => item.name == name);
        }
        return null;

    }


    void BuildItemDatabase()
    {

        // build all miscellaneous items
        itemsMisc = new List<Item>()
        {
            new Item(0, "DirtyPlate", dirtyPlate, 3),

            new Item(1, "CleanPlate", cleanPlate, 4)
        };

        // build all items
        itemsRaw = new List<Item>()
        {
            new Item(0, "Orange", orangeRaw, 0),

            new Item(1, "Bun", bunRaw, 2),

            new Item(2, "Burger", burgerRaw, 1),

            new Item(3, "Lettuce", lettuceRaw, 0),

            new Item(4, "Tomato", tomatoRaw, 0),

            new Item(5, "Cheese", cheeseRaw, 0), 

            new Item(6, "Onion", onionRaw, 0)
        };

        // build all items chopped
        itemsChopped = new List<Item>()
        {
            new Item(0, "OrangeChopped", orangeChopped, 2),

            //new Item(1, "BunChopped"),

            //new Item(2, "BurgerChopped"),

            new Item(3, "LettuceChopped", lettuceChopped, 2),

            new Item(4, "TomatoChopped", tomatoChopped, 2),

            new Item(5, "CheeseChopped", cheeseChopped, 2), 

            new Item(6, "OnionChopped", onionChopped, 2)
        };

        // build all items cooked
        itemsCooked = new List<Item>()
        {
            new Item(0, "OrangeCooked", orangeCooked, 2),

            //new Item(1, "BunCooked"),

            new Item(2, "BurgerCooked", burgerCooked, 2),

            //new Item(3, "LettuceCooked"),

            //new Item(4, "TomatoCooked"),

            //new Item(5, "CheeseCooked")
        };

    }
}
