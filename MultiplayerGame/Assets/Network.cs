using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class Network : MonoBehaviour
{
    static SocketIOComponent socket;
    public GameObject playerPrefab;
    Dictionary<string, GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn", OnSpawned);
        socket.On("move", OnMoved);
        players = new Dictionary<string, GameObject>();
    }

    private void OnMoved(SocketIOEvent e)
    {
        var id = e.data["id"].ToString();
        Debug.Log("Network player " + id + " is moving: " + e.data);
        var player = players[id];
        var pos = new Vector3(GetFloatFromJSON(e.data,"x"), 0, GetFloatFromJSON(e.data,"z"));
        var navigatePos = player.GetComponent<NavigatePos>();
        navigatePos.NavigateTo(pos);
    }

    private void OnSpawned(SocketIOEvent e)
    {
        var player = Instantiate(playerPrefab);
        Debug.Log("Spawned: " + e.data);
        players.Add(e.data["id"].ToString(), player);
        Debug.Log("Total known players: " + players.Count);
    }

    private void OnConnected(SocketIOEvent e)
    {
        Debug.Log("Connected to Server");
        JSONObject data = new JSONObject();
        data.AddField("msg", "Hello Yolo");
        socket.Emit("yolo", data);
    }

    float GetFloatFromJSON(JSONObject data, string key)
    {
        return float.Parse(data[key].ToString().Replace("\"",""));
    }
}
