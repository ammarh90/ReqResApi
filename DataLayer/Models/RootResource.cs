namespace ReqResApi.DataLayer.Models
{
    public class RootResource
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Resource> data { get; set; }
        public Support support { get; set; }
    }
}
