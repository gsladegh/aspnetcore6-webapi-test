namespace HotelListing.API.Data
{
    /// <summary>
    /// these classes in the data folder are for data operations, not the API
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