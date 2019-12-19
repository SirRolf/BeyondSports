using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerControler : MonoBehaviour
{
    static string path = "Assets/Data/match_data.dat";
    
    private float timer = 0;

    [SerializeField]
    private GameObject player, ball;

    private StreamReader reader = new StreamReader(path);

    void Start()
    {
        GameObject newBall = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
        newBall.transform.parent = GameObject.Find("Match").transform;
        newBall.name = "Ball";
        for (int i = 1; i <= 29; i++)
        {
            GameObject newPlayer = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            newPlayer.GetComponent<PlayerTeam>().trackingId = i;
            newPlayer.transform.parent = GameObject.Find("Match").transform;
            newPlayer.name = "Player" + i;
        }
    }

    void Update()
    {
        if (timer <= 4)
        {
            timer += Time.deltaTime;
            string[] tokens = ReadString(1).Split(';');
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                string[] individualPlayerData = tokens[i].Split(',');
                GameObject myPlayer = GameObject.Find("Player" + individualPlayerData[1]);
                myPlayer.GetComponent<PlayerTeam>().ChangeTeam(int.Parse(individualPlayerData[0]));
                myPlayer.transform.GetChild(0).GetComponent<PlayerNumber>().ChangeTeam(individualPlayerData[2]);
                myPlayer.GetComponent<Movement>().Move(float.Parse(individualPlayerData[3]), float.Parse(individualPlayerData[4]));
            }
        }
        else
        {
            timer = 0;
        }
    }

    private string ReadString(int dataObject)
    {
        string[] tokens = reader.ReadLine().Split(':');
        return tokens[dataObject];
    }
}
