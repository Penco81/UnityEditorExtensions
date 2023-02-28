using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class AssetDataBaseSample
{
    static void AssetDataBaseAPIs()
    {
        string path = "Assets/xxx/xxx.prefab";
        //Directory.Exists(path) 判断文件夹存在
        
        //判断文件存在
        if (!File.Exists(path))
        {
            Debug.Log("Not Exist Path :" + path);
        }

        string guid = AssetDatabase.AssetPathToGUID(path);
        
        GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);

        AssetDatabase.RenameAsset(path, "NewName");

        AssetDatabase.MoveAsset(path, "Assets/move.prefab");

        AssetDatabase.CopyAsset(path, "Assets/copy.prefab");
        
        //移动到回收站
        AssetDatabase.MoveAssetToTrash(path);
        //完全删除
        AssetDatabase.DeleteAsset(path);
            
        AssetDatabase.Refresh();
    }
}
