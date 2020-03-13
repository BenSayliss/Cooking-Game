using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public List<Item> itemsOnPlate = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // for each item on the plate
        for (int i = 0; i < itemsOnPlate.Count; i++)
        {
            // each item on the plate gets higher
            itemsOnPlate[i].gameObject.transform.position = transform.position + new Vector3(0.0f, 0.25f * i + 1, 0.0f);
        }
    }

    // method called to add an item to the plate
    public void AddToPlate(Item item_)
    {
        // add item to the plate
        itemsOnPlate.Add(item_);
    }


}
