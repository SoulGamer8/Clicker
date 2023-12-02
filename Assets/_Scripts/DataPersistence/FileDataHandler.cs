using System;
using System.IO;
using UnityEngine;

namespace NeverMindEver.DataPersistent{
    public class FileDataHandler 
    {
        private string _dataDirPath= "";
        private string _dataFileName ="";

        private bool _isUseEncryption =true;
        private readonly string _secretWord = "NeverMindEver";

        public FileDataHandler(string dataDirPath,string dataFileName,bool isUseEncryption){
            _dataDirPath = dataDirPath;
            _dataFileName = dataFileName;
            _isUseEncryption = isUseEncryption;
        }

        public GameData Load(){
            string fullPath = Path.Combine(_dataDirPath,_dataFileName);
            GameData loadData = null;
            if(File.Exists(fullPath)){
                try{    
                    string dataToLoad = "";

                    using(FileStream stream = new FileStream(fullPath,FileMode.Open)){
                        using(StreamReader reader = new StreamReader(stream)){
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

                    if(_isUseEncryption)
                        dataToLoad = EncryptDecrypt(dataToLoad);

                    loadData = JsonUtility.FromJson<GameData>(dataToLoad);
                }
                catch(Exception e){
                    Debug.LogError("Error occurred when trying to save data file:" +fullPath+"\n"+e);
                }
            }
            return loadData;
        }


        public void Save(GameData data){
            string fullPath = Path.Combine(_dataDirPath,_dataFileName);

            try{
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                string dataToStore = JsonUtility.ToJson(data,true);

                if(_isUseEncryption)
                    dataToStore= EncryptDecrypt(dataToStore);

                using (FileStream stream = new FileStream(fullPath,FileMode.Create)){
                    using(StreamWriter writer = new StreamWriter(stream)){
                        writer.Write(dataToStore);
                    }
                }
            }
            catch(Exception e){
                Debug.LogError("Error occurred when trying to save data file:" +fullPath+"\n"+e);
            }
        }

        private string EncryptDecrypt(string data){
            string modifiedData = "";
            for(int i =0;i<data.Length;i++){
                modifiedData +=(char)(data[i]^_secretWord[i % _secretWord.Length]);
            }
            return modifiedData;
        }
    }
}