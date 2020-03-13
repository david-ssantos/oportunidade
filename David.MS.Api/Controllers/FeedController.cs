using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using David.MS.Application.Interface;
using David.MS.Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace David.MS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        IFeed _feed;
        IConfiguration _config;
        public FeedController(IFeed feed, [FromServices] IConfiguration config)
        {
            _feed = feed;
            _config = config;
        }

        [HttpGet]
        public WordsCountModel get()
        {
            //api/feed
            var model = _feed.GetTopWords(ConfigurationBinder.GetValue<string>(_config, "UriFeed"));

            return model;
        }
    }
}