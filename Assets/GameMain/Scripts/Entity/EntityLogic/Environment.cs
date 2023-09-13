using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BladeHonor
{
    public class Environment : Entity
    {
        [SerializeField] private Transform _decorationRoot;
        [SerializeField] private Transform _interactiveRoot;

        [SerializeField] private SpriteRenderer[] _allDecorations;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            _allDecorations = _decorationRoot.GetComponentsInChildren<SpriteRenderer>().ToArray();
        }
        
        
    }
}
