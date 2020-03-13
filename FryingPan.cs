using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    public Item currentItem;
    public Item cookedItem;
    public ItemDatabase database;

    public GameObject slider;

    public bool isCooking;
    public bool hasItem;
    public bool isCooked;

    // Start is called before the first frame update
    void Start()
    {
        isCooked = false;
        isCooking = false;
        currentItem = null;
        cookedItem = null;
        hasItem = false;
        database = FindObjectOfType<ItemDatabase>();

    }

    // Update is called once per frame
    void Update()
    {
        if(currentItem)
        {
            currentItem.gameObject.transform.position = transform.position + new Vector3(0.0f, 1.5f, 0.0f);
            Debug.Log("Cooking Item Name: " + currentItem.name);
        }


        // cooking
        if(isCooking)
        {
            slider.transform.localScale += new Vector3(0, 0, 0.004f);
        }


        if(slider.transform.localScale.z >= 0.9)
        {
            FinishedCooking();
        }
    }

    public void CookFood()
    {
        isCooking = true;
    }

    void FinishedCooking()
    {
        isCooking = false;
        isCooked = true;
        slider.transform.localScale = new Vector3(1.0f, 0.75f, 0.0f);
        int foodType = currentItem.id;
        Destroy(currentItem.gameObject);
        cookedItem = database.GetItem("cooked", foodType);
        Debug.Log("DONE COOKING");
        currentItem = Instantiate(cookedItem);
    }

    public Item ReturnCookedItem()
    {
        hasItem = false;
        return Instantiate(cookedItem);
    }

    public void ClearFryingPan()
    {
        Destroy(currentItem.gameObject);
        isCooking = false;
        isCooked = false;
        cookedItem = null;
        currentItem = null;
        hasItem = false;
    }

    public void TakeInitem(Item item_)
    {
        currentItem = item_;
        hasItem = true;
    }

}
