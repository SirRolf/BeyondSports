using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerControler : MonoBehaviour
{
    static string path = "Assets/Data/match_data.dat";

    private float frameCount = 0;
    private float timer = 0;

    [SerializeField]
    private GameObject player;

    void Start()
    {
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
            string[] tokens = ReadString(frameCount, 1).Split(';');
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                string[] individualPlayerData = tokens[i].Split(',');
                GameObject myPlayer = GameObject.Find("Player" + individualPlayerData[1]);
                myPlayer.GetComponent<PlayerTeam>().ChangeTeam(int.Parse(individualPlayerData[0]));
                myPlayer.transform.GetChild(0).GetComponent<PlayerNumber>().ChangeTeam(individualPlayerData[2]);
                myPlayer.GetComponent<PlayerMovement>().Move(float.Parse(individualPlayerData[3]), float.Parse(individualPlayerData[4]));
            }

            frameCount++;
        }
        else
        {
            timer = 0;
        }
    }

    private string ReadString(float line, int dataObject)
    {
        StreamReader reader = new StreamReader(path);
        for (int i = 0; i < line; i++)
        {
            reader.ReadLine();
        }
        string[] tokens = reader.ReadLine().Split(':');
        reader.Close();
        return tokens[dataObject];
    }
}
