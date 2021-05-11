using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public string WeaponName;
    public GameObject WeaponPrefab;
}
