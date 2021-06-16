using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids.UI
{
    public abstract class BaseUI : MonoBehaviour
    {
        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}
