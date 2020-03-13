using System;
using System.Collections.Generic;
using System.Text;

namespace David.MS.Entity.Model
{
    public class WordsCountModel
    {
        public WordsCountModel()
        {

            WordsByTopic = new Dictionary<string, int>();
            TotalWords = new List<KeyValuePair<int, string>>();
        }
        public Dictionary<string, int> WordsByTopic { get; set; }
        public IEnumerable<KeyValuePair<int, string>> TotalWords { get; set; }
    }
}
