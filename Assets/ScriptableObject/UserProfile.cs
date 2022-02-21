using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "User", menuName = "ScriptableObjects/UserProfile", order = 1)]
public class UserProfile : ScriptableObject
{
    public string username;
    public string password;
    public List<Material> ClothMaterial;
}
