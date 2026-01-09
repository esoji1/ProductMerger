using UnityEngine;

namespace _Project.IndependentComponents
{
    public class FPSCapRemover
    {
        public void Initialize()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
    }
}