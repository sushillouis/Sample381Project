using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AudioSource ballBall;
    public AudioSource ballEthan;
    public AudioSource ballCube;
    public AudioSource coinEthan;

    public void Play(AudioSource sound)
    {
        sound.Play();
    }


}
