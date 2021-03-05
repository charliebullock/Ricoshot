using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject destructionObject;   
    private void OnCollisionEnter(Collision collision)
    {
        //If projectile collides then destroy the destruction object or the gameobject which the class is attached to
        if (collision.gameObject.tag == "Projectile")
        {
            if (destructionObject)
            {
                Destroy(destructionObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
