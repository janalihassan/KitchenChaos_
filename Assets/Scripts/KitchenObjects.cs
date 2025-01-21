using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO kitchenObjectsSo;

    public KitchenObjectsSO GetKitchenObject()
    {
        return kitchenObjectsSo;
    }
}
