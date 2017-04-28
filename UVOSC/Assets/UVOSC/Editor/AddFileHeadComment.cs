/*********************************************************************************
 *Copyright(C) 2016 by 北京华丽达视听
 *All rights reserved.
 *FileName:     AddFileHeadComment.cs
 *Author:       李友涛
 *Version:      1.0
 *UnityVersion：5.3.4f1
 *Date:          2016-03-31 
 *Description:  在unity创建c#脚本时替换脚本中的属性值。
 *History:  
**********************************************************************************/
using UnityEditor;
using UnityEngine;
using System.IO;

public class AddFileHeadComment : UnityEditor.AssetModificationProcessor
{
    /// <summary>
    /// 此函数在asset被创建完，文件已经生成到磁盘上，但是没有生成.meta文件和import之前被调用
    /// </summary>
    /// <param name="newFileMeta">newfilemeta 是由创建文件的path加上.meta组成的</param>
    public static void OnWillCreateAsset(string newFileMeta)
    {
        string newFilePath = newFileMeta.Replace(".meta","");
        string fileExt = Path.GetExtension(newFilePath);
        if (fileExt != ".cs")
        {
            return;
        }
        //注意，Application.datapath会根据使用平台不同而不同
        string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
        string scriptContent = File.ReadAllText(realPath);

        //这里实现自定义的一些规则
        scriptContent = scriptContent.Replace("#YEAR#", System.DateTime.Now.Year.ToString());
        scriptContent = scriptContent.Replace("#SCRIPTFULLNAME#", Path.GetFileName(newFilePath));
        scriptContent = scriptContent.Replace("#COMPANYNAME#", PlayerSettings.companyName);
        scriptContent = scriptContent.Replace("#VERSION#", "1.0");
        scriptContent = scriptContent.Replace("#UNITYVERSION#", Application.unityVersion);
        scriptContent = scriptContent.Replace("#DATE#", System.DateTime.Now.ToShortDateString());
        scriptContent = scriptContent.Replace("#TIME#", System.DateTime.Now.ToLongTimeString());
        File.WriteAllText(realPath,scriptContent);
    }

}
