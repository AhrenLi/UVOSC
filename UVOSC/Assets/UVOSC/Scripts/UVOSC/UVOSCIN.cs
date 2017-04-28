/*********************************************************************************
 *Copyright(C) 2016 by DefaultCompany
 *All rights reserved.
 *FileName:     UVOSCIN.cs
 *Author:       李友涛
 *Version:      1.0
 *UnityVersion：5.5.0f3
 *Date:         12/13/2016
 *Time:			5:00:21 PM
 *Description:   
 *History:  
**********************************************************************************/
using UnityEngine;
using System.Collections.Generic;

using System.Threading;
using Ventuz.OSC;

public class UVOSCIN : UVOSC
{
    public bool receiveOnStart = false;
    public Dictionary<string, object> argsDic = new Dictionary<string, object>();

    private UdpReader udpReader;        //udp读取
    private Thread readThread;      //接受线程

    private bool receive = false;       //是否开启接收数据
    private void Start()
    {
        if (receiveOnStart)
        {
            OnReceive();
        }
    }
    private void OnReceive()
    {
        readThread = new Thread(ReceiveData);
        receive = true;
        readThread.Start();
    }  
    private void ReceiveData()
    {
        udpReader = new UdpReader(oscPort);
        while (receive)
        {
            var data = udpReader.Receive();     //会阻塞主线程
            if (data != null)
            {
                OscBundle ob = (OscBundle)data;
                foreach (OscElement item in ob.Elements)
                {
                    if (item.Address.Equals(oscAddress))
                    {
                        argsDic.Clear();
                        for (int i = 0; i < item.Args.Length; i++)
                        {
                            argsDic.Add(item.Args[i].GetType().ToString(), item.Args[i]);
                        }
                        foreach (var dic in argsDic.Values)
                        {
                            Debug.Log(dic);
                        }
                    }
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        receive = false;
        if (udpReader != null)
        {
            //udpReader.Dispose();
            readThread.Abort();
            argsDic.Clear();
        }
    }
}
