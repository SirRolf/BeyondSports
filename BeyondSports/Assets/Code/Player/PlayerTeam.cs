using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeam : MonoBehaviour
{
    public int trackingId;

    [SerializeField]
    private Material neutral ,team0Material, team1Material, team3Material;

    private int team;

    void Awake()
    {
        switch (team)
        {
            case 0:
                GetComponent<Renderer>().material = team0Material;
                break;
            case 1:
                GetComponent<Renderer>().material = team1Material;
                break;
            case 3:
                GetComponent<Renderer>().material = team3Material;
                break;
            default:
                GetComponent<Renderer>().material = neutral;
                break;
        }
    }
    
    public void ChangeTeam(int _team)
    {
        if (team != _team)
        {
            team = _team;
            switch (team)
            {
                case 0:
                    GetComponent<Renderer>().material = team0Material;
                    break;
                case 1:
                    GetComponent<Renderer>().material = team1Material;
                    break;
                case 3:
                    GetComponent<Renderer>().material = team3Material;
                    break;
                default:
                    GetComponent<Renderer>().material = neutral;
                    break;
            }
        }
    }
}
