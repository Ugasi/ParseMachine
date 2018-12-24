using System;
using System.Collections.Generic;
using System.Text;

namespace ParseMachine
{
    public class TestParser : Parser
    {
        public override ParserProperties SetProperties()
        {
            return new ParserProperties() { NextPageXpath = "asd" };
        }
    }
}
