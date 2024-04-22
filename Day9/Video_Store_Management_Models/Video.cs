namespace Video_Store_Management_Models
{
    public class Video
    {
       public int Id { get; set; }  
       public string Title { get; set; }

        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public decimal RentalPrice { get; set; }
    }
}

