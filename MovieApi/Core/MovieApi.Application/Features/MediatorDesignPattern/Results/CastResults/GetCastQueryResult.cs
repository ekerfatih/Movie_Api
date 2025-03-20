namespace MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults {
    public class GetCastQueryResult {
        public int CastId { get; set; }
        public required string Title { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Overview { get; set; } = null!;
        public string Biography { get; set; } = null!;
    }
}
