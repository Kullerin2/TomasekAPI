namespace TomasekCore.ApiApp.Entities
{
    /// <summary>
    /// This represents the Pet entity.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pet" /> class.
        /// </summary>
        public Pet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pet" /> class.
        /// </summary>
        /// <param name="cityName">City name.</param>
        public Pet(int id, string name, string status, Category category = null, Tag[] tags = null, PhotoUrls photoUrls = null)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.Category = category;
            this.Tags = tags;
            this.PhotoUrls = photoUrls;
        }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        public string Name { get; set; }
        public int ID { get; set; }

        public string Status { get; set; }

        public Category Category { get; set; }
        public Tag [] Tags { get; set; }

        public PhotoUrls PhotoUrls  { get; set; }

    }
}