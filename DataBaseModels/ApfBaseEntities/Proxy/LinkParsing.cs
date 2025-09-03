using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseModels.ApfBaseEntities.Proxy
{
    public static class LinkParsing
    {
        public static Guid[] ParseBranchGroupUid(
            string value, ApfBaseContext ctx)
        {
            if (string.IsNullOrWhiteSpace(value)) return new Guid[0];

            var acc = new List<Guid>();
            foreach (var raw in value.Split(
                new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var token = raw.Trim();
                if (token.Length == 0) continue;

                if (Guid.TryParse(token, out Guid g))
                {
                    acc.Add(g);
                }
                else
                {
                    var bg = ctx.BranchGroup.FirstOrDefault(
                        b => b.Name == token);

                    if (bg != null) acc.Add(bg.Uid);
                }
            }
            return acc.Distinct().ToArray();
        }

        public static int[] ParseAnnexIds(string value, ApfBaseContext ctx)
        {
            if (string.IsNullOrWhiteSpace(value)) return new int[0];

            var acc = new List<int>();
            foreach (var raw in value.Split(
                new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var token = raw.Trim();
                if (token.Length == 0) continue;

                if (int.TryParse(token, out int id))
                {
                    acc.Add(id);
                }
                else
                {
                    var annex = ctx.Annex.FirstOrDefault(
                        a => a.Name == token);

                    if (annex != null) acc.Add(annex.Id);
                }
            }
            return acc.Distinct().ToArray();
        }
    }
}
