using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    Canvas canvas;

    public UnityEngine.Audio.AudioMixer mixer;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void SetBGM(float val)
    {
        mixer.SetFloat("BGM", val);
    }
    public void SetFX(float val)
    {
        mixer.SetFloat("FX", val);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
    }
    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
      
    }
    public void GameQuit()
    {
        #if UNITY_EDITOR //에디터일때

        UnityEditor.EditorApplication.isPlaying = false;
        #else //에디터가 아닐때
        Application.Quit();
        #endif
    }
}
