namespace DogsApp.Models.Dog
{
    public class DogAllViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }


        public string Breed { get; set; } = null!;

        public string? Pictures { get; set; }
    }
}
