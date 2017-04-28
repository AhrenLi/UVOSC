/*********************************************************************************
 *Copyright(C) 2016 by DefaultCompany
 *All rights reserved.
 *FileName:     UVOSCOUTButton.cs
 *Author:       李友涛
 *Version:      1.0
 *UnityVersion：5.5.0f3
 *Date:         12/13/2016
 *Time:			6:36:29 PM
 *Description:   
 *History:  
**********************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UVOSCOUTButton : UVOSCOUT
{
    public float oscMessage= 0.01f;   //参数

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            WriteData(oscMessage);
        });
    }
}
