using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


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
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            craftingScreenUI.SetActive(false);
            toolScreenUI.SetActive(false);
            isOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    
}
