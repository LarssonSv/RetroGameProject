using UnityEngine;

public class BoundingBox : MonoBehaviour
{

    private GameObject cam;
    private GameObject player;


    [SerializeField] float boxHeight = 5.0f;
    [SerializeField] float boxWidth = 10.0f;

    private void Start()
    {
        cam = GameManager.GM.CurrentGameMode.currentCamera;
        player = GameManager.GM.CurrentGameMode.currentPlayer;
    }


    private void Update()
    {

        //BoundingBox Y
        if (player.transform.position.y < (cam.transform.position.y - boxHeight))
        {
            player.transform.position = new Vector3(player.transform.position.x, (cam.transform.position.y - boxHeight), 0.0f);
        }
        else if (player.transform.position.y > (cam.transform.position.y + boxHeight))
        {
            player.transform.position = new Vector3(player.transform.position.x, (cam.transform.position.y + boxHeight), 0.0f);
        }

        //BoundingBox X
        if(player.transform.position.x < (cam.transform.position.x - boxWidth))
        {
            player.transform.position = new Vector3((cam.transform.position.x - boxWidth), player.transform.position.y , 0.0f);
        }
        else if(player.transform.position.x > (cam.transform.position.x + boxWidth))
        {
            player.transform.position = new Vector3((cam.transform.position.x + boxWidth), player.transform.position.y, 0.0f);
        }


    }


}
