using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace SaveConfig
{

    [System.Serializable]
    public class JsonMap
    {
        public List<JsonMapObj> datas;

        //public Dictionary<string, string> dic;

        public JsonMapDic dic;
    }

    [System.Serializable]
    public class JsonMapObj
    {
        public int id;
        public string game_name;
        public string game_company;
        public int version;
        public string other;
    }

    [System.Serializable]
    public class JsonMapDic
    {
        public string aa;
        public string bb;
        public string cc;
    }


    public class SaveConfig : MonoBehaviour
    {
        private static SaveConfig inst = null;

        public static SaveConfig Inst
        {
            get
            {
                if (inst == null)
                {
                    var go = new GameObject("SaveConfig");
                    var s =go.AddComponent<SaveConfig>();
                    inst = s;
                    //print("ÊµÀýÓÐÁË");
                }

                return inst;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public    void test()
        {
            print("i am test");
            /*
            var txt = Resources.Load<TextAsset>("Config/main");
            JsonMap j = JsonUtility.FromJson<JsonMap>(txt.text);
            print(j);

            foreach (var item in j.datas)
            {
                print($"{item.id} {item.game_company} {item.game_name} {item.version} {item.other}");
            }
            print(j.dic.aa);
            print(j.dic.bb);
            print(j.dic.cc);
            */
        }

       public T LoadJson<T>(string jsonPath) where T:class
        {
            var txt = Resources.Load<TextAsset>(jsonPath);
            T res = JsonUtility.FromJson<T>(txt.text);

            return res;
        }





       private  string GetFileName<T>()
        {
            return typeof(T).Name + ".txt";
        }

        public T LoadData<T>() where T : new()
        {
            var tName = GetFileName<T>();
            var saveFile = Path.Combine(Application.persistentDataPath, tName);

            if (File.Exists(saveFile) == false)
            {
                File.WriteAllText(saveFile, "", new UTF8Encoding(false));
            }

            var tempFileStr = File.ReadAllText(saveFile,
                new UTF8Encoding(false));

            if (tempFileStr == "")
            {
                return new T();
            }
            else
            {
                return JsonUtility.FromJson<T>(tempFileStr);  // JsonMapper.ToObject<T>(tempStr);
            }
        }

        internal void SaveData<T>(T saveObj)
        {
            var tName = GetFileName<T>();
            var jsonStr = JsonUtility.ToJson(saveObj, true);  //JsonMapper.ToJson(saveObj);

            File.WriteAllText(System.IO.Path.Combine(Application.persistentDataPath, tName), jsonStr,
                new UTF8Encoding(false));
        }

    }

}
