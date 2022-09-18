using System;
using UnityEngine;

[DefaultExecutionOrder(-7)]
public class SFXManager : MonoBehaviour
{
    public enum SoundName
    {
        GameMusic, KeepOn, Silent, Grinder, Pick1, Pick2, Pick3
    }

    public static SFXManager Instance;

    public static bool soundMuted = false;
    
    [SerializeField]private Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }
    
    public void Play(Enum eEnum)
    {
        if (!soundMuted)
        {
            foreach (var s in sounds)
            {
                if (s.name == (SoundName)eEnum)
                {
                    s.source.Play();
                    return;
                }
            }
            Debug.LogWarning("Your sound named " + name + " does not exits");
        }
    }
    
    public void Stop(Enum eEnum)
    {
        if (!soundMuted)
        {
            foreach (var s in sounds)
            {
                if (s.name == (SoundName)eEnum)
                {
                    s.source.Play();
                    return;
                }
            }
            Debug.LogWarning("Your sound named " + name + " does not exits");
        }
    }

    [Serializable]
    public class Sound
    {
        public SoundName name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;
        [HideInInspector] public AudioSource source;
    }
}