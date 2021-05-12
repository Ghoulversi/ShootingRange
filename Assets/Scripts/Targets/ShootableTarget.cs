using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableTarget : MonoBehaviour
{
    //Call parent GetHit to destroy this object and spawn a new one, based on game level
    //Separate class so in the future is easier to add futures for target, anti-target, obstacle.
    public virtual void GetHit()
    {
        GetComponentInParent<MovableTarget>().GetHit();
    }
}
