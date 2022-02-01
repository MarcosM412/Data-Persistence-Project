using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField inputName;
    [SerializeField] Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.bestScore > 0)
        {
            bestScoreText.text = "Best Score: " + MainManager.Instance.Name + ": " + MainManager.Instance.bestScore;
        }
    }

    public void StartNew()
    {
        MainManager.Instance.Name = inputName.text;
        Debug.Log("Name is " + MainManager.Instance.Name);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        MainManager.Instance.SaveScore();
    }
}
