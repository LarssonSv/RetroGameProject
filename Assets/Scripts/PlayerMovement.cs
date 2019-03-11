using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float Speed = 5.0f;
    
    public void Left()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    public void Right()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    public void Up()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    public void Down()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

}
