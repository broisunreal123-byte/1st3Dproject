using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private GameObject interaction_Info_UI;
    private TextMeshProUGUI interaction_text;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Interacting objects
        if (Physics.Raycast(ray, out hit, 10f))
        {
            var interactable = hit.transform.GetComponent<InteractableObject>();

            if (interactable)
            {
                interaction_text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (!InventorySystem.Instance.CheckIfFull())
                    {
                        InventorySystem.Instance.AddToInvetory(interactable.GetItemName());
                        Destroy(interactable.gameObject);
                        
                    }
                    else
                    {
                        Debug.Log("Full fat ass!");
                    }
                }
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }

        }
        else
        {
            interaction_Info_UI.SetActive(false);
        }
    }
}