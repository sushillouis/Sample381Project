using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<Entity>();
    }

    public Entity entity;
    // Update is called once per frame
    void Update()
    {
        entity.SelectionCircle.SetActive(entity.isSelected);
    }

    private void OnMouseDown()
    {
        SelectionMgr.inst.SelectEntity(entity);
    }
}
