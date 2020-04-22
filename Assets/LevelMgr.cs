
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMgr : MonoBehaviour
{
    public static LevelMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public float startingLives = 3;
    public int startingScore = 0;
    public float startingCountdownSeconds = 120;
    public int startingNumberOfEnemies = 12;

    //------------------------------------------
    public GameObject Ethan;
    public GameObject GroundCube;
    public GameObject ethanProxy;
    public Entity ethanProxyEntity;
    int count = 0;
    int maxEnemies = 10;
    public int score; //oncollision accesses this, should be controlled
    float lives = 10;
    public Vector3 spawnPosition;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        lives = startingLives;
        score = startingScore;
        countDownSeconds = startingCountdownSeconds;
        maxEnemies = startingNumberOfEnemies;

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeIsUp(enemySpawnPeriod) && count < maxEnemies) {
            spawnPosition = ethanProxy.transform.position + ethanProxy.transform.forward * 20;
            spawnPosition.y = 0;
            Entity ent = EntityMgr.inst.CreateEntity(EntityType.Enemy, spawnPosition, Vector3.zero);
            AIMgr.inst.CreateIntercept(ent, ethanProxyEntity, false);
            ent.desiredSpeed = ent.maxSpeed;
            count++;
        }
        if (lives > 0) 
            ScoreText.text = score.ToString("D3");
        else
            EndLevel();

        if (countDownSeconds < 0)
            EndLevel();
        else
            countDownSeconds -= Time.deltaTime;
        CountdownTimer.text = Mathf.RoundToInt(countDownSeconds).ToString("D3");
    }

    public void EndLevel()
    {
        PlayerPrefs.SetInt("Score", score);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public float elapsedTimeInterval = 0;
    public float enemySpawnPeriod = 5;//seconds
    //------------------------------------------
    bool TimeIsUp(float timeInterval)
    {
        elapsedTimeInterval += Time.deltaTime;
        if(elapsedTimeInterval > timeInterval) {
            elapsedTimeInterval = 0;
            return true;
        }
        return false;
    }

    //------------------------------------------
    public Text HealthLivesText;
    public Text ScoreText;
    public Text CountdownTimer;
    float countDownSeconds = 180;

    public List<Entity> collidedEntities = new List<Entity>();
    public void UpdateHealth(Entity ent)
    {
        if (null == collidedEntities.Find(x => x.name == ent.name)) {
            collidedEntities.Add(ent);
            lives -= ent.damage;
            HealthLivesText.text = (Mathf.RoundToInt(lives)).ToString("D3");
        }
    }

}
