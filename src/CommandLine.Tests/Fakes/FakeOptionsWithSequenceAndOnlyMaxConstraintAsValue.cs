﻿// Copyright 2005-2015 Giacomo Stelluti Scala & Contributors. All rights reserved. See doc/License.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLine.Tests.Fakes
{
    class FakeOptionsWithSequenceAndOnlyMaxConstraintAsValue
    {
        [Value(0, Max=3)]
        public IEnumerable<string> StringSequence { get; set; }
    }
}
