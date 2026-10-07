using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CurrentScore = 0;
    public int TargetScore = 0;


    public bool IsInGame;
    public GameObject Scroll;
    public GameObject Player;
    public Rigidbody Rigidbody;

    //i forgot which speed variable does what
    public float speed;
    public float realSpeed = 1;
    public float spinSpeed = 4;
    float a = 0; // aAW
    public GameObject[] Parts;
    public TextMeshPro score;
    
    //PAST ME, WHY HAVE YOU FORSAKEN ME BY WRITTING THIS SHITTY CODE LMFAO
    
    //HERE IS UR FUCKING FUNCTIONS ROWAN
    // vvv
    public void PlayerLoosed()
    {
        Debug.Log("L faps");
    }
    public void PlayerWinned()
    {
        Debug.Log("Teh epic player win");
    }
    void Start()
    {
        CreateNewPart(0,false,0);
        CurrentScore = 0;
        CreateNewPart(1, false, 0);
        CurrentScore = 0;
        CreateNewPart(2, false, 0);
        CurrentScore = 0;
        CreateNewPart(3, false, 0);
        CurrentScore = 0;
        CreateNewPart(4);
        CurrentScore = 0;
        CreateNewPart(5);
        CurrentScore = 0;
        CreateNewPart(6);
        CurrentScore = 0;
        CreateNewPart(7);
        CurrentScore = 0;
    }
    public void CreateNewPart(int partsAway = 8, bool dostuff = false,int ii = -1)
    {

        int aaaa = ii;
        if (ii == -1)
        {
            aaaa = Random.Range(0, Parts.Length);
        }
        GameObject a = Instantiate(Parts[aaaa], Scroll.transform);
        
        GameObject[] aa = GameObject.FindGameObjectsWithTag("Part");
        float zed = 0;

        for (int i = 0; i < aa.Length; i++)
        {
            zed = Mathf.Max(aa[i].transform.localPosition.z, zed);
        }

        if (partsAway == 0)
        {
            a.transform.localPosition = new Vector3(0, 0,0 );
        } else
        {
            if (dostuff )
            {
                a.transform.localPosition = new Vector3(0, 0, 50 + zed - 1);
            } else
            {
                a.transform.localPosition = new Vector3(0, 0, 50 + zed );
            }
            
        }
        CurrentScore += 1;
        if (CurrentScore > TargetScore)
        {
            PlayerWinned();
        }
        
    }
    private void Update()
    {
        Collider[] hits;
        //tiny ahh hitbox for my pussy ass players (i KNOW they stupid ass would complain with some corny shit like "oh that barely hit me" otherwise)
        //fuckass players that i hate
        //always bitching that my cool ass games dont cheat for them >:T
        hits = Physics.OverlapSphere(Player.transform.position, 0.01f, LayerMask.GetMask("Killer"));
        if (hits.Length > 0)
        {
            PlayerLoosed();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        score.text = CurrentScore.ToString() + " / " + TargetScore.ToString();
        if (IsInGame)
        {

            spinSpeed = speed * 100;
            a += spinSpeed * Time.fixedDeltaTime / 0.02f ;
            Rigidbody.rotation = Quaternion.AngleAxis(a%360, new Vector3(1, 0, 0));
            
            //Scroll.transform.localPosition -= new Vector3(0, 0, speed);
            //Scroll.transform.localPosition = new Vector3(Scroll.transform.localPosition.x, Scroll.transform.localPosition.y, Scroll.transform.localPosition.z % 10);
        }
    }
}
