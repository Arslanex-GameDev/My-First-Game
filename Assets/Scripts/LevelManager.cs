using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();
    [SerializeField] private Text tokenText;

    private PlayerScript playerScript;
    public int score = 0;
    public int tokenScore = 0;
    private int tScore = 0;
    private float counter = 0;
    
    void Start()
    {
        tokenText.enabled = false ;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if(tScore<tokenScore){
            tokenText.text = tokenScore + "/3";
            tScore = tokenScore;
            tokenText.enabled = true;
            counter = Time.time;
        }
        if(Time.time - counter > 3f){
            tokenText.enabled = false;
        }
        if(playerScript.gameOver == true){
            losePanel.gameObject.SetActive(true);
            UpdateList("Player");
            UpdateList("Coin");
            UpdateList("jCoin");
            UpdateList("Token");
            UpdateList("Enemy");
            foreach(GameObject i in destroyAfterGame){
                Destroy(i, 3);
            }
        }
        if(tokenScore >= 3){
            winPanel.gameObject.SetActive(true);
            UpdateList("Player");
            UpdateList("Coin");
            UpdateList("jCoin");
            UpdateList("Token");
            UpdateList("Enemy");
            foreach(GameObject i in destroyAfterGame){
                Destroy(i, 3);
            }
        }
    }

    public void NextLevel(){
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex +1;
        int scenesIndex = SceneManager.sceneCountInBuildSettings -1;
        if(nextSceneIndex<=scenesIndex){
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void RestartLevel(){
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    private void UpdateList(string tag){
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }
}
