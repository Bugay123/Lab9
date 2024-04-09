namespace Lab9.DB
{
    public class MusicTrack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public string FullInfo { get => $"{Title} {Artist} ({Album} {Year})"; }
        public override string ToString() => FullInfo;
    }
}
