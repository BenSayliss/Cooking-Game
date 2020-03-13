using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string name;
    public GameObject gameObject;
    public bool isPlated;

    public int type;
    // 0 = can be chopped
    // 1 = can be cooked
    // 2 = ready to be plated
    // 3 = dirty plate
    // 4 = clean plate
    // probably don't need all of these ^^^
    

    public Item(int id_, string name_, GameObject gameObject_, int type_)
    {
        id = id_;
        name = name_;
        gameObject = gameObject_;
        type = type_;
        isPlated = false;
    }

    
    public Item(Item item_)
    {
        id = item_.id;
        name = item_.name;
        gameObject = item_.gameObject;
        type = item_.type;
        isPlated = false;
    }

}
