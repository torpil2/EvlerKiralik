using EvlerKiralik.DAL.Entities;
namespace EvlerKiralik.Model
{
    public class GonderiModel
    {
        public IEnumerable<User>? GonderiUser { get; set; }
        public IEnumerable<Picture>? GonderiPic { get; set; }
        public IEnumerable<KirayaVerme>? GonderiKirayaVerme { get; set; }
    }
}
