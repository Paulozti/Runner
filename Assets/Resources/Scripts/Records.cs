using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Records : FileReader
{
    protected override string Data => "records.txt";
    public Text recordList;
    public bool save = false;
    public Text saveName;

    private GameManager gameManager;
    private int[] recordListToCheck = new int[5];
    private String[] recordTexts = new String[5];
    private String path;

    private void Awake() {
        path = "Assets/StreamingAssets/" + Data;
        gameManager = FindObjectOfType<GameManager>();
    }

    protected override void ReadData(StreamReader stream) {
        if (!save)
            recordList.text = "";

        for (int i = 0; i < 5; i++) {
            String value = stream.ReadLine();

            if (!save)
                recordList.text += value + "\n";

            recordTexts[i] = value;
            recordListToCheck[i] = int.Parse(value.Split(' ').Last());
        }
    }
    protected override void SaveData(StreamReader stream){        
    }

    public void SaveRecord(){
        int retorno = CheckRecordToSave(0);
        if (retorno > -1){
            //save
            int record = gameManager.GetScore();
            saveName.text += "ZZZ";
            String save = saveName.text.Substring(0, 3).ToUpper() + " " + record;

            //procura e apaga dado         
            
            File.WriteAllText(path, "");

            //Salva o dado e todos abaixo, limite de 5
            for (int c = 0; c < 5; c++) {
                if (c == retorno){
                    SaveData(save);                    
                }else{
                    SaveData(recordTexts[c]);
                }
            }
        }
        else{
            Debug.Log("Not Save");
            gameManager.RestartGame();
        }        
    }

    private void SaveData(String value){
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(value);
        writer.Close();
    }

    public int CheckRecordToSave(int record){
        for (int i = 0; i < 5; i++){
            if (record > recordListToCheck[i]){
                return i;
            }
        }
        return -1;
    }
}
