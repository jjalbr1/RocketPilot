using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartHandler : MonoBehaviour
{
   //Controls the start screen button
   //Brings user to the first level
   public void changeTheScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
