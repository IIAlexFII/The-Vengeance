using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class LoginAndRegister : MonoBehaviour
{
    public InputField username, password;
    public Button submitButton, registerButton;
    private ServerConnection ServerConnection;

    public Text messageWarning;

    private float timer = 0f;
    private float timerCoolDown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ServerConnection = new ServerConnection();

        registerButton.onClick.AddListener(RegisterPlayer);
        submitButton.onClick.AddListener(Login);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void RegisterPlayer()
    {
        ServerConnection.RegisterPlayerInfo info = new ServerConnection.RegisterPlayerInfo(username.text, password.text);
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);
        StartCoroutine(ServerConnection.PostRequest(ServerConnection.BaseAPI + "/player/new", json, PlayerRegInfo));
    }

    void Login()
    {
        ServerConnection.RegisterPlayerInfo info = new ServerConnection.RegisterPlayerInfo(username.text, password.text);
        string json = JsonUtility.ToJson(info);
        StartCoroutine(ServerConnection.PostRequest(ServerConnection.BaseAPI + "/player/login", json, PlayerGetData));
        Debug.Log(json);
    }

    public void PlayerGetData(string json)
    {
        LoginInfo info = JsonUtility.FromJson<LoginInfo>(json);
        PlayerData.loginInfo = info;

        if (info != null)
        {
            SceneManager.LoadScene(1);
        }
    }

    void PlayerRegInfo(string json)
    {
        timer = timerCoolDown;
         messageWarning.text = "Register Successful";
         //Debug.Log(json);
    }

    private void FixedUpdate()
    {
        if (messageWarning.text != string.Empty)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            messageWarning.text = string.Empty;
        }
    }

}

public class LoginInfo
{
    public string username;
    public int id;
    public int score;
}