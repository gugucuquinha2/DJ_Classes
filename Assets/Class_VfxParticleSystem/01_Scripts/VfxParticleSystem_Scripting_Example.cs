using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxParticleSystem_Scripting_Example : MonoBehaviour
{
    // particle system component
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        // particle systems scripting works with modules
        // to change module's properties we need to make references to those modules:
        // - we can't change them directly

        // main module
        ParticleSystem.MainModule main = ps.main;
        main.startSize = 0.5f;
        main.startColor = Color.yellow;

        // emission module
        ParticleSystem.EmissionModule emission = ps.emission;
        emission.rateOverTime = 5;

        // shape module
        ParticleSystem.ShapeModule shape = ps.shape;
        shape.shapeType = ParticleSystemShapeType.Cone;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            // the particle system starts imitting new particles
            ps.Play();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            // stops the particle system from emitting new particles, but
            // the currently active particles will still conclude their behaviour
            ps.Stop();
        }
    }
}
