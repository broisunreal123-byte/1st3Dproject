using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public static CraftingSystem Instance{get; set;}

    void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
