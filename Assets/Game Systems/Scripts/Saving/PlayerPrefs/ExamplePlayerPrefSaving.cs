using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerPrefSaving : MonoBehaviour
{
    /*
      Pros
      - Prebuilt
        - Already has all the functions and functionality
        - easy to use
      - Saves a Key (name) and Value (data) similar to a dictionary
      - Easy to edit
    Cons
      - Not Flexible
      - Easy to edit - Players can easily mess with the file
      - Webplayer has a playerPrefs size limit 1MB

     What is it good for?
             - User/Options/Settings
    */

    public string stringToSaveAndLoad;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Test String"))
        {
            //if there is data called Test String
            Debug.Log("Data was found");
        }
        else
        {
            //there is no data called Test String
            Debug.Log("No save data");
        }

    }

    private void Start()
    {
        //Returns the value corresponding to key in the preference file if it exists.
        stringToSaveAndLoad = PlayerPrefs.GetString("Test String", "Chris Pratt");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Set = Write = Save
            //Sets the value of the preference indentified by key.
            PlayerPrefs.SetString("Test String", stringToSaveAndLoad);
            PlayerPrefs.SetInt("Test Int", 1);
            PlayerPrefs.SetFloat("Test float", 1f);
            //Writes all modified preference to disk.
            PlayerPrefs.Save();

        }
        //Delete String
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Removes key and its corresponding value from the preferences.
            PlayerPrefs.DeleteKey("Test String");
        }
        //Delete String
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Removes all keys and values from the references. Use with caution.
            PlayerPrefs.DeleteAll();

        }
    }
}
