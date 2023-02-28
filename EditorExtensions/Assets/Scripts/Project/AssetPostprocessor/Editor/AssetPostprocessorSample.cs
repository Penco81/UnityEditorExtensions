using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetPostprocessorSample : AssetPostprocessor
{
    private void OnPreprocessAnimation()
    {
        throw new NotImplementedException();
    }

    private void OnPostprocessAnimation(GameObject root, AnimationClip clip)
    {
        throw new NotImplementedException();
    }

    private void OnPreprocessTexture()
    {
        Debug.Log("OnPreprocessTexture:" + this.assetPath);
        TextureImporter importer = this.assetImporter as TextureImporter;
        importer.textureType = TextureImporterType.Sprite;
        importer.maxTextureSize = 512;
        importer.mipmapEnabled = false;
    }

    private void OnPostprocessTexture(Texture2D texture)
    {
        Debug.Log("OnPostprocessTexture:" + texture.name);
    }

    //任何资源
    private void OnPreprocessAsset()
    {
        
    }

    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        
    }
}
