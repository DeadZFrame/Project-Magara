using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnvData", menuName = "Scriptable Object/Data")]
    public class EnvData : ScriptableObject
    {
        public Material firstEarth;
        public Material rockyEarth;
    }
}
