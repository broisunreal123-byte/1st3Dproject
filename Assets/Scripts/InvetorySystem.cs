using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using NUnit.Framework;
using UnityEngine;
 
public class InventorySystem : MonoBehaviour
{
 
   public static InventorySystem Instance { get; set; }
 
    public GameObject inventoryScreenUI;

    public List<GameObject> slotList = new List<GameObject>();

    public List<string> itemList = new List<string>();

    private GameObject itemToAdd;

    private GameObject whatSlotToEquip;

    public bool isOpen;

    public bool isFull;
 
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
 
    void Start()
    {
        isOpen = false;
        PopulateSlotList();
    }

    private void PopulateSlotList()
    {
        foreach(Transform child in inventoryScreenUI.transform)
        {
            if (child.CompareTag("Slot"))
            {
                slotList.Add(child.gameObject);
            }
        }
    }

    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
 
		    Debug.Log("i is pressed");
            inventoryScreenUI.SetActive(true);
            isOpen = true;
            Cursor.lockState = CursorLockMode.None;
 
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            isOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    public void AddToInvetory(String name)
    {
        
        if (CheckIfFull())
        {
            Debug.Log("Full fat ass!");
        }
        else
        {
          whatSlotToEquip = FindNextEmptySlot();
          itemToAdd = (GameObject)Instantiate(Resources.Load<GameObject>(name), whatSlotToEquip.transform.position,whatSlotToEquip.transform.rotation);  
        }
    }

    private GameObject FindNextEmptySlot()
    {
        throw new NotImplementedException();
    }

    public bool CheckIfFull()
    {
        return isFull;
    }
 
}