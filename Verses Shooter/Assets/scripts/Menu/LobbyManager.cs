using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inputField;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JoinRoom()
    {
        PlayerPrefs.SetString("room", inputField.GetComponent<TMP_InputField>().text);
        SceneManager.LoadScene(1); // If this isn't working check ID of main scene in  File > Build Settings  ("thanks" -Owen)
    }
}
