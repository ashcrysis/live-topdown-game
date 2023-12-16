using UnityEngine;
using System.IO;
using System;

public class FileInputState : MonoBehaviour
{
    public int x;
    public int y;
    public int itemIndex;
    public TextAsset file;
    public GameObject player;
    public ItemControlelr index;
    public GameObject Camera;
    private Boolean hasRunAtRuntime = false;
    void Start()
    {
        
        var lines = file.text.Split(",");

        foreach (string line in lines)
        {
            string[] keyValue = line.Split(':');
            string key = keyValue[0].Trim();
            string value = keyValue[1].Trim();
            
            if (key == "x")
                x = int.Parse(value);
            else if (key == "y")
                y = int.Parse(value);
            else if (key == "ItemIndex")
                itemIndex = int.Parse(value);
        }

     if (x != (int)player.transform.position.x || y != (int)player.transform.position.y){
            player.transform.position = new Vector3(x,y,player.transform.position.z);
            Camera.transform.position = new Vector3(x,y,Camera.transform.position.z);
        }    
        if ( itemIndex != (int) index.itemIndex)
        {
            index.itemIndex = itemIndex;
        }
    hasRunAtRuntime = true;
    }


    private void Update() {
        if (hasRunAtRuntime){
        if (x != (int)player.transform.position.x || y != (int)player.transform.position.y || itemIndex != (int) index.itemIndex ){
        if ( x != (int)player.transform.position.x)
        {
            x = (int) player.transform.position.x;
        }
           if ( y != (int)player.transform.position.y)
        {
            y = (int) player.transform.position.y;
        }
        if ( itemIndex != index.itemIndexAux)
        {
            itemIndex = (int) index.itemIndexAux;
        }
    UpdateFile();
    }}
    }
    private void UpdateFile()
    {
        // Create a string with the updated values
        string updatedData = "x:" + x + ",\ny:" + y + ",\nItemIndex:" + itemIndex;
        
        // Write the updated data back to the file
        File.WriteAllText("Assets/data.txt.txt", updatedData);

        Debug.Log(updatedData);
    }    
    }
