using UnityEngine;

public class PartScript : MonoBehaviour
{
    GameManager game;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        game = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        rb = game.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (game.IsInGame)
        {
            transform.localPosition -= new Vector3(0, 0, game.speed);
            Physics.SyncTransforms();
            if (transform.localPosition.z < -50)
            {
                game.CreateNewPart(2,true);
                Destroy(gameObject);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
