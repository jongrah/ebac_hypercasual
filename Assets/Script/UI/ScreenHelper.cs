using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType _screenType;

        public void OnClick()
        {
            ScreenManager.Instance.ShowByType(_screenType);
        }
    }

}