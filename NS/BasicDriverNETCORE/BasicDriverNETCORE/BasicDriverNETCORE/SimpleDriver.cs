using System;
using System.Collections.Generic;

namespace BasicDriverNETCORE
{
    class SimpleDriver : IDriver
    {
        public Dictionary<String, float> drive(Dictionary<String, float> values) {
            Dictionary<String, float> responses = new Dictionary<String, float>();
            float distance0 = values["distance0"];
            // pokud je v levo jede doprava, jinak do leva
            if (distance0 < 0.5) {
                responses.Add("wheel", 0.8f);
            } else {
                responses.Add("wheel", 0.2f);
            }
            // maximalni zrychleni
            responses.Add("acc", 1f);
            return responses;
        }
    }
}