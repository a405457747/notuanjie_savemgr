using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveConfig
{

    public class Test : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SaveConfig.Inst.test();
            SaveConfig.Inst.test();
        }

    }
}