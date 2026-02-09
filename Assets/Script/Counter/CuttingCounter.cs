using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public CuttingRecipeListSO cuttingRecipeListSO;
    public ProgressBar progressBar;
    private int cuttingCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Interact(Player player)
    {
        base.Interact(player);
        if(GetKitchenObject() == null)
        {
            if (player.GetKitchenObject() != null)
            {
                cuttingCount = 0;
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
                progressBar.Hide();
            }
            else
            {
                return;
            }
        }   
    }
    public override void Opreate(Player player)
    {
        base.Opreate(player);

        if(GetKitchenObject() == null) return;
        
       cuttingRecipeListSO.TryGetCuttingRecipe(
        GetKitchenObject().getKitchenObjectSO(),
        out CuttingRecipe cuttingrecipe);
        


        if(cuttingrecipe != null)
        {
            cuttingCount++;
            Debug.Log(cuttingCount/cuttingrecipe.cuttingCount);
            progressBar.UpdateProgressBar((float)cuttingCount/(float)cuttingrecipe.cuttingCount);

            if(cuttingCount == cuttingrecipe.cuttingCount){
            DestroyKithenObject();
            CreateKitchenObject(cuttingrecipe.output.prefab);
      
            }
       }
    }
}
