namespace HotelListing.API.Data
{
    /// <summary>
    /// one country can have many hotels
    /// </summary>
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }


        public virtual IList<Hotel> Hotels { get; set; }
    }
}