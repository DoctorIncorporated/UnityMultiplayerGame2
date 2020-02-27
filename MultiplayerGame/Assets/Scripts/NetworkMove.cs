using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkMove : MonoBehaviour
{
    public SocketIOComponent socket;

    public void OnMove(Vector3 pos)
    {
        Debug.Log("Sending position to server: " + Network.VectorToJson(pos));
        socket.Emit("move", new JSONObject(Network.VectorToJson(pos)));
    }
}
