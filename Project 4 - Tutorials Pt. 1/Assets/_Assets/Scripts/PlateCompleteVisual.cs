using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlateCompleteVisual : MonoBehaviour
{
[Serializable]
public struct kitcheObjectSO_GameObject {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }
[SerializeField] private PlateKitchenObject plateKitchenObject;
[SerializeField] private List<kitcheObjectSO_GameObject> kitcheObjectSO_GameObjectList;
 private void Start() {
     plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;

      foreach(kitcheObjectSO_GameObject kitcheObjectSO_GameObject in kitcheObjectSO_GameObjectList){
                kitcheObjectSO_GameObject.gameObject.SetActive(false);
     }

 }
 private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
//e.kitchenObjectSO
        foreach(kitcheObjectSO_GameObject kitcheObjectSO_GameObject in kitcheObjectSO_GameObjectList){
            if(kitcheObjectSO_GameObject.kitchenObjectSO == e.kitchenObjectSO){
                kitcheObjectSO_GameObject.gameObject.SetActive(true);
            }
     }
 }
}
