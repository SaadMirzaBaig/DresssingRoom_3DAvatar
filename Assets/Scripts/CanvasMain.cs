using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] private Users userScriptableObjects;
    [SerializeField] private DataHolder dataHolder;

    [SerializeField] private InputField user_name;
    [SerializeField] private InputField user_password;

    private void OnWelcome(string name, string pass, List<Material> clothMat)
    {
        //Set the values of Main character scene
        dataHolder.username_set = name;
        dataHolder.password_set = pass;

        //clear the list before populating
        dataHolder.clothMaterialSet.Clear();
        foreach (var item in clothMat)
        {
            dataHolder.clothMaterialSet.Add(item);
        }

        //Load into the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void OnLogin()
    {
        //Checking if username password exists
        foreach(var userScriptableObject in userScriptableObjects.UsersList)
        {
            if( user_name.text == userScriptableObject.username && user_password.text == userScriptableObject.password)
            {
                OnWelcome(userScriptableObject.username, userScriptableObject.password,userScriptableObject.ClothMaterial);
                break;
            }
            
        }
    }
}
