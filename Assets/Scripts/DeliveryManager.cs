using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecipeListSo recipeListSo;
    private List<RecipeSO> waitingRecipeSOList;

    private float spawnRecipeTimer = 0;
    private float spawnRecipeTimerMax = 4;
    private int waitingRecipeMax = 4;

    private void Awake()
    {
        Instance = this;
        waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0f )
        {
            spawnRecipeTimer = spawnRecipeTimerMax;
            if(waitingRecipeSOList.Count < waitingRecipeMax )
            {
                RecipeSO waitingRecipeSO = recipeListSo.recipeSoList[Random.Range(0, recipeListSo.recipeSoList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);  
                waitingRecipeSOList.Add(waitingRecipeSO);
            }

        }
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];
            if (waitingRecipeSO.kitchenObjectsSOsList.Count == plateKitchenObject.GetKitchenObjectsSOs().Count)
            // Has the Same Number of Ingredients in the Plate
            {
                bool plateContentMatchesRecipe = true;
                foreach (KitchenObjectsSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectsSOsList)
                {
                    //Cycling through all the ingredients in the Recipe
                    bool ingredientFound = false;
                    foreach (KitchenObjectsSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectsSOs())
                    {
                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            //Ingredient Matches
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        //The Recipe Was not Found on the List
                       plateContentMatchesRecipe = false;
                    }
                }
                if (plateContentMatchesRecipe)
                {
                    //Player Delivered The Correct Recipe
                    Debug.Log("Player Delivered The Correct Recipe");
                    waitingRecipeSOList.RemoveAt(i);
                    return;
                }
            }
        }
        //No Matches Found!
        //Player  did not Delivered Correct Recipe
        Debug.Log("Player  did not Delivered Correct Recipe");
    }
}
