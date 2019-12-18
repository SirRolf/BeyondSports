using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumber : MonoBehaviour
{
    private string number;

    private void ChangeTeam(string _number)
    {
        if (number != _number)
        {
            number = _number;
            gameObject.GetComponent<TextMesh>().text = _number;
        }
    }
}
