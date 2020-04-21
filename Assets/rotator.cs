using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        circumference = entity.size * Mathf.PI * 2;
    }
    public float circumference = Mathf.PI * 2;
    public Entity entity;
    public Vector3 eulerAngles = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        entity.rotationRate = 360 * entity.speed / circumference ;
        eulerAngles.x = Utils.Degrees360(eulerAngles.x + entity.rotationRate * Time.deltaTime);
        transform.localEulerAngles = eulerAngles;
    }

}
