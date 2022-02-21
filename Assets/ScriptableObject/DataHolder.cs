using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataHolder", menuName = "ScriptableObjects/DataHolder", order = 3)]

public class DataHolder : ScriptableObject
{
    public string username_set;
    public string password_set;
    public List<Material> clothMaterialSet;

}
