using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas can1;

    private void Start()
    {
        can1.gameObject.SetActive(false);


    }
    

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            can1.gameObject.SetActive(true); 

        }
    }


  



    public void sceneSwitch(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
