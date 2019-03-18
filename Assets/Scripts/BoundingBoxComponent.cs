using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Author: Simon

public class BoundingBoxComponent : MonoBehaviour
{
    //Privates
    private GameObject cam;
    private List<GameObject> players = new List<GameObject>();
    [SerializeField] float boxHeight = 5.0f;
    [SerializeField] float boxWidth = 10.0f;

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


    private void Update()
    {

        foreach(GameObject x in players)
        {
            //BoudingBox Y
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
            else if (x.transform.position.x > (cam.transform.position.x + boxWidth))
            {
                x.transform.position = new Vector3((cam.transform.position.x + boxWidth), x.transform.position.y, 0.0f);
            }
        }

      



    }


}
