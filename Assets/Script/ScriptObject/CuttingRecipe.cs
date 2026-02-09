using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CuttingRecipe
{
    public kitchenObjectSO input;
    public kitchenObjectSO output;
    public int cuttingCount; 
}

[CreateAssetMenu()]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;

    public bool TryGetCuttingRecipe(kitchenObjectSO input,out CuttingRecipe cuttingrecipe)
    {
        foreach(CuttingRecipe recipe in list)
        {
            if(recipe.input == input)
            {
              cuttingrecipe = recipe;
              return true;
            }
        }
        cuttingrecipe = null;
        return false;
    }
    public kitchenObjectSO GetOutput(kitchenObjectSO input)
    {
        foreach(CuttingRecipe recipe in list)
        {
            if(recipe.input == input)
            {
              return recipe.output;
            }
        }
        return null;
    }
}