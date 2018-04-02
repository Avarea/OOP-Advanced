using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new File("fileName",10,10);
            Music music = new Music("artist", "album", 10, 10);
            StreamProgressInfo musicInfo = new StreamProgressInfo(music);
            StreamProgressInfo filesInfo = new StreamProgressInfo(file);

            Console.WriteLine(musicInfo.CalculateCurrentPercent());
            Console.WriteLine(filesInfo.CalculateCurrentPercent());
        }
    }
}
