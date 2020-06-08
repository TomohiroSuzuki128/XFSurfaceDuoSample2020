# Surface Duo を先取り。Dual Screen 対応アプリを作ってみよう！
　  
現在、パブリックプレビューですが、すでに、Surface Duo のエミュレーターが公開されていますので、Xamarin.Forms で Surface Duo の Dual Screen を利用したサンプルアプリを作って動かしてみましょう。
　  
　  
サンプルアプリとして、駅の時刻表をイメージしたアプリを準備しました。左ペインで、路線と駅を選ぶと、右ペインに時刻が表示されます。
このような構成で Dual Screen は非常に効果的です。
　  
　  
アプリの構成をシンプルに理解するために、Prism などのフレームワークを使わず、素の Xamarin.Forms で構成しています。
　  
　  
なお、路線名、駅名、時刻は実在しないダミーです。
　  
![](https://github.com/TomohiroSuzuki128/XFSurfaceDuoSample2020/blob/master/images/001.png?raw=true)
　  
　  
# 準備 #
　  
## SDK のインストール ##
　  
API 29 の SDK をインストールします。
　  
![](https://github.com/TomohiroSuzuki128/XFSurfaceDuoSample2020/blob/master/images/010.png?raw=true)
  
![](https://github.com/TomohiroSuzuki128/XFSurfaceDuoSample2020/blob/master/images/011.png?raw=true)
　  
　  
## Surface Duo エミュレーター のセットアップ ##
以下の手順で、Surface Duo のエミュレーターをダウンロード、インストールします。
　  
### Windows ###
  
[https://docs.microsoft.com/ja-jp/dual-screen/android/get-duo-sdk?tabs=windows#download-and-install-the-surface-duo-sdk](https://docs.microsoft.com/ja-jp/dual-screen/android/get-duo-sdk?tabs=windows#download-and-install-the-surface-duo-sdk)
　  
　  
### Mac ###
  
[https://docs.microsoft.com/ja-jp/dual-screen/android/get-duo-sdk?tabs=mac#download-and-install-the-surface-duo-sdk](https://docs.microsoft.com/ja-jp/dual-screen/android/get-duo-sdk?tabs=mac#download-and-install-the-surface-duo-sdk)
　  
　  
## Surface Duo エミュレーター の起動スクリプトの確認 ##
以下の手順で、Surface Duo エミュレーターの起動スクリプトの設定を確認します。
（Android SDK のインストールパスがデフォルトの場合、変更の必要はありません。）
　  
　  
### Windows ###
  
[https://docs.microsoft.com/ja-jp/dual-screen/android/use-emulator?tabs=csharp%2Cwindows#xamarin-developers](https://docs.microsoft.com/ja-jp/dual-screen/android/use-emulator?tabs=csharp%2Cwindows#xamarin-developers)
　  
　  
### Mac ###
  
[https://docs.microsoft.com/ja-jp/dual-screen/android/use-emulator?tabs=csharp%2Cmac#xamarin-developers](https://docs.microsoft.com/ja-jp/dual-screen/android/use-emulator?tabs=csharp%2Cmac#xamarin-developers)
　  
　  
# アプリの実行 #
  
Surface Duo エミュレーターを起動します。
  
Visual Studio でソリューションを開き、ビルドして、(実行中のデバイスの一覧で) <build> (Android 10.0 - API 29) を選択し、実行します。
  
![](https://github.com/TomohiroSuzuki128/XFSurfaceDuoSample2020/blob/master/images/012.png?raw=true)
　  
　  
# Dual Screen 対応アプリの仕組み #
  
Dual Screen に対応するには、以下の対応を行うだけであり、非常に簡単です。
  
- コンテンツ（UI） を記述した XAML を分離する。
- Single Screen 用と、Dual Screen 用の "ガワ" の ContentPage を用意し、コンテンツを配置する。
- アプリが、Single Screen モード、Dual Screen モードのどちらで動いているかを判断し、適切な UI を表示する。
　  
　  
### Single Screen 時の構成 ###
  
![](https://github.com/TomohiroSuzuki128/XFSurfaceDuoSample2020/blob/master/images/021.png?raw=true)
　  
　  
### Dual Screen 時の構成 ###
  
![](https://github.com/TomohiroSuzuki128/XFSurfaceDuoSample2020/blob/master/images/020.png?raw=true)
　  
　  
# 早速アプリをビルドして実行してみましょう #
  
仕組みがわかりましたので、早速アプリを実行してみましょう。
　  
　  
Dual Screen で表示させるためには以下の手順でアプリを*スパン*してください。
　  
　  
[エミュレーターでアプリをスパンする](https://docs.microsoft.com/ja-jp/dual-screen/android/use-emulator?tabs=java%2Cwindows#span-your-app-in-the-emulator)
