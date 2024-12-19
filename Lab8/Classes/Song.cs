using System;

namespace Lab8
{
    /// <summary>
    /// Класс, представляющий песню.
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Название песни.
        /// </summary>
        private string name;
        /// <summary>
        /// Автор песни.
        /// </summary>
        private string author;

        /// <summary>
        /// Ссылка на предыдущую песню.
        /// </summary>
        private Song? prev;

        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            this.prev = null;
        }
        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }
        public Song()
        {

        }


        /// <summary>
        /// Устанавливает название песни.
        /// </summary>
        /// <param name="name">Название песни.</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Устанавливает автора песни.
        /// </summary>
        /// <param name="author">Автор песни.</param>
        public void SetAuthor(string author)
        {
            this.author = author;
        }

        /// <summary>
        /// Устанавливает ссылку на предыдущую песню.
        /// </summary>
        /// <param name="prev">Предыдущая песня.</param>
        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        /// <summary>
        /// Выводит информацию о песне в консоль.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Название песни: {name}\nАвтор песни: {author}");
        }

        /// <summary>
        /// Возвращает заголовок песни в формате "Название - Автор".
        /// </summary>
        /// <returns>Строка с заголовком песни.</returns>
        public string Title()
        {
            return $"{name} - {author}";
        }

        /// <summary>
        /// Определяет, равна ли текущая песня другой песне.
        /// </summary>
        /// <param name="d">Объект для сравнения.</param>
        /// <returns>True, если песни равны, иначе False.</returns>
        public override bool Equals(object d)
        {
            if (d is Song otherSong)
            {
                return name == otherSong.name && author == otherSong.author;
            }
            return false;
        }
    }
}