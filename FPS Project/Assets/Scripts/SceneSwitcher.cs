using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

   [SerializeField] private string targetScene;
   
   private void OnTriggerEnter(Collider other)
   {
      SceneManager.LoadScene(targetScene);
   }
}
