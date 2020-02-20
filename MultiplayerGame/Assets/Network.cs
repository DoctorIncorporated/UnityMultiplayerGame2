using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class Network : MonoBehaviour
{
    static SocketIOComponent socket;
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn", OnSpawned);
        socket.On("move", OnMoved);
    }

    private void OnMoved(SocketIOEvent e)
    {
        Debug.Log("Network player is moving: " + e.data);
    }

    private void OnSpawned(SocketIOEvent e)
    {
        Instantiate(playerPrefab);
        //throw new NotImplementedException();
    }

    private void OnConnected(SocketIOEvent e)
    {
        Debug.Log("Connected to Server");
        JSONObject data = new JSONObject();
        data.AddField("msg", "Hello Yolo");
        socket.Emit("yolo", data);
    }
}
