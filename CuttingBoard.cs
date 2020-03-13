using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public Item currentItem;
    public Item cuttedItem;
    public ItemDatabase database;


    public GameObject knife;

    public GameObject slider;

    public bool isCuttingDone;
    public bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        isCuttingDone = false;
        currentItem = null;
        cuttedItem = null;
        hasItem = false;
        database = FindObjectOfType<ItemDatabase>();       
    }

    // Update is called once per frame
    void Update()
    {
        // set the position of the item
        if (currentItem)
        {
            currentItem.gameObject.transform.position = transform.position + new Vector3(0.0f, 1.5f, 0.0f);
            Debug.Log("CuttingBoard Item Name: " + currentItem.name);
        }

        // when the cutting is finished
        if(slider.transform.localScale.z >= 0.9)
        {
            FinishedCutting();
        }

    }


    public void Cutting()
    {
        // make the knife on the table disappear
        knife.SetActive(false);
        slider.transform.localScale += new Vector3(0, 0, 0.004f);
    }

    // reset the timer / slider
    void FinishedCutting()
    {
        slider.transform.localScale = new Vector3(1.0f, 0.75f, 0.0f);
        int foodType = currentItem.id;
        Destroy(currentItem.gameObject);
        cuttedItem = database.GetItem("chopped", foodType);
        isCuttingDone = true;
        Debug.Log("DONE CUTTING");
        currentItem = Instantiate(cuttedItem);
    }

    public void TakeInItem(Item item_)
    {
        currentItem = item_;
        hasItem = true;
    }

    public Item ReturnCuttedItem()
    {
        hasItem = false;
        knife.SetActive(true);
        Debug.Log("return item: " + currentItem.name);
        return Instantiate(currentItem);
    }

    public void ClearCuttingBoard()
    {
        Destroy(currentItem.gameObject);
        isCuttingDone = false;
        cuttedItem = null;
        currentItem = null; // this is redundant i think
        hasItem = false;
    }
   
    
}
