using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //ethanProxyEntity = ethanProxy.GetComponent<Entity>();
    }
    public GameObject Ethan;
    public GameObject GroundCube;
    public GameObject ethanProxy;
    public Entity ethanProxyEntity;
    public int count = 0;
    public int maxEnemies = 10;

    public Vector3 spawnPosition;
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
    }

    public float elapsedTimeInterval = 0;
    public float enemySpawnPeriod = 5;//seconds

    bool TimeIsUp(float timeInterval)
    {
        elapsedTimeInterval += Time.deltaTime;
        if(elapsedTimeInterval > timeInterval) {
            elapsedTimeInterval = 0;
            return true;
        }
        return false;
    }



}
