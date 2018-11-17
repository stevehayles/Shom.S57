using S57;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shom.s57
{
    public static class FeatureExtensions
    {
        public static IDictionary<S57Attribute, string> GetFeatureAttributes(this Feature feature)
        {
            if (feature.Attributes != null)
            {
                return feature.Attributes.ToDictionary(i => S57Attributes.Get(i.Key), i => i.Value);
            }
            else
            {
                return new Dictionary<S57Attribute, string>();
            }         
        }
    }
}
