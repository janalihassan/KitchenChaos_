using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct kitchenObjectSO_GameObject {
    
        public KitchenObjectsSO KitchenObjectsSO;
        public GameObject gameObject;
    }


    [SerializeField]private PlateKitchenObject platekitchenObject;
    [SerializeField] private List<kitchenObjectSO_GameObject> kitchenGameObjectList;


    private void Start()
    {
        platekitchenObject.onIngredientAdded += PlatekitchenObject_onIngredientAdded;
        foreach (kitchenObjectSO_GameObject kitchenObjectSO_GameObject in kitchenGameObjectList)
        {
            kitchenObjectSO_GameObject.gameObject.SetActive(false); 
        }
    }

    private void PlatekitchenObject_onIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (kitchenObjectSO_GameObject kitchenObjectSO_GameObject in kitchenGameObjectList)
        {
            if (kitchenObjectSO_GameObject.KitchenObjectsSO == e.KitchenObjectsSO) {
                kitchenObjectSO_GameObject.gameObject.SetActive(true);
            }
        }
    }
}
