using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager current = null;
    void Awake()
    {
        if (current == null)
            current = this;
        else
            Debug.LogError("Not single UIManager");

    }

    int Score;
    [SerializeField]
    UnityEngine.UI.Text scoreText;
    [SerializeField]
    GameObject GameOverText;

    public void Addscore(int point)
    {
        Score += point;
        scoreText.text = "Score : " + Score;
    }

    void Update()
    {
        
    }
    void GameOver()
    {
        gameObject.SetActive(GameOverText);
    }
}
