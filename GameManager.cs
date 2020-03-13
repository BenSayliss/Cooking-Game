using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ItemDatabase database;
    public Item orangeRawTest;
    public Item orangeChoppedTest;
    public Item burgerRaw;
    public Item burgerCooked;
    public Item bun;
    public Item plate;
    public Item onionRawTest;
    public Item onionChoppedTest;

    // Start is called before the first frame update
    void Start()
    {
        database = FindObjectOfType<ItemDatabase>();

        // this is really bad but i'm having a bug with my item database
        database.itemsRaw.Add(orangeRawTest);
        database.itemsChopped.Add(orangeChoppedTest);
        database.itemsRaw.Add(burgerRaw);
        database.itemsCooked.Add(burgerCooked);
        database.itemsRaw.Add(bun);
        database.itemsMisc.Add(plate);
        database.itemsRaw.Add(onionRawTest);
        database.itemsChopped.Add(onionChoppedTest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
