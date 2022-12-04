using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{

   [SerializeField] private Transform theDest;

   void OnMouseDown()
   {
      GetComponent<BoxCollider>().enabled = false;
      GetComponent<Rigidbody>().useGravity = false;
      this.transform.position = theDest.position;
      this.transform.parent = GameObject.Find("Destination").transform;
   }

   void OnMouseUp()
   {
      this.transform.parent = null;
      GetComponent<BoxCollider>().enabled = true;
      GetComponent<Rigidbody>().useGravity = true;
   }
}
