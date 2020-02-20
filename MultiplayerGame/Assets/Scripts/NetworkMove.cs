using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class NetworkMove : MonoBehaviour
{
    public SocketIOComponent socket;

    public void OnMove(Vector3 pos)
    {
        Debug.Log("Sending position to server: " + VectorToJson(pos));
        socket.Emit("move", new JSONObject(VectorToJson(pos)));
    }

    string VectorToJson(Vector3 vector)
    {
        return string.Format(@"{{""x"":""{0}"",""z"":""{1}""}}", vector.x, vector.z);
    }
}
