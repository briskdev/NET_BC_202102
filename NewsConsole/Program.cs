using NewsLogic.Managers;
using System;

namespace NewsConsole
{
    class Program
    {
        private static NewsManager news = new NewsManager();
        private static TopicManager topics = new TopicManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Topics: ");
            topics.GetAllTopics().ForEach(t =>
            {
                Console.WriteLine(t.Title);
            });

            Console.WriteLine("Articles: ");
            news.GetLatestNews().ForEach(a =>
            {
                Console.WriteLine(a.Title);
            });
        }
    }
}
