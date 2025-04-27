using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;

    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecipeListSo recipeListSo;
    private List<RecipeSO> waitingRecipeSOList;

    private float spawnRecipeTimer = 0;
    private float spawnRecipeTimerMax = 4;
    private int waitingRecipeMax = 4;
    private int successFulRecipeAmount;

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
            if(KitchenGameManager.Instance.IsGamePlaying() && waitingRecipeSOList.Count < waitingRecipeMax )
            {
                RecipeSO waitingRecipeSO = recipeListSo.recipeSoList[UnityEngine.Random.Range(0, recipeListSo.recipeSoList.Count)];
                waitingRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
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
                    successFulRecipeAmount++;
                    waitingRecipeSOList.RemoveAt(i);
                    OnRecipeSuccess?.Invoke(this,EventArgs.Empty);
                    OnRecipeCompleted?.Invoke(this,EventArgs.Empty);
                    return;
                }
            }
        }
        //No Matches Found!
        //Player  did not Delivered Correct Recipe
        OnRecipeFailed?.Invoke(this,EventArgs.Empty);
    }

    public List<RecipeSO> GetWaitingRecipeListSO()
    {
        return waitingRecipeSOList;
    }
    public int GetSuccessFulRecipeAmount()
    {
        return successFulRecipeAmount;
    }
}
