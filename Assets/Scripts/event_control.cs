using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class event_control : MonoBehaviour {
    public GameObject factoryPre;
    public GameObject apartmentPre;
    public build_bottom[] button;
    public void DidClickBuildFactory()
    {
        start_build(building_types.factory);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            start_build(building_types.apartment);
        }
    }

    public void DidClickBuildButton()
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
            obj.GetComponent<BuildingClass>().state = build_state.Build;
            //	设置当前状态为建造状态
            main.build_mode = true;

        }
    }
}
