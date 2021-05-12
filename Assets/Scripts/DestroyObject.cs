using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //Set destroy gameobject to separate class for future upgrades
    public void DestroyGameObject(GameObject gameObjectToDestroy)
    {
        Destroy(gameObjectToDestroy);
    }
}
