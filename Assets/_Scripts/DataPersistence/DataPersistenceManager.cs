using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [field: Header("File Storage Config")]
    [SerializeField] private string _fileName;
    
    public static DataPersistenceManager Instance{get;private set;}

    private List<IDataPersistence> _dataPersistenceObjects;
    private GameData _gameData;
    private FileDataHandler _fileDataHandler;

    public string GetFileName() => _fileName;
    private void Awake() {
        if(Instance != null)
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        Instance = this;
    }

    private void Start() {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath,_fileName);
        _dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame(){
        _gameData = new GameData();
    }

    public void LoadGame(){
        _gameData = _fileDataHandler.Load();
        
        if(_gameData==null){
            Debug.Log("Save don't found");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObj in _dataPersistenceObjects){
            dataPersistenceObj.LoadData(_gameData);
        }
    }

    public void SaveGame(){
         foreach(IDataPersistence dataPersistenceObj in _dataPersistenceObjects){
            dataPersistenceObj.SaveData(ref _gameData);
        }
        _fileDataHandler.Save(_gameData);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
