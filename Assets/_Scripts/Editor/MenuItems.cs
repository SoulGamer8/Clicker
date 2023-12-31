using NeverMindEver.DataPersistent;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace NeverMindEver.Editor{
    public class MenuItems
    {
        [MenuItem("Custom Menu/Delete Save")]
        private static void DeleteSave(){
            string fileName = DataPersistenceManager.Instance.GetFileName();
            string fullPath =Path.Combine(Application.persistentDataPath, fileName);
            try{
                File.Delete(fullPath);
            }
            catch(Exception e){
                Debug.LogError("Error occurred when trying to save data file:" +fullPath+"\n"+e);
            }
        }
    }
}