using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.VersionControl;

public class AssetModificationProcessorSample : UnityEditor.AssetModificationProcessor
{
    static void OnWillCreateAsset(string assetName)
    {
        Debug.Log($"OnWillCreateAsset {assetName}");
    }

    private static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
    {
        Debug.Log($"OnWillDeleteAsset{assetPath}/{options}");
        if (EditorUtility.DisplayDialog("删除目录", "确定要删除吗?", "确定", "取消"))
        {
            return AssetDeleteResult.DidNotDelete;
        }
        else
        {
            return AssetDeleteResult.FailedDelete;
        }
    }

    private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
    {
        Debug.Log($"OnWillMoveAsset{sourcePath}=>{destinationPath}");
            
        if (EditorUtility.DisplayDialog("移动目录", $"确定要移动吗?{sourcePath}=>{destinationPath}", "确定", "取消"))
        {
            return AssetMoveResult.DidNotMove;
        }
        else
        {
            return AssetMoveResult.FailedMove;
        }
    }

    private static string[] OnWillSaveAssets(string[] paths)
    {
        Debug.Log($"OnWillSaveAssets{paths.Length}");
        return paths;
    }

    private static void FileModeChanged(string[] paths, FileMode mode)
    {
        Debug.Log($"FileModeChanged ({mode})");

        foreach (var path in paths)
        {
            Debug.Log(path);
        }
    }

    private static bool MakeEditable(string[] paths, string prompt, List<string> outNotEditablePaths)
    {
        Debug.Log("MakeEditable");
        foreach (var path in paths)
        {
            Debug.Log(path);
        }

        return true;
    }
}
