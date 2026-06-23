
using System;
using System.IO;
using ScreenRecorderLib;

namespace MargBooks1.Helpers
{
    public static class VideoRecorder
    {
        private static Recorder recorder;
        public static string VideoPath;

        public static void StartRecording(string testName)
        {
            string folder =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Videos");
           
            Directory.CreateDirectory(folder);

            VideoPath = Path.Combine(
                folder,
                $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");

            recorder = Recorder.CreateRecorder();

            recorder.Record(VideoPath);
        }

        public static void StopRecording()
        {
            recorder?.Stop();
        }
    }
}