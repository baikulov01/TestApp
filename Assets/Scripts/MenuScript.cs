using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainPanel;
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(false);
    }


    public void ContinueButton()
    {
        mainPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}