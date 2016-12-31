using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GSM : MonoBehaviour
{

    public GameObject player;
    public GameObject gsbtn;
    public Text title;

    private int state = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buttonClicked() {

        StartLevel();
         

    }

    public void GameOver()
    {
        gsbtn.SetActive(true);
        gsbtn.GetComponent<Text>().text = "Play Again";
        title.text = "Game Over";
    }
    public void StartLevel()
    {
        Instantiate(player, Vector3.zero, Quaternion.identity);
        title.text = "Level 1";
        gsbtn.SetActive(false);
      
    }
}
