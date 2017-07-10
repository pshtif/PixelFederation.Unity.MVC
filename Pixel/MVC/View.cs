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
    public class View<T> : View where T : MVCApplication
    {
        new public T application { get { return (T)base.application; } }
    }

    public class View : MVCBase { }
}
