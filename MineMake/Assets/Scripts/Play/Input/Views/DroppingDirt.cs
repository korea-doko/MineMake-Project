using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DroppingDirt : MonoBehaviour
{
    public event EventHandler onParticleDurationIsOver;

    public ParticleSystem ps;

    public void Init(int i)
    {
        ps = this.GetComponent<ParticleSystem>();

        ParticleSystem.MainModule main = ps.main;
        main.stopAction = ParticleSystemStopAction.Callback;

        Hide();
    }

    
    public void Show(Vector3 _pos)
    {
        this.transform.position = _pos;
        
        //ParticleSystem.ShapeModule sm = ps.shape;
        //sm.randomDirectionAmount = UnityEngine.Random.Range(0.0f, 1.0f);
        //sm.randomPositionAmount = UnityEngine.Random.Range(0.0f, 1.0f);
        //sm.sphericalDirectionAmount = UnityEngine.Random.Range(0.0f, 1.0f);

        this.gameObject.SetActive(true);     
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    private void OnParticleSystemStopped()
    {
        onParticleDurationIsOver(this, EventArgs.Empty);
    }
}
