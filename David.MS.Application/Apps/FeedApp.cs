using David.MS.Application.Interface;
using David.MS.Entity;
using David.MS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using David.MS.Application.Helper;

namespace David.MS.Application.Apps
{
    public class FeedApp : IFeed
    {
        IUtil _util;
        public FeedApp(IUtil util)
        {
            _util = util;
        }
        public IEnumerable<PostModel> Posts(string uri)
        {
            var obj = _util.GetXml<Rss>(uri);
            return Convert(obj);
        }

        public WordsCountModel GetTopWords(string uri)
        {
            var posts = this.Posts(uri);
            var wordsCountModel = new WordsCountModel();
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            String artigosPreposicoes = "(?i)(\\w)(\\s+)(se|e|é|o|ou|os|a|as|um|uns|uma|umas|a|ao|aos|à|às|de|do|dos|da|das|dum|duns|duma|dumas|em|no|nos|na|nas|num|nuns|numa|numas|por|pelo|pelos|pela|pelas)(\\s+)(\\w)"; 

            foreach (var post in posts)
            {
                var text = post.Text.ToLower().Replace(",","").Replace("(","").Replace(")","");
                text = Regex.Replace(text, "<.*?>", String.Empty);
                text = Regex.Replace(text, artigosPreposicoes, "$1 $5");
                text = text.Replace("r$", "");
                
                var wordsSplit = text.Split(" ").Where(x => x.Length > 1);

                wordsCountModel.WordsByTopic.Add(post.Title, wordsSplit.Count());

                foreach(var word in wordsSplit)
                {
                    if (wordsCount.ContainsKey(word))
                        wordsCount[word]++;
                    else
                        wordsCount.Add(word, 1);
                }
            }

            var sortedList = new SortedList<int, string>(new DuplicateKeyComparer<int>());

            foreach (var dic in wordsCount)
            {
                sortedList.Add(dic.Value, dic.Key);
            }

            wordsCountModel.TotalWords = sortedList.TakeLast(10);

            return wordsCountModel; 
        }

        private IEnumerable<PostModel> Convert(Rss feed)
        {
            return feed.Channel.Item.Select(x => new PostModel()
            {
                Description = x.Description,
                Text = x.Encoded,
                Title = x.Title

            }) ;
        }
    }
}
