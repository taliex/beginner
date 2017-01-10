using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GSM : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    private GameObject genedplayer;

    public Button btn;
    public Text btntext;
    public Text title;

    private int state = 0;
    private int preState = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (genedplayer ==null && state == 1) {
            state = 2;
        }

        if (preState != state)
        {
            switch (state)
            {
                case 0:
                    title.text = "tracing game";
                    btntext.text= "Start";
                    btn.gameObject.SetActive(true); break;
                case 1:
                    title.text = "level 1";
                    btn.gameObject.SetActive(false); break;
                case 2:
                    btn.gameObject.SetActive(true);
                    btntext.text = "play again";
                    title.text = "Game over";
                    break;
            }

            preState = state;
        }
    }

    public void setState(int state) {
        this.state = state;
    }

    public void genPlayer() {
        genedplayer = (GameObject)Instantiate(player,Vector3.zero,Quaternion.identity);
    }

    public void genEnemy() {
        Instantiate(enemy, new Vector3(0,2),Quaternion.identity);
    }

}

    

