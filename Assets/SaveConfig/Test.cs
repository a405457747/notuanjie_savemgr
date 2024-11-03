using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveConfig
{

    public class Test : MonoBehaviour
    {
        void Start()
        {
            //SaveConfig.Inst.test();
            var a = 3;
            a = a + 1;
            a = a + 2;
            print("a" + a);
        }

    }
}