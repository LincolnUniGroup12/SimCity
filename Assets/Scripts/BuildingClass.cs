/* Ruoyu Gu*/
using UnityEngine;
using System.Collections;
public class BuildingClass : MonoBehaviour
{
    public GameObject factoryPre;
    public GameObject apartmentPre;
    public bool is_building = false;
    public int wide, leigh; // building size
    int price;  //building price
    public building_types type;
    bool canBuild = true;
    void State_Machine()
    {
        switch (is_building)
        {
            case false:
                normal();
                break;
            case true:
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
            is_building = false;
        }
    }
    void Update()
    {
        State_Machine();
    }


    public enum building_types
    {
        factory,
        apartment,
    }
    public void DidClickBuildFactory()
    {
        start_build(building_types.factory);
    }


    public void DidClickBuildApartment()
    {
        start_build(building_types.apartment);
    }
     public void start_build(building_types t)
    {
        //	判断是否处于正常状态
        if (!main.build_mode)
        {
            //	创建游戏对象用的预设体
            GameObject tempPre = null;
            //	判断建筑物类型
            switch (t)
            {
                case building_types.factory:
                    //	建造兵营
                    tempPre = factoryPre;
                    break;
                case building_types.apartment:
                    //	建造旗帜
                    tempPre = apartmentPre;
                    break;

            }
            //	用预设体创建建筑物
            GameObject obj = Instantiate(tempPre, new Vector3(1000f, 1000f, 1000f), Quaternion.identity) as GameObject;
            //	设置建筑物为建造状态
            obj.GetComponent<BuildingClass>().is_building = true;
            //	设置当前状态为建造状态
            main.build_mode = true;
           
        }
    }
}