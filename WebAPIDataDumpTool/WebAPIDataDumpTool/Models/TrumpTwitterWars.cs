using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDataDumpTool.Models
{
    class TrumpTwitterWars
    {
        public string Description { get; set; }
        public int StatusesCount { get; set; }
        public int FollowersCount { get; set; }
        public int FavoritesCount { get; set; }
        public int FriendsCount { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Created { get; set; }
        public string Protected1 { get; set; }
        public string Verified { get; set; }
        public string ScreenName { get; set; }
        public string Location { get; set; }
        public string Lang { get; set; }
        public string Id { get; set; }
        public string ListedCount { get; set; }
        public string FollowRequestSent { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Rank { get; set; }

    }
}