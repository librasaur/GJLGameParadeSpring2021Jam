using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitchTS : MonoBehaviour
{

    public void sceneSwitch(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }   
   
    



}
