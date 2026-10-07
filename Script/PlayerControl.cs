using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float TargetX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        TargetX = context.ReadValue <Vector2>().x * 4.7f;
    }
    // Update is called once per frame
    void Update()
    {
        
        //TargetX = Input.GetAxis("Horizontal");

        transform.position = Vector3.Lerp(transform.position, new Vector3(TargetX, transform.position.y, transform.position.z), 0.8f);

    }
}
