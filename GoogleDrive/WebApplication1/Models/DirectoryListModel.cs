using System.Collections.Generic;
using Google.Apis.Drive.v3.Data;

namespace WebApplication1.Models
{
    public class DirectoryListModel
    {
        public string DirectoryId { get; set; }
        
        public string DirectoryName { get; set; } 
        public List<Google.Apis.Drive.v3.Data.File> Files { get; set; }
    }
}