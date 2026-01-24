using System;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private kitchenObjectSO kitchenObjectSO;
    public kitchenObjectSO getKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
