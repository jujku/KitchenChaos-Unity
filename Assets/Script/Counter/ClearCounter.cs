using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ClearCounter : BaseCounter
{
    
    
    [SerializeField] private GameObject kitchenObjectPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Interact(Player player)
    {
        base.Interact(player);
        if(GetKitchenObject() == null)
        {
            if (player.GetKitchenObject() != null)
            {
                TransforKitchenObject(player,this);
            }
            else
            {
                return;
            }
        }
        else
        {
            if(player.GetKitchenObject() == null)
            {
                TransforKitchenObject(this,player);
            }
            else
            {
                return;
            }
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
