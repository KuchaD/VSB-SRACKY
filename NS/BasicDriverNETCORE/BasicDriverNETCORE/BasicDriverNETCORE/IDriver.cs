using System;
using System.Collections.Generic;

namespace BasicDriverNETCORE
{
    public interface IDriver
    {
        Dictionary<String, float> drive(Dictionary<String, float> values);
    }
}