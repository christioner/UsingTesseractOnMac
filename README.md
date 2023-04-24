# UsingTesseractOnMac

一个在mac上使用Tesseract.OCR判断图片是否空白的示例

主旨在于记录如何在Mac上使用改OCR开源工具

Mac 环境下的配置过程：
1. 打开终端并运行以安装
  brew install leptonica tesseract
2. 在项目的csproj文件中加入下面的配置项（替换$(OutDir)为输出目录，检查配置中的版本号是否正确）
  <Target Name="link_deps" AfterTargets="AfterBuild">
    <Exec Command="ln -sf /usr/local/lib/liblept.dylib $(OutDir)x64/libleptonica-1.80.0.dylib"/>
    <Exec Command="ln -sf /usr/local/lib/libtesseract.dylib $(OutDir)x64/libtesseract41.dylib"/>
  </Target>
3. 去https://github.com/tesseract-ocr/tessdata 中下载语言包
  设置代码中的语言包名称以及语言包位置（语言包文件名即其名称，路径试验时可以填写绝对路径）
4. 运行项目，程序会自动读取img目录下指定文件进行识别

PS：因为只是作为学习和参考使用，项目中上面提及的地方都没有设置为变量。
    windows环境的话，只需要安装并且设置语言包即可，第二步不是必要的。
