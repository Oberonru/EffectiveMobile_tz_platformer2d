﻿using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public abstract class BaseObjectInstaller : MonoInstaller
    {
        [SerializeField] private bool _asSingle = true;

        public bool AsSingle => _asSingle;
    }
}