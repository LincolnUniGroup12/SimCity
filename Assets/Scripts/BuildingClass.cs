/* Ruoyu Gu*/
using UnityEngine;
using System.Collections;
public class BuildingClass : MonoBehaviour
{
    public int wide, leigh; // building size
    int price;  //building price
    bool canBuild = true;
    public building_types type;
    public build_state state;
    void State_Machine()
    {
        switch (state)
        {
            case build_state.Normal:
                normal();
                break;
            case build_state.Build:
                build();
                break;
        }
    }
    void normal()
    {
    }
    private void build()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit = Physics.RaycastAll(ray);
        foreach (RaycastHit hitInfo in hit)
        {
            if (hitInfo.transform.tag == "Ground")
            {
                transform.position = hitInfo.point;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            state = build_state.Normal;
            main.build_mode = false;
        }
    }
    void Update()
    {
        State_Machine();
    }
    
}
public enum building_types
{
    factory,
    apartment,
}
public enum build_state
{
    Normal=0,
    Build,
}