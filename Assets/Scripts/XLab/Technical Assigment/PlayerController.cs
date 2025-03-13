using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Spawner spawner;
        [SerializeField] private CloudController cloudController;
        [SerializeField] private FreeCamera freeCamera;
        [Space]
        [SerializeField] private List<Refresh> villagers;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                spawner.Spawn();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                cloudController.Action();

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var villager in villagers)
                {
                    villager.ChangeTool();
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                freeCamera.CameraIncreaseSpeed(true);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                freeCamera.CameraIncreaseSpeed(false);
            }
        }
    }
}