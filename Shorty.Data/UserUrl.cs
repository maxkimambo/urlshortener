using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shorty.Data
{
    public class UserUrl
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string OriginalUrl { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        public string UserId { get; set; }
        public int AccessCount { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LastAccessedOn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ExpiresOn { get; set; }
    }
}