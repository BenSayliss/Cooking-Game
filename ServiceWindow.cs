using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServiceWindow : MonoBehaviour
{
    ItemDatabase database;
    public List<Item> correctItems = new List<Item>();
    public List<Item> receivedItems = new List<Item>();
    public bool doItemsMatch;

    public Item test1, test2, test3;

    public Text recipeText1, recipeText2, recipeText3, recipeCompleteText, recipeIncompleteText;
    // Start is called before the first frame update
    void Start()
    {
        // hardcoding in the items because there is an error with my ItemDatabase :( 
        doItemsMatch = false;
        database = FindObjectOfType<ItemDatabase>();
        correctItems.Add(test1);
        correctItems.Add(test2);
        correctItems.Add(test3);
        recipeText1.text = test1.name;
        recipeText2.text = test2.name;
        recipeText3.text = test3.name;
        recipeCompleteText.gameObject.SetActive(false);
        recipeIncompleteText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        doItemsMatch = DoListsMatch(correctItems, receivedItems);
        if(doItemsMatch)
        {
            recipeIncompleteText.gameObject.SetActive(false);
            recipeCompleteText.gameObject.SetActive(true);
        } else
        {
            recipeIncompleteText.gameObject.SetActive(true);
            recipeCompleteText.gameObject.SetActive(false);
        }
    }

    bool DoListsMatch(List<Item> list1, List<Item> list2)
    {
        if(list1.Count != list2.Count)
        {
            return false;
        }
        for(int i = 0; i < list1.Count; i++)
        {
            if(list1[i].name != list2[i].name)
            {
                return false;
            }
        }
        return true;
    }

    public void GivePlateToWindow(Plate plate_)
    {
        receivedItems = new List<Item>(plate_.itemsOnPlate);
        plate_.gameObject.transform.localPosition = new Vector3(-1.0f, 3.3f, -27.0f);

    }

}
