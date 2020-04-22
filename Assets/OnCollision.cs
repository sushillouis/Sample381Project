using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Ethan = LevelMgr.inst.Ethan;
    }

    public float elapsedTime = 0;
    public float period = 1;
    // Update is called once per frame
    void Update()
    {
        if(entity.state == EState.Bouncing) {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > period) {
                entity.state = priorState;
            }
        }
    }

    public GameObject Ethan;
    public Entity entity;
    public UnitAI entityUAI;
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log(entity.name + " exited from with " + collision.gameObject.name);
        if (collision.collider.gameObject == Ethan) {
            entityUAI.StopAndRemoveAllCommands();
            entity.speed = entity.desiredSpeed = 0;
            entity.GetComponent<AudioSource>().Stop();
            LevelMgr.inst.UpdateHealth(entity);
        }
    }
    public EState priorState;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(entity.name + " collided with " + collision.gameObject.name);
        if (entity.state != EState.Bouncing && 
             collision.gameObject != LevelMgr.inst.GroundCube && 
             collision.gameObject != Ethan) {
            entity.velocity = Vector3.Reflect(entity.velocity, collision.contacts[0].normal);//- entity.velocity;
            entity.desiredHeading = Utils.Degrees360(Mathf.Rad2Deg * Mathf.Atan2(entity.velocity.x, entity.velocity.z));
            entity.heading = entity.desiredHeading;
            priorState = entity.state;
            entity.state = EState.Bouncing;
            elapsedTime = 0;
        }
        if(collision.gameObject == Ethan) 
            SoundMgr.inst.Play(SoundMgr.inst.ballEthan);

        if (collision.gameObject.name.StartsWith("Obs"))
            SoundMgr.inst.Play(SoundMgr.inst.ballBall);
    }
}
