using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class CraftingSystem : MonoBehaviour
{
    public static CraftingSystem Instance{get; private set;}

    public GameObject craftingScreenUI;

    public GameObject toolScreenUI;

    public List<string> inventoryItemList = new List<string>();

    //Category Buttons
    private Button toolsBTN;

    //Craft Buttons
    private Button craftAxeBTN;

    //Requirement text
    private Text Axereq1, Axereq2;
    
    public bool isOpen;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }
    void Start()
    {
        isOpen = false;
        toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
        toolsBTN.onClick.AddListener(OpenToolsCategory);
        Axereq1 = toolScreenUI.transform.Find("Axe").transform.Find("req1").GetComponent<Text>();
        Axereq2 = toolScreenUI.transform.Find("Axe").transform.Find("req2").GetComponent<Text>();
        craftAxeBTN = toolScreenUI.transform.Find("Axe").Find("CraftAxe").GetComponent<Button>();
        craftAxeBTN.onClick.AddListener(() => CraftAnyItem());
    }

    private void CraftAnyItem()
    {
        //add item into invetory


        //remove crafted materials
    }

    public void OpenToolsCategory()
    {
        craftingScreenUI.SetActive(false);
        toolScreenUI.SetActive(true);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
            craftingScreenUI.SetActive(true);
            isOpen = true;
            

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolScreenUI.SetActive(false);
            isOpen = false;
            
        }

    }

    
}
