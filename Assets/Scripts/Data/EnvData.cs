using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnvData", menuName = "Scriptable Object/Data")]
    public class EnvData : ScriptableObject
    {
        public GameObject firstEarth;
        public GameObject rockyEarth;
    }
}
