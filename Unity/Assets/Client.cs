using System;
using UnityEngine;
using WebSocketSharp;

public static class Client
{
    private static WebSocket _webSocket;
    
    [RuntimeInitializeOnLoadMethod]
    private static void Start()
    {
        _webSocket = new WebSocket("ws://192.168.1.18:8081");
        ConnectClient();
    }

    private static void ConnectClient()
    {
        _webSocket.OnOpen += OnOpen;
        _webSocket.OnClose += OnClose;
        _webSocket.OnError += OnError;
        _webSocket.OnMessage += OnMessage;
        
        _webSocket.Connect ();
    }
    
    private static void OnOpen(object sender, EventArgs e)
    {
        Debug.Log("Client - OnOpen");
    }
    
    private static void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Client - OnClose");
        
        _webSocket.OnOpen -= OnOpen;
        _webSocket.OnClose -= OnClose;
        _webSocket.OnError -= OnError;
        _webSocket.OnMessage -= OnMessage;
    }
    
    private static void OnError(object sender, ErrorEventArgs e)
    {
        Debug.Log($"Client - OnError : {e.Message}");
    }

    private static void OnMessage(object sender, MessageEventArgs e)
    {        
       Debug.Log($"Client - OnMessage : {e.Data}");
    }
}