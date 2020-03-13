using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    // Item Variabls
    public Item currentItem;
    public bool hasItem;
    public Plate plate;

    public GameObject newPlate;

    // Animation
    public Animator animator;

    public PlayerController playerController;
    bool isChopping;

    // Start is called before the first frame update
    void Start()
    {
        RemoveItem();
        plate = null;
        isChopping = false;
    }

    // Update is called once per frame
    void Update()
    {
        // check for item and change the item's position to match the player holding sphere
        if (currentItem != null)
        {
            currentItem.gameObject.transform.position = transform.position;
        }

        if (plate != null)
        {
            plate.gameObject.transform.position = transform.position;
        }

        // Animator things
        animator.SetBool("isWalking", playerController.isWalking);
        animator.SetBool("isHoldingItem", hasItem);
        animator.SetBool("isChopping", isChopping);
        isChopping = false;
    }


    // Set the current Item to the item from the crate
    void SetItem(Item item_)
    {
        currentItem = item_;
        hasItem = true;
    }

    void PickupPlate(Plate plate_)
    {
        plate = plate_;
        hasItem = true;
    }

    void RemoveItem()
    {
        currentItem = null;
        hasItem = false;
    }

    // MOST OF THE INTERACTIONS HAPPEN HERE!! -----------------
    // while you are colliding with an item
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("PlayerAction is colliding with" + other.name);

        // collision with crates -----------------------------------
        if (other.gameObject.CompareTag("Crate"))
        {
            Crate crate = other.gameObject.GetComponent<Crate>();

            // if the player doesn't have an item and presses "J"
            if (!hasItem && Input.GetKeyDown(KeyCode.J))
            {
                // set item to the item from the crate
                SetItem(crate.ReturnItem());
            }
        }



        // using cutting board ---------------------------------------
        if (other.gameObject.CompareTag("CuttingBoard"))
        {
            CuttingBoard cuttingBoard = other.gameObject.GetComponent<CuttingBoard>();
            // if you have an item and the cutting board does not 
            // OR
            // if you don't have an item but the cutting board does
            // AND
            // you're pressing down the "K" key
            if (hasItem && !cuttingBoard.hasItem && Input.GetKey(KeyCode.K) && currentItem.gameObject.CompareTag("FoodChoppable"))
            {
                Debug.Log("CURRENT ITEM NUMBER: " + currentItem.name);
                // give away item
                cuttingBoard.TakeInItem(currentItem);
                RemoveItem();

            }

            else if (!hasItem && cuttingBoard.hasItem && Input.GetKey(KeyCode.K))
            {
                // while the cutting is not done, 
                if (!cuttingBoard.isCuttingDone)
                {
                    // cut
                    cuttingBoard.Cutting();
                    isChopping = true;
                }
            } 

            if (!hasItem && cuttingBoard.isCuttingDone && Input.GetKeyDown(KeyCode.J))
            {
                SetItem(cuttingBoard.ReturnCuttedItem());
                cuttingBoard.ClearCuttingBoard();
            }


        }
        

        // Cooking with the Frying Pan -------------------------------------
        if (other.gameObject.CompareTag("FryingPan"))
        {
            FryingPan fryingPan = other.gameObject.GetComponent<FryingPan>();
            // if you have an item that can be cooked and the fryingPan is
            if (hasItem && !fryingPan.hasItem && Input.GetKeyDown(KeyCode.K) && currentItem.gameObject.CompareTag("FoodCookable"))
            {
                fryingPan.TakeInitem(currentItem);
                RemoveItem();
                fryingPan.CookFood();
            }

            if (!hasItem && fryingPan.isCooked && Input.GetKeyDown(KeyCode.J))
            {
                SetItem(fryingPan.ReturnCookedItem());
                fryingPan.ClearFryingPan();
            }
        }

        // Plate ----------------------------------------------------  
        if (other.gameObject.CompareTag("Plate"))
        {
            Plate plate = other.gameObject.GetComponent<Plate>();
            // add item to plate
            if (hasItem && Input.GetKeyDown(KeyCode.K) && !currentItem.gameObject.CompareTag("Plate"))
            {
                plate.AddToPlate(currentItem);
                RemoveItem();
            }

            // pick up plate
            if (!hasItem && Input.GetKeyDown(KeyCode.J))
            {
                SetItem(plate.gameObject.GetComponent<Item>());
            }
        }

        // Service Window --------------------
        if (other.gameObject.CompareTag("ServiceWindow"))
        {
            ServiceWindow serviceWindow = other.gameObject.GetComponent<ServiceWindow>();

            if (hasItem && Input.GetKeyDown(KeyCode.K) && currentItem.gameObject.CompareTag("Plate"))
            {
                serviceWindow.GivePlateToWindow(currentItem.GetComponent<Plate>());
                // change plate position to x: -1     y: 3.3     z: -27
                RemoveItem();
            }
        }

        // Trash ----------------------------
        if (other.gameObject.CompareTag("Trash"))
        {
            Trash trash = other.gameObject.GetComponent<Trash>();

            

            if (hasItem && Input.GetKeyDown(KeyCode.K))
            {
                string tag = currentItem.gameObject.tag;
                trash.RemoveItem(currentItem);
                RemoveItem();
                if(tag == "Plate")
                {
                    CreateNewPlate();
                }
                
            }
        }
    }

    void CreateNewPlate()
    {
        // create new plate at the initial position
        Instantiate(newPlate, new Vector3(-13.5f, 3.2f, 22.4f), Quaternion.Euler(0, 180,0));
        Debug.Log("New Plate");
    }
}
