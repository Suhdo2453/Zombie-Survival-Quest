using System.Collections;
using System.Collections.Generic;
using Ultilites;
using UnityEngine;

public class BackPool : MonoBehaviour
{
    public void BackPoolObject()
    {
        ObjectPooler.Instance.CoolObject(gameObject);
    }
}
