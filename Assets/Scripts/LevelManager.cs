using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();

    private PlayerScript playerScript;
    public int score = 0;
    public int tokenScore = 0;
    
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
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
