/*********************************************************************************
 *Copyright(C) 2016 by DefaultCompany
 *All rights reserved.
 *FileName:     UVOSCOUTSlider.cs
 *Author:       李友涛
 *Version:      1.0
 *UnityVersion：5.5.0f3
 *Date:         12/13/2016
 *Time:			6:53:28 PM
 *Description:   
 *History:  
**********************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UVOSCOUTSlider : UVOSCOUT
{
    private void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener((value) =>
        {
            WriteData(value);
        });
    }
}
