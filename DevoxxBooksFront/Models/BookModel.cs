using System.Collections.Generic;
using Newtonsoft.Json;

namespace DevoxxBooksFront.Models
{
    public class BookModel
    {
        [JsonProperty("bookId")]
        public int BookId { get; set; }
        
        [JsonProperty("bookTitle")]
        public string BookTitle { get; set; }
        
        [JsonProperty("bookType")]
        public string BookType { get; set; }
        
        [JsonProperty("bookPublication")]
        public int BookPublication { get; set; }
        
        [JsonProperty("autorName")]
        public string AuthorName { get; set; }
    }
}