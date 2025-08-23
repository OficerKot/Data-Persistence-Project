using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TextMeshProUGUI bestPlayerText;
    
    void Start()
    {
        nameField.onEndEdit.AddListener(GetInputText);
   
    }

    private void Update()
    {
        bestPlayerText.text = DataManager.Instance.bestPlayerName + " " + DataManager.Instance.highScore;
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }

    void GetInputText(string text)
    {
        DataManager.Instance.playerName = nameField.text;
    }
    
    public void OnClickExit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
