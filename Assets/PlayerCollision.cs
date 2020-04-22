using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + " collided with: " + collision.gameObject.name);
        if (collision.gameObject == LevelMgr.inst.Ethan) {
            LevelMgr.inst.score += 100;
            gameObject.SetActive(false);
            SoundMgr.inst.Play(SoundMgr.inst.coinEthan);
        }
    }
}
