using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New SO", menuName = "My New SO")]
public class MyNewSO : ScriptableObject
{
    public int age;
    public int height;
    public int speed;

    public NewPerson np = new NewPerson();

    public List<NewPerson> npList = new List<NewPerson>();

}

[System.Serializable]
public class NewPerson
{

}
