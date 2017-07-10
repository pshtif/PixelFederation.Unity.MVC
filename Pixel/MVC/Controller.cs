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
    public delegate void NotificationCallback(string p_event, Object p_dispatcher, params object[] p_args);

    public class Controller<T> : Controller where T : MVCApplication
    {
        new public T application { get { return (T)base.application; } }
    }

    public class Controller : MVCBase
    {
        virtual public void OnNotification(string p_event, Object p_dispatcher, params object[] p_args) { }
    }
}
