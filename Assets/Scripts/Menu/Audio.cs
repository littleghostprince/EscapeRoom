using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource m_mainMusic = null;
    [SerializeField] AudioSource m_static = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (m_mainMusic.isPlaying)
        {
            m_mainMusic.Pause();
            m_static.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(m_mainMusic.isPlaying == false)
        {
            m_mainMusic.UnPause();
            m_static.Stop();
        }
    }
}
