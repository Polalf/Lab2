using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ui : MonoBehaviour
{
    
    [Header("Pausa")]
    public KeyCode pauseKey;
    public bool isPause;
    [SerializeField] GameObject pausePanel;
    
    // Update is called once per frame
    void Update()
    {
        if(isPause)
        {
            if(Input.GetKeyDown(pauseKey))
            {
                pausePanel.SetActive(true);
                TimeControl(0);
            }
        }
    }
    public void TimeControl(int _tScale)
    {
        Time.timeScale = _tScale;
    }
    public void LoadScene(int nScene)
    {
        SceneManager.LoadScene(nScene);
    }

    public void Quit()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
