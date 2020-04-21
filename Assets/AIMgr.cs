using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    public static AIMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 9;// LayerMask.GetMask("Water");
    }

    public RaycastHit hit;
    public int layerMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && CameraMgr.inst.isRTSMode && SelectionMgr.inst.selectedEntity != null) {
            if (Physics.Raycast(CameraMgr.inst.RTSCamera.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, layerMask)) {
                Debug.DrawLine(CameraMgr.inst.transform.position, hit.point, Color.yellow, 2); //for debugging
                Vector3 pos = hit.point;
                pos.y = 0;
                Entity ent = FindClosestEntInRadius(pos, rClickRadiusSq);
                if (ent == null) {
                    HandleMove(pos);
                } else {
                    if (Input.GetKey(KeyCode.LeftControl))
                        HandleIntercept(ent);
                    else
                        HandleFollow(ent);
                }
            } else {
                Debug.DrawRay(CameraMgr.inst.transform.position, 
                    CameraMgr.inst.transform.TransformDirection(Vector3.forward) * 1000, Color.white, 2);
            }
        }
    }

    void HandleMove(Vector3 point)
    {
        Move m = new Move(SelectionMgr.inst.selectedEntity, hit.point);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        //AddOrSet(uai, m);

        if (Input.GetKey(KeyCode.LeftShift))
            uai.AddCommand(m);
        else
            uai.SetCommand(m);

    }

    void HandleFollow(Entity ent)
    {
        Follow f = new Follow(SelectionMgr.inst.selectedEntity, ent, new Vector3(10, 0, 0));
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        AddOrSet(uai, f);
    }

    void HandleIntercept(Entity ent)
    {
        Intercept intercept = new Intercept(SelectionMgr.inst.selectedEntity, ent);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        AddOrSet(uai, intercept);
    }

    public void CreateIntercept(Entity source, Entity target, bool isAdd)
    {
        Intercept intercept = new Intercept(source, target);
        UnitAI uai = source.GetComponent<UnitAI>();
        if (isAdd)
            uai.AddCommand(intercept);
        else
            uai.SetCommand(intercept);
    }

    void AddOrSet(UnitAI uai, Command c)
    {
        if (Input.GetKey(KeyCode.LeftShift))
            uai.AddCommand(c);
        else
            uai.SetCommand(c);
    }

    public float rClickRadiusSq = 1000;
    public Entity FindClosestEntInRadius(Vector3 point, float rsq)
    {
        Entity minEnt = null;
        float min = float.MaxValue;
        foreach (Entity ent in EntityMgr.inst.entities) {
            float distanceSq = (ent.transform.position - point).sqrMagnitude;
            if (distanceSq < rsq) {
                if (distanceSq < min) {
                    minEnt = ent;
                    min = distanceSq;
                }
            }
        }
        return minEnt;
    }
}
