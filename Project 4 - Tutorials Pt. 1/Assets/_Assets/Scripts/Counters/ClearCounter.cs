using UnityEditor.PackageManager.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ClearCounter : BaseCounter {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;



    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
           //There is no KitchenObject here
           if(player.HasKitchenObject())
           {
               //Player is carrying something
               player.GetKitchenObject().SetKitchenObjectParent(this);
           }else
           {
               //player not carrying anything
           }
        }else{
            //There is a KitchenObject here
            if (player.HasKitchenObject()){
                //Player is carrying something
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)){
                    // Player is holding a Plate
                    if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())){
                         GetKitchenObject().DestroySelf();
                    }
                } else{
                    //Player is not carring plate but something else
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject)){
                        //counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())){
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }else{
                //player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

} 
