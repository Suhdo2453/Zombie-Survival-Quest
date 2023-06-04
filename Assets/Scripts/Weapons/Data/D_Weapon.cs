using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="newEntityData", menuName ="Data/Weapon Data/Base Data")]
public class D_Weapon : ScriptableObject
{
    public int quantityOfBullets;
    public float reloadTime;
    public float fireRate;
    
    public float fireForce;
    public GameObject bulletPref;
    public Sound fireSound;
    public Sound reloadSound;
}
