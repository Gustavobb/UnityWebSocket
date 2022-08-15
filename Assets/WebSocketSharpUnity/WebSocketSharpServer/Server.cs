using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class Server : MonoBehaviour
{
    private WebSocketServer _wsServer;
    [SerializeField] private int _port = 4649;
    [SerializeField] private string _host = "localhost";
    private string _address { get { return "ws://" + _host + ":" + _port; } }

    public int Port { get { return _port; } }
    public string Host { get { return _host; } }
    public string Address { get { return _address; } }
    public WebSocketServer WsServer { get { return _wsServer; } }

    private void Awake()
    {
        InitServer();
    }

    private void InitServer()
    {
        // create a new WebSocket server
        _wsServer = new WebSocketServer(_address);

        // add the behaviors to the server
        AddImageBehavior();

        // start the server
        _wsServer.Start();
    }

    private void OnDestroy()
    {
        _wsServer.Stop();
    }

    private void AddImageBehavior()
    {
        // add the behavior to the server
        _wsServer.AddWebSocketService<ImageWebSocketBehaviour>("/Image");
    }
}