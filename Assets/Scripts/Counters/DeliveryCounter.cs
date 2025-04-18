using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{

    public static DeliveryCounter Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObjects().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                // Only Accept Plates
                DeliveryManager.Instance.DeliveryRecipe(plateKitchenObject);
                player.GetKitchenObjects().DestroySelf();
            }
        }
    }
}
