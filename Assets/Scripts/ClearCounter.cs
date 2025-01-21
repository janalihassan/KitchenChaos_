using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObjects kitchenObjects;
    public void Interact()
    {
        if (kitchenObjects == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.Prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            kitchenObjects = kitchenObjectTransform.GetComponent<KitchenObjects>();
        }
       
    }
}
