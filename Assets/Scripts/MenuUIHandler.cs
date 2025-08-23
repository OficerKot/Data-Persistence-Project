using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    
    void Start()
    {
        nameField.onEndEdit.AddListener(GetInputText);
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }

    void GetInputText(string text)
    {
        DataManager.Instance.playerName = nameField.text;
    }
}
