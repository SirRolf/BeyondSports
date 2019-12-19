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

    private GameObject myBall;

    private StreamReader reader = new StreamReader(path);

    void Start()
    {
        // Make a ball that is the child of Match
        GameObject newBall = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
        newBall.transform.parent = GameObject.Find("Match").transform;
        newBall.name = "Ball";
        myBall = newBall;
        // Make all the players and give them identical names
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
            //spliting from the ball and framecount players
            string[] playerTokens = ReadString(1).Split(';');
            //all player changes
            for (int i = 0; i < playerTokens.Length - 1; i++)
            {
                //splitting all components for the player
                string[] individualPlayerData = playerTokens[i].Split(',');
                GameObject myPlayer = GameObject.Find("Player" + individualPlayerData[1]);
                myPlayer.GetComponent<PlayerTeam>().ChangeTeam(int.Parse(individualPlayerData[0]));
                myPlayer.transform.GetChild(0).GetComponent<PlayerNumber>().ChangeTeam(individualPlayerData[2]);
                myPlayer.GetComponent<Movement>().Move(float.Parse(individualPlayerData[3]), 0,float.Parse(individualPlayerData[4]));
            }
            //splitting ball from the player and framecount
            string[] ballTokens = ReadString(2).Split(';');
            //all ball changes
            for (int i = 0; i < ballTokens.Length - 1; i++)
            {
                string[] individualBallData = ballTokens[i].Split(',');
                myBall.GetComponent<Movement>().Move(float.Parse(individualBallData[0]), float.Parse(individualBallData[2]), float.Parse(individualBallData[1]));
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
