using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem playparticleSystem;

    public void OnClick()
    {
        playparticleSystem.Play();
    }
}
