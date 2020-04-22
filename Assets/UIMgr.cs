using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public Text Score;
    public int score;
    public Text Health;

    // Start is called before the first frame update
    void Start()
    {
        //lives = LevelMgr.inst.maxEnemies;
    }

    public float lives = 10;
    // Update is called once per frame
    void Update()
    {
        if(lives > 0) {
            score = Mathf.RoundToInt(Time.realtimeSinceStartup);
            Score.text = score.ToString("D3");
        } else {
            PlayerPrefs.SetInt("Score", score);
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }

    public List<Entity> collidedEntities = new List<Entity>();
    public void UpdateHealth(Entity ent)
    {
        if(null == collidedEntities.Find(x => x.name == ent.name)) { 
            collidedEntities.Add(ent);
            lives -= ent.damage;
            Health.text = (Mathf.RoundToInt(lives)).ToString("D3");
        }

    }

}
