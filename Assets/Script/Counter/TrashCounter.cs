using UnityEngine;

public class TrashCounter : BaseCounter
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Interact(Player player)
    {
        base.Interact(player);
        if(player.GetKitchenObject() != null)
        {
            player.DestroyKithenObject();
        }
    }
}
