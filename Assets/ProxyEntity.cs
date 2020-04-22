using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyEntity : MonoBehaviour
{
    public int nPositions = 10;
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<Entity>();
        positions = new List<Vector3>();
        for(int i = 0; i < nPositions; i++) {
            positions.Add(transform.position);
        }
    }
    public Entity entity;
    public List<Vector3> positions;
    public GameObject Ethan;
    // Update is called once per frame
    void Update()
    {
        entity.position = Ethan.transform.localPosition;
        entity.heading = Utils.Degrees360(transform.localEulerAngles.y);
        positions.RemoveAt(0);
        positions.Add(transform.localPosition);
        entity.velocity = VelocityFromPositions(positions);
        entity.speed = entity.velocity.magnitude;

        //
    }

    public Vector3 VelocityFromPositions(List<Vector3> positions)
    {
        Vector3 diffSum = Vector3.zero;
        for(int i = 0; i < positions.Count - 1; i++) {
            diffSum += positions[i + 1] - positions[i];
        }
        return diffSum/(positions.Count - 1);
    }

}
