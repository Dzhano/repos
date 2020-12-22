using System;

namespace Articles_FirstSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article article = new Article();
            article.Author = input[2];
            article.Content = input[1];
            article.Title = input[0];
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                article = article.Command(article, command);
            }
            Console.WriteLine(article.ToString());
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article Command(Article article, string[] command)
        {
            switch (command[0])
            {
                case "Edit":
                    article.Content = command[1];
                    break;
                case "ChangeAuthor":
                    article.Author = command[1];
                    break;
                case "Rename":
                    article.Title = command[1];
                    break;
            }
            return article;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
