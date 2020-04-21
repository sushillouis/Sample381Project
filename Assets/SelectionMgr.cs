using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMgr : MonoBehaviour
{
    public static SelectionMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {//Select first entity as default selected
        //must be done after Awake since list of entities is populated in EntityMgr.Awake
        UnSelectAll();
        //SelectEntity(EntityMgr.inst.entities[selectedEntityIndex]); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
            SelectNextEntity();
    }

    public int selectedEntityIndex = -1;
    public Entity selectedEntity = null;

    public void SelectNextEntity()
    {
        selectedEntityIndex = (selectedEntityIndex >= EntityMgr.inst.entities.Count - 1 ? 0 : selectedEntityIndex + 1);
        selectedEntity = EntityMgr.inst.entities[selectedEntityIndex];
        UnSelectAll();
        selectedEntity.isSelected = true;
    }

    void UnSelectAll()
    {
        foreach (Entity ent in EntityMgr.inst.entities)
            ent.isSelected = false;
    }

    public void SelectEntity(Entity ent)
    {
        if (ent != null && EntityMgr.inst.entities.Contains(ent)) {
            UnSelectAll();
            selectedEntity = ent;
            selectedEntity.isSelected = true;
            selectedEntityIndex = EntityMgr.inst.entities.FindIndex(x => (x == ent));
        }
    }

}
