using David.MS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace David.MS.Application.Interface
{
    public interface IFeed
    {
        IEnumerable<PostModel> Posts(string uri);
        WordsCountModel GetTopWords(string uri);
    }
}
