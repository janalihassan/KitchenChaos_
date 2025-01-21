using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;

    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObjects kitchenObjects;


    private void Update()
    {
        if (testing && Input.GetKey(KeyCode.T))
        {
            if(kitchenObjects != null) {
            kitchenObjects.SetClearCounter(secondClearCounter);
            }
        }
    }

    public void Interact()
    {
        if (kitchenObjects == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.Prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObjects>().SetClearCounter(this);
        }
       else
        {
            Debug.Log(kitchenObjects.GetClearCounter());
        }

    }

    public Transform GetObjectFollowtransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObjects = kitchenObject;
    }
    public KitchenObjects GetKitchenObjects()
    {
        return kitchenObjects;
    }
    public void ClearKitchenObject() { 
        kitchenObjects = null; 
    }
    public bool HasKitchenObject()
    {
        return kitchenObjects != null;
    }

}
