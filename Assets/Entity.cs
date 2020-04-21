using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum EState
{
    Idle = 0,
    Moving,
    Following,
    Intercepting,
    Bouncing,
    Spawning,
    Dropping,
    Dying,
    Dead
}

[System.Serializable]
public enum EntityType
{
    Player = 0,
    Enemy,
    Neutral,
    Obstacle
}


public class Entity : MonoBehaviour
{

    public float size = 2;
    public float maxSpeed = 40;

    public float rotationSpeed;
    public float rotationRate = 10;

    public float speed;
    public float heading;
    public Vector3 velocity = Vector3.zero;
    public Vector3 position = Vector3.zero;
    public float acceleration = 1;
    public float turnRate = 3;

    public float desiredSpeed;
    public float desiredHeading;

    public bool isSelected;

    public EState state = EState.Idle;
    public EntityType entityType = EntityType.Enemy;

    public GameObject CameraRig;
    public GameObject SelectionCircle;
    public GameObject Commands;

    public float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
