﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void AddObjeto()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i] == 0)
            { 
                inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                Destroy(gameObject);
                break;
            }
        }
    }
}

