using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obs in EntityMgr.inst.obstacles) {
            GameObject coin = Instantiate(coinPrefab, obs.transform);

            coins.Add(coin);
        }
    }
    public GameObject coinPrefab;
    public List<GameObject> coins = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        
    }



}
