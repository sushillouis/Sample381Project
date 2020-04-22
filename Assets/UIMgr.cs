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

    // Start is called before the first frame update
    void Start()
    {
        //lives = LevelMgr.inst.maxEnemies;
    }

    // Update is called once per frame
    void Update()
    {
 
    }


}
