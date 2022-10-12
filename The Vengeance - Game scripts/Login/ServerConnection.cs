using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ServerConnection
{
    public static string BaseAPI = "http://192.168.0.22:3434";

    [System.Serializable]
    public class PlayerInfo
    {
        public string username;
        public int gold;
        public PlayerInfo(string user, int g)
        {
            username = user;
            gold = g;
        }
    }
    [System.Serializable]
    public class PlayerList
    {
        public PlayerInfo[] players;
    }
    [System.Serializable]
    public class RegisterPlayerInfo
    {
        public string username;
        public string password;
        public RegisterPlayerInfo(string u, string p)
        {
            username = u;
            password = p;
        }
    }
    [System.Serializable]
    public class UpdatePlayerInfo
    {
        public int id;
        public int gold;
        public UpdatePlayerInfo(int i, int g)
        {
            id = i;
            gold = g;
        }
    }
    public IEnumerator GetPlayersRequest(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Request Error!!");
        }
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
        }
        Debug.Log(webRequest.downloadHandler.text);

        PlayerList playerList = JsonUtility.FromJson<PlayerList>(webRequest.downloadHandler.text);

        foreach (PlayerInfo player in playerList.players)
        {
            Debug.Log(player.username);
            Debug.Log(player.gold);
        }
    }
    public IEnumerator PostRequest(string url, string jsondata, System.Action<string> behaviour)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        byte[] jsonConverted = new System.Text.UTF8Encoding().GetBytes(jsondata);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonConverted);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Request Error!!");
        }

        behaviour.Invoke(webRequest.downloadHandler.text);
    }
    // Start is called before the first frame update

}
