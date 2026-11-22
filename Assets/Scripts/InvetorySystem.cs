using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using NUnit.Framework;
using Unity.VisualScripting;
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

    //public bool isFull;




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
        foreach (Transform child in inventoryScreenUI.transform)
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
            

        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            isOpen = false;
            
        }

    }

    public void AddToInvetory(String name)
    {

        whatSlotToEquip = FindNextEmptySlot();

        itemToAdd = Instantiate
        (Resources.Load<GameObject>(name), whatSlotToEquip.transform.position, whatSlotToEquip.transform.rotation);

        itemToAdd.transform.SetParent(whatSlotToEquip.transform);

        itemList.Add(name);

    }

    private GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return new GameObject();
        
    }

    public bool CheckIfFull()
    {
        int count = 0;
        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount > 0)
            {
                count++;
            }
        }
        if (count >= 14)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}