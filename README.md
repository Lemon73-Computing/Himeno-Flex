# Himeno_Flex

## 概要
こちらのソフトウェアは、[理化学研究所](https://www.riken.jp)/[情報システム部](https://i.riken.jp)
で発表されている[姫野ベンチマーク](https://i.riken.jp/supercom/documents/himenobmt/)をGUIにしたソフトウェアです。<br />
(内蔵している姫野ベンチマークはC言語/計算サイズ:```m```です。)<br />
理論上はWindows/MacOS/Android/iOSで使えます。<br />
(が、現在の予定ではWindowsのみ配布する予定です。ほかのMacOSなどで使いたい場合はこちらのレポジトリから自分でビルドしてください。)<br />

## 開発状況
完成
- UI

未完成
- 姫野ベンチ読み込み部分
- アイコン/起動画面

## 技術
プログラム言語
- C#(メイン)
- C++/CLI(C言語で書かれた姫野ベンチを一部書き換えている)

デザイン言語
- .xaml

フレームワーク
- .NET 7.0
- MAUI

## ライセンス
[LGPLv2.1](LICENSE.txt)です。<br />
(姫野ベンチのライセンスによって)<br />

## 開発する
#### Windows/MacOSの場合
VisualStudioで.slnファイルを開けば利用できるかと思います。<br />

#### Linuxの場合
諦めてください。<br />
<br />
MAUIはLinuxでも使えるという噂がありますが、実際に使えるかはわかりません…<br />
(自分もLinux向けのビルドをいろいろと試してみましたが無理でした。)<br />
Linuxを使ってAndroid向けのビルドは可能だそうです。<br />

<details>
<summary>Linux/Solaris向けについて</summary>
Linux/Solaris用としてJavaFX版Himeno_Flexを作成する可能性が(ミジンコ並みに僅かですが)あります。<br />
(もともと作る予定だったけど、こっちの開発が予想以上に時間がかかっているので、作れなさそう…)<br />
</details>
