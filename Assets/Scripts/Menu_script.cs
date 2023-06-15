using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_script : MonoBehaviour
{    
    public GameObject PlayPanel;
    public GameObject CommPanel;
    public void LoadScene (string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    void Start()
    {
        if (Connection.gloveseted == false)
        {
            CommPanel.SetActive(true);
            PlayPanel.SetActive(false);
        }
        else
        {
            CommPanel.SetActive(false);
            PlayPanel.SetActive(true);
        }
    }
}
