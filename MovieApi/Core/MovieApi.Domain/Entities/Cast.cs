namespace MovieApi.Domain.Entities {
    public class Cast {
        public int CastId { get; set; }
        public required string Title { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Overview { get; set; } = null!;
        public string Biography { get; set; } = null!;
    }
}
