using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    class Comment
    {
        public string Author { get; }
        public string Text { get; }

        public Comment(string author, string text)
        {
            Author = author;
            Text = text;
        }

        public override string ToString() => $"{Author}: {Text}";
    }

    class Video
    {
        public string Title { get; }
        public string Author { get; }
        public int Duration { get; }
        private List<Comment> Comments { get; } = new List<Comment>();

        public Video(string title, string author, int duration)
        {
            Title = title;
            Author = author;
            Duration = duration;
        }

        public void AddComment(Comment comment) => Comments.Add(comment);
        public int GetCommentCount() => Comments.Count;
        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}\nAuthor: {Author}\nDuration: {Duration} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($"  - {comment}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>
            {
                new Video("Learning C#", "C# Channel", 600),
                new Video("OOP in C#", "Dev Tutorial", 750),
                new Video("Data Structures", "Code Academy", 900)
            };

            videos[0].AddComment(new Comment("Amon", "Great explanation!"));
            videos[0].AddComment(new Comment("Sharon", "Very good, thanks!"));

            videos[1].AddComment(new Comment("Trump", "Clear explanation."));
            videos[1].AddComment(new Comment("Moises", "Very useful, thanks!"));

            videos[2].AddComment(new Comment("Amanda", "I liked the approach."));
            videos[2].AddComment(new Comment("Bolsonaro", "I need to review some concepts."));

            foreach (var video in videos)
            {
                video.DisplayInfo();
            }
        }
    }
}
