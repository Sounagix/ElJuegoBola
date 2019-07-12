using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBola : MonoBehaviour
{
    public BullEyeManager bullEyeManager;
    public RampManager lRamp , rRamp;
    public CloserManager lCloser, rCloser;
    public bool servedBola { get; private set; }
    public void desactivaRampas()
    {
        servedBola = true;
        bullEyeManager.SetAllCollidersEyeBull(true);
        lRamp.setEnabled(false);
        rRamp.setEnabled(false);
        lCloser.desactiva(false);
        rCloser.desactiva(false);
    }
    public void ServingBola()
    {
        servedBola = false;
    }

}
