using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    PlayerMovement Mover;

    private void Start()
    {
        Mover = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Mover.Left();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Mover.Right();
        }

        if (Input.GetKey(KeyCode.W))
        {
            Mover.Up();
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Mover.Down();
        }

    }

    


}
