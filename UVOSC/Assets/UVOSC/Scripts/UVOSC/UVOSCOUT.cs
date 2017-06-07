/*********************************************************************************
 *Copyright(C) 2016 by DefaultCompany
 *All rights reserved.
 *FileName:     UVOSCOUT.cs
 *Author:       李友涛
 *Version:      1.0
 *UnityVersion：5.5.0f3
 *Date:         12/13/2016
 *Time:			5:00:38 PM
 *Description:  使用OSC发出指令 
 *History:  
**********************************************************************************/
using UnityEngine;

using Ventuz.OSC;
public abstract class UVOSCOUT : UVOSC
{
    private UdpWriter udpWriter;        //udp写入

    /// <summary>
    /// 使用OSC协议发送数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <returns>发送结果</returns>
    public bool WriteData(params object[] data)
    {
        try
        {
			//hehe
            udpWriter = new UdpWriter(oscIP, oscPort);
            OscElement element = new OscElement(oscAddress, data);
            udpWriter.Send(element);
            return true;
        } 
        catch (System.Exception e)
        {
            Debug.LogError("发送失败：" + e.ToString()); 
        }
        return false;
    }

    private void OnApplicationQuit()
    {
        if (udpWriter != null)
            udpWriter.Dispose();
    }
}
