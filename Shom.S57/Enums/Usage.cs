﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S57
{

    public enum Usage
    {
        ExteriorBoundaries = 1,                         // E
        InteriorBoundaries = 2,                         // I
        ExteriorBoundaryTruncatedByDataLimit = 3,       // C
        NotRelevant = 255
    }

}
