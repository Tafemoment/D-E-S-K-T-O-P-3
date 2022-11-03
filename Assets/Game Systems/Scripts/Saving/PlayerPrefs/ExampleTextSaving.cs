using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class ExampleTextSaving : MonoBehaviour
{
    public string[] whatWeAreSaving;
    //input values for saving
    public string[] showWhatWeAreSplitting;
    //display what we have loaded after we split a string
    public string[] showStringsLoaded;
    //put some of the values into an array
    public int showIntLoaded;
    //some of the values into an int
    public string path = "Assets/Game Systems/Resources/Save/TextSaveIfle.txt";
    //Path for saving and loading
    void Write()
    {
        StreamWriter writer = new StreamWriter(path, false);
        //true adds on
        //false replaces
        for (int i = 0; i < whatWeAreSaving.Length; i++)
        {
            if(i < whatWeAreSaving.Length - 1)
                //if its not the last piece of data
            {
                writer.Write(whatWeAreSaving[i] + '|');
                //when saving add a marker | to sepperate the data value
            }
            else //if we are the last piece of data
            {
                writer.Write(whatWeAreSaving[i]);
                    //we dpmt meed a ,arler | on the end as we are the end so just save the data
            }
        }
        writer.Close();
        //this lets us stop the data stream aka stop the process of saving so shit dont break
        AssetDatabase.ImportAsset(path);
        //this next part is only thing tied to Unity Editor
        //what this does is allows if we have the save file selected and displaying in the inspector... the inprctor updates when we save... else its look like shiz happens and that annoys Jay :)
    }
    void Read()
    {
        StreamReader reader = new StreamReader(path);
        string tempRead = reader.ReadLine();
        //temporarily store the loaded info
        showWhatWeAreSplitting = tempRead.Split('|');
        //splitting up the line at the marker | and putting each value into our array
        showStringsLoaded = new string[showWhatWeAreSplitting.Length - 1];
        //seperate our last value is the goal of the following

        //set our array to the size of our split data minus the last piece of data... as that will be an int
        for (int i = 0; i < showStringsLoaded.Length; i++)
        {
            showStringsLoaded[i] = showWhatWeAreSplitting[i];
        }
        showIntLoaded = int.Parse(showWhatWeAreSplitting[showWhatWeAreSplitting.Length - 1]);
        //assign and convert out int value
        reader.Close();
        //stop load shiz
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Read();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Write();
        }
    }

}
