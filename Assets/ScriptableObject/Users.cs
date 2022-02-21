using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData", order = 2)]
public class Users : ScriptableObject
{
    public List<UserProfile> UsersList;
}
