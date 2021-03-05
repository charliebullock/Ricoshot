using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private BulletStats bulletStats;

   public Vector3 reflectDirection;
   
   private int maxDistance;
   private Rigidbody rb;
   private float speedBullet;
   private int reflectionsBullet;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      reflectionsBullet = bulletStats.numberOfReflections;
      speedBullet = bulletStats.speed;
   }

   private void Update()
   {
      if (bulletStats.numberOfReflections < 1)
      {
         Destroy(this.gameObject);
      }
      
      
   }

   private void FixedUpdate()
   {
      transform.position += (reflectDirection * (Time.deltaTime * speedBullet));
      transform.LookAt(transform.position + reflectDirection);
   }

   private void OnCollisionEnter(Collision other)
   {
      if (other.transform.CompareTag("Wall"))
      {
         --reflectionsBullet;
         reflectDirection = Vector3.Reflect(reflectDirection, other.contacts[0].normal);
         Debug.Log(reflectDirection);
      }
   }

   private void OnDrawGizmos()
   {
      Handles.color = Color.blue;
      Handles.ArrowHandleCap(0,transform.position + transform.forward *0.25f, transform.rotation, 0.25f, EventType.Repaint);
   }
}
