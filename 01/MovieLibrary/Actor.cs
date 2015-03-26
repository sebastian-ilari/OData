using System.Data.Services.Common;

namespace MovieLibrary
{
    [DataServiceKey("Name")]
    public class Actor
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public bool Visible { get; set; }
    }
}