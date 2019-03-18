using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Author: Simon

public class BoundingBoxComponent : MonoBehaviour
{
    //Privates
    private GameObject cam;
    private List<GameObject> players = new List<GameObject>();
    public List<GameObject> bots = new List<GameObject>();
    [SerializeField] float boxHeight = 5.0f;
    [SerializeField] float boxWidth = 10.0f;
    [SerializeField] float distanceDespawnBot = 4.0f;

    private void Start()
    {
        cam = this.gameObject;

        if (GameManager.GM.CurrentGameMode.currentFishPlayer)
        {
            players.Add(GameManager.GM.CurrentGameMode.currentFishPlayer);
        }

        if (GameManager.GM.CurrentGameMode.currentBoatPlayer)
        {
            players.Add(GameManager.GM.CurrentGameMode.currentBoatPlayer);
        }

        

        //this.enabled = false;
    }
    
    public void AddBot(GameObject bot)
    {
        if(bot)
        {
            bots.Add(bot);
        }
    }

    public void RemoveBot(GameObject bot)
    {
        if (bot)
        {
            bots.Remove(bot);
        }
    }

    private void Update()
    {
        foreach(GameObject x in players)
        {
            //BoundingBox Y
            if (x.transform.position.y < (cam.transform.position.y - boxHeight))
            {
                x.transform.position = new Vector3(x.transform.position.x, (cam.transform.position.y - boxHeight), 0.0f);
            }
            else if (x.transform.position.y > (cam.transform.position.y + boxHeight))
            {
                x.transform.position = new Vector3(x.transform.position.x, (cam.transform.position.y + boxHeight), 0.0f);
            }
            
            //BoundingBox X
            if (x.transform.position.x < (cam.transform.position.x - boxWidth))
            {
                x.transform.position = new Vector3((cam.transform.position.x - boxWidth), x.transform.position.y, 0.0f);
            }
            //right
            else if (x.transform.position.x > (cam.transform.position.x + boxWidth))
            {
                x.transform.position = new Vector3((cam.transform.position.x + boxWidth), x.transform.position.y, 0.0f);
            }
        }

        foreach(GameObject x in bots)
        {
            //BoundingBox X
            if (x.transform.position.x < (cam.transform.position.x - boxWidth - distanceDespawnBot))
            {
                x.SetActive(false);
            }
        }
    }
}
