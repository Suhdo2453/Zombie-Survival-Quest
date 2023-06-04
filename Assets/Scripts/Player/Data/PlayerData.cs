using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
   [Header("Move State")] public float movementSpeed = 10f;
   [Header("Knock Back State")] 
   public float knockBackForce = 10f;

   public float knockBackTime = 0.2f;
}
