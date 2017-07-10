/*
 *  MVC framework for Unity
 * 
 *	Copyright 2017 Peter @sHTiF Stefcek. All rights reserved.
 *	
 *	Work in progress
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pixel.MVC
{
    public class MVCBase<T> : MVCBase where T : MVCApplication
    {
        new public T application { get { return (T)base.application; } }
    }

    public class MVCBase : MonoBehaviour
    {
        private MVCApplication _application;
        public MVCApplication application { get { return _application = _application ? _application : Find<MVCApplication>(true); } }

        public T Find<T>(bool p_all = false) where T : Object
        {
            return p_all ? GameObject.FindObjectOfType<T>() : transform.GetComponentInChildren<T>();
        }

        public T[] FindMultiple<T>(bool p_all = false) where T : Object
        {
            return p_all ? GameObject.FindObjectsOfType<T>() : transform.GetComponentsInChildren<T>();
        }

        public void Notify(string p_event, params object[] p_data)
        {
            application.Notify(p_event, this, p_data);
        }

        protected void NotifyGameObject(System.Action<GameObject> p_callback, GameObject p_gameObject = null)
        {
            Transform t = p_gameObject ? p_gameObject.transform : transform;
            p_callback(t.gameObject);
            for (int i = 0; i < t.childCount; i++) { NotifyGameObject(p_callback, t.GetChild(i).gameObject); }
        }
    }
}
