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
    public class MVCApplication<M, V, C> : MVCApplication where M : MVCBase where V : MVCBase where C : MVCBase
    {
        new public M model { get { return (M)(object)base.model; } }

        new public V view { get { return (V)(object)base.view; } }

        new public C controller { get { return (C)(object)base.controller; } }
    }

    public class MVCApplication : MVCBase
    {
        static private bool _initialized = false;

        private Model _model;
        public Model model { get { return _model = _model ? _model : Find<Model>(); } }

        private View _view;
        public View view { get { return _view = _view ? _view : Find<View>(); } }

        private Controller _controller;
        public Controller controller { get { return _controller = _controller ? _controller : Find<Controller>(); } }

        public void Notify(string p_event, Object p_dispatcher, params object[] p_data)
        {
            NotifyGameObject((GameObject gameObject) => { 
                Controller[] list = gameObject.GetComponents<Controller>();
                for (int i = 0; i < list.Length; i++) list[i].OnNotification(p_event, p_dispatcher, p_data);
            });
        }

        virtual protected void Start()
        { 
            if (!_initialized) {
                _initialized = true;
                Notify("application.start");
            }
        }
    }
}
