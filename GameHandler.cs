using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{

    PlayerData playerData = new PlayerData();

    public int myNum = 5;
    public string myName = "Not Sure";


    // A class to hold the data
    private class PlayerData
    {
        public string name;
        public int health;
    }

    void Update()
    {
        // TO JSON
        if (Input.GetKeyDown(KeyCode.B))
        {
            playerData.name = myName;
            playerData.health = myNum;
            string json = JsonUtility.ToJson(playerData);
            Debug.Log("The JSON string: " + json);
            File.WriteAllText(Application.dataPath + "/saveFile.json", json);    
        }

        //FROM JSON
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Name: " + loadedPlayerData.name + ", Health: " + loadedPlayerData.health);
        }

    }
}
