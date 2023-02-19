using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Resources
{
    [Serializable]
    public class ResourcesList : ICollection<ResourceValuePair>, IEnumerable<ResourceValuePair>
    {
        [SerializeField]
        private List<ResourceValuePair> _resourceValuePairs;

        public List<ResourceValuePair> ResourceValuePairs => _resourceValuePairs;

        public int Count => _resourceValuePairs.Count;

        public bool IsReadOnly => false;

        public ResourcesList(List<ResourceValuePair> resourceValuePairs)
        {
            _resourceValuePairs = resourceValuePairs;
        }

        public ResourcesList()
        {
            _resourceValuePairs = new List<ResourceValuePair>();
        }

        public IEnumerator<ResourceValuePair> GetEnumerator()
        {
            return ResourceValuePairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ResourceValuePair item)
        {
            _resourceValuePairs.Add(item);
        }

        public void Clear()
        {
            _resourceValuePairs.Clear();
        }

        public bool Contains(ResourceValuePair item)
        {
            return _resourceValuePairs.Contains(item);  
        }

        public void CopyTo(ResourceValuePair[] array, int arrayIndex)
        {
            _resourceValuePairs.CopyTo(array, arrayIndex);
        }

        public bool Remove(ResourceValuePair item)
        {
            return _resourceValuePairs.Remove(item);
        }
    }
}