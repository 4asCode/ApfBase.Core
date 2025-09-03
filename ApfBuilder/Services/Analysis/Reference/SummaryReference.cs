using System;
using System.Collections.Generic;

namespace ApfBuilder.Services.Analysis.Reference
{
    public class SummaryReference
    {
        public Dictionary<string, HashSet<int>> ReferenceIds { get; } = 
            new Dictionary<string, HashSet<int>>(
                StringComparer.OrdinalIgnoreCase);

        public void Add(string key, int id)
        {
            if (!ReferenceIds.TryGetValue(key, out var set))
            {
                ReferenceIds[key] = set = new HashSet<int>();
            }
            set.Add(id);
        }

        public int GetCount(string key)
        {
            return ReferenceIds.TryGetValue(
                key, out var set) ? set.Count : 0;
        }
    }
}
