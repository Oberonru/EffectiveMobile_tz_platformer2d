using UnityEngine;
using System;

namespace Infrastructure.SO
{
    public class ScriptableObjectIdentity : ScriptableObject
    {
        public string GUID => _guid;
        private string _guid = Guid.NewGuid().ToString();
    }
}