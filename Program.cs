using System;
using Tesseract;

namespace TextDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "/Users/christioner/Projects/MyDemo/ConsoleIMGWhite/ConsoleIMGWhite/img/tt3.png"; // 设置要判断的图片路径
            bool hasText = false; // 初始化是否有文字的标志为false

            // Environment.SetEnvironmentVariable("TESSDATA_PREFIX", "/Users/christioner/Projects/MyDemo/ConsoleIMGWhite/ConsoleIMGWhite/tessdata");
            
            // 创建OCR引擎
            using (var engine = new TesseractEngine("/Users/christioner/Projects/MyDemo/ConsoleIMGWhite/ConsoleIMGWhite/tessdata", "chi_sim", EngineMode.Default))
            {
                // 读取图片
                using (var image = Pix.LoadFromFile(imagePath))
                {
                    // 进行OCR识别
                    using (var page = engine.Process(image))
                    {
                        // 获取识别结果
                        string text = page.GetText();

                        // 判断是否有文字
                        hasText = !string.IsNullOrWhiteSpace(text);
                    }
                }
            }

            // 输出结果
            if (hasText)
            {
                Console.WriteLine("该图片中有文字。");
            }
            else
            {
                Console.WriteLine("该图片中没有文字。");
            }
        }
    }
}