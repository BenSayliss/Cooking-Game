using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    // Start is called before the first frame update

    public void RemoveItem(Item item_)
    {
        // if the item is a plate...
        if(item_.gameObject.CompareTag("Plate"))
        {
            // destroy each item on the plate
            for(int i = 0; i < item_.GetComponent<Plate>().itemsOnPlate.Count; i++)
            {
                Destroy(item_.GetComponent<Plate>().itemsOnPlate[i].gameObject);
            }
        }


        // destroy item
        Destroy(item_.gameObject);
        Debug.Log("TRASH DESTROY: " + item_.name);
    }

    
}
