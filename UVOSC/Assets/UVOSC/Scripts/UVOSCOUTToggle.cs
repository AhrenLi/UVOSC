/*********************************************************************************
 *Copyright(C) 2016 by DefaultCompany
 *All rights reserved.
 *FileName:     OSCOUTToggle.cs
 *Author:       李友涛
 *Version:      1.0
 *UnityVersion：5.5.0f3
 *Date:         12/13/2016
 *Time:			7:03:57 PM
 *Description:   
 *History:  
**********************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UVOSCOUTToggle : UVOSCOUT
{
    private void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener((value) =>
        {
            WriteData(value);
        });
    }
}
