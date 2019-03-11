using UnityEngine;

public class BoundingBoxComponent : MonoBehaviour
{

    private GameObject cam;
    private GameObject[] players = new GameObject[1];


    [SerializeField] float boxHeight = 5.0f;
    [SerializeField] float boxWidth = 10.0f;

    private void Start()
    {
        cam = GameManager.GM.CurrentGameMode.currentCamera;
        players[0] = GameManager.GM.CurrentGameMode.currentFishPlayer;
        players[1] = GameManager.GM.CurrentGameMode.currentBoatPlayer;

        if(players[0] == null)
        {
            this.enabled = false;
        }

    }


    private void Update()
    {

        foreach(GameObject x in players)
        {
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
