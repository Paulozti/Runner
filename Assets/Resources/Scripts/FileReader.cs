using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class FileReader : MonoBehaviour
{
    protected abstract string Data { get; }

    private void Start()
    {
        var path = Path.Combine(Application.streamingAssetsPath, Data);

        var file = new FileInfo(path);
        using (var stream = file.OpenText()) {
            ReadData(stream);
            SaveData(stream);
        }        
    }

    protected abstract void ReadData(StreamReader stream);

    protected abstract void SaveData(StreamReader stream);
}
