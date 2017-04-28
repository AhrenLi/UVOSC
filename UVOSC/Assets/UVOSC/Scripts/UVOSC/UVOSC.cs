/*********************************************************************************
 *Copyright(C) 2016 by huelead
 *All rights reserved.
 *FileName:     UVOSC.cs
 *Author:       李友涛
 *Version:      1.0
 *UnityVersion：5.5.0f3
 *Date:         12/7/2016
 *Time:			2:18:41 PM
 *Description:  UVOSC 基类 
 *History:  
**********************************************************************************/
using UnityEngine;

public  abstract class UVOSC : MonoBehaviour
{
    public string oscIP = @"127.0.0.1";     //OSC的默认IP地址
    public int oscPort = 7000;      //OSC默认端口号  
    public string oscAddress = @"/UVOSC";       //OSC默认 地址  
}
