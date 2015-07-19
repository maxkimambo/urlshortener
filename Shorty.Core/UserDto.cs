using System;

namespace Shorty.Core
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserId { get; set;  }
        public int AccessCount { get; set; }
        public DateTime LastAccessedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}